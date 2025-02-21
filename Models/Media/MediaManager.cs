using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;  // For EXIF data processing
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace MediaStream.Models
{
    public class MediaManager
    {
        private List<string> mediaFiles = new();
        private int currentIndex = -1;
        private string folderPath = "";

        private static readonly string[] SupportedExtensions = { ".jpg", ".jpeg", ".png", ".heic", ".mp4", ".mov" };


        public MediaManager(string folderPath)
        {
            this.folderPath = folderPath;
            LoadMediaFiles();
        }

        // Load Media Files
        public void LoadMediaFiles()
        {

            if (!Directory.Exists(folderPath)) return;


            // Get the current media files
            var updatedMediaFiles = Directory.GetFiles(folderPath)
                    .Where(file => SupportedExtensions.Contains(Path.GetExtension(file).ToLower()))
                    .OrderBy(f => f)
                    .ToList();

            // Remove any missing files from the list
            mediaFiles = mediaFiles.Where(file => updatedMediaFiles.Contains(file)).ToList();

            // Check for new or removed files
            foreach (var file in updatedMediaFiles)
            {
                if (!mediaFiles.Contains(file))
                    mediaFiles.Add(file); // Add any new files
            }

            // Sort mediafiles alpabetacily
            mediaFiles.Sort();

            // Reset index if the current file is removed
            if (currentIndex >= mediaFiles.Count)
            {
                currentIndex = mediaFiles.Count > 0 ? 0 : -1;
            }
        } // LoadMediaFiles



        // GetCurrentMedia
        public string GetCurrentMedia()
        {
            if (currentIndex >= 0 && currentIndex < mediaFiles.Count)
            {
                var filePath = mediaFiles[currentIndex];

                // If it's an image, apply rotation based on EXIF data
                string validFilePath = RotateImageBasedOnExif(filePath);

                // If the rotated file path is null (invalid or skipped), move to the next valid file
                if (validFilePath == null)
                {
                    return GetNextMedia(); // Skip the invalid file and go to the next one
                }

                return validFilePath;
            }

            return null;
        } // GetCurrentMedia


        // GetNextMedia
        public string GetNextMedia()
        {
            if (mediaFiles.Count == 0) return null;

            // Skip invalid files (those that return null when checked)
            do
            {
                currentIndex = (currentIndex + 1) % mediaFiles.Count;
            } while (string.IsNullOrEmpty(RotateImageBasedOnExif(mediaFiles[currentIndex])));

            return GetCurrentMedia(); // Returns the valid image or file path
        } // GetNextMedia

        // GetPreviousMedia
        public string GetPreviousMedia()
        {
            if (mediaFiles.Count == 0) return null;

            // Skip invalid files (those that return null when checked)
            do
            {
                currentIndex = (currentIndex - 1 + mediaFiles.Count) % mediaFiles.Count;
            } while (string.IsNullOrEmpty(RotateImageBasedOnExif(mediaFiles[currentIndex])));

            return GetCurrentMedia(); // Returns the valid image or file path
        } // GetPreviousMedia



        // RotateImageBasedOnExif
        private string RotateImageBasedOnExif(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            // If the file is .heic, return it as is (since System.Drawing.Bitmap does not support HEIC)
            if (extension == ".heic")
            {
                return filePath;
            }
            // Only process image files
            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png" && extension != ".heic")
            {
                return filePath; // Return video files as they are
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File does not exist: {filePath}");
                return null;
            }

            try
            {
                using (var image = new Bitmap(filePath))
                {
                    PropertyItem propertyItem;
                    try
                    {
                        propertyItem = image.GetPropertyItem(274);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine($"No EXIF data for: {filePath}");
                        return filePath; // Return original if no EXIF orientation data
                    }

                    int orientation = BitConverter.ToInt16(propertyItem.Value, 0);
                    RotateFlipType flipType = orientation switch
                    {
                        1 => RotateFlipType.RotateNoneFlipNone,
                        3 => RotateFlipType.Rotate180FlipNone,
                        6 => RotateFlipType.Rotate90FlipNone,
                        8 => RotateFlipType.Rotate270FlipNone,
                        _ => RotateFlipType.RotateNoneFlipNone
                    };

                    image.RotateFlip(flipType);

                    string rotatedFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(filePath));

                    try
                    {
                        image.Save(rotatedFilePath, ImageFormat.Jpeg);
                    }
                    catch (ExternalException ex)
                    {
                        Console.WriteLine($"Error saving image: {filePath} - {ex.Message}");
                        return filePath; // Return the original if saving failed
                    }

                    return rotatedFilePath;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Invalid image file: {filePath}");
                return null;
            }
        }



        // GetMediaFiles
        public List<string> GetMediaFiles()
        {
            return mediaFiles;
        } // GetMediaFiles
    }
}
