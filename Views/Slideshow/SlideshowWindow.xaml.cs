using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MediaStream.Models;
using MediaStream.Views.Slideshow.helpers;  // Add this namespace

namespace MediaStream.Views
{
    public partial class SlideshowWindow : Window
    {
        // Declare timers
        private readonly DispatcherTimer hideUiTimer;
        private readonly DispatcherTimer countdownTimer;
        private int timeRemaining = 5;  // Change image every 5 seconds

        // Controls
        private Controls controls;  // Declare an instance of the Controls class

        // Media manager
        private readonly MediaManager mediaManager;

        // Constructor
        public SlideshowWindow(string folderPath)
        {
            InitializeComponent();


            // Initialize Controls class
            controls = new Controls();

            // Set up hide UI timer
            hideUiTimer = new DispatcherTimer();
            hideUiTimer.Interval = TimeSpan.FromSeconds(3); // Hide controls after 3 seconds of inactivity
            hideUiTimer.Tick += HideUiTimer_Tick;

            // Set up countdown timer for showing the time remaining
            countdownTimer = new DispatcherTimer();
            countdownTimer.Interval = TimeSpan.FromSeconds(1);
            countdownTimer.Tick += CountdownTimer_Tick;

            // Start countdown
            countdownTimer.Start();

            // Load image and show first
            mediaManager = new MediaManager(folderPath);  // Assuming MediaManager is initialized here.
            LoadMedia(mediaManager.GetNextMedia());


            // Update media list selection
            ShowMediaList();
        }

        /*- ShowControls ----------------------------------------------------------- */
        private void ShowControls()
        {
            controls.ShowControls(BtnPrevious, BtnNext, BtnClose, TxtTimer);
            MediaList.Visibility = Visibility.Visible; // Show media list on mouse movement
        } // ShowControls

        /*- HideControls ----------------------------------------------------------- */
        private void HideControls()
        {
            controls.HideControls(BtnPrevious, BtnNext, BtnClose, TxtTimer);
            MediaList.Visibility = Visibility.Collapsed; // Hide media list after inactivity
        } // HideControls

        /*- Window_MouseMove ------------------------------------------------------- */
        // Start the slideshow when mouse moves
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            ShowControls();
            MediaList.Visibility = Visibility.Visible; // Only make it visible on mouse movement
            hideUiTimer.Stop();
            hideUiTimer.Start();
        }


        /*- Window_MouseLeave ------------------------------------------------------ */
        // Mouse leaves window
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            HideControls();
            HideMediaList(); // Hide the list of media names
        }

        /*- BtnNext_Click ----------------------------------------------------------- */
        // Handle the "Next" button click
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            LoadMedia(mediaManager.GetNextMedia());
            // Logic for next image or media
        }

        /*- BtnPrevious_Click ------------------------------------------------------- */
        // Handle the "Previous" button click
        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            // Logic for previous image or media
        }

        // Handle the "Close" button click
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Hide UI after inactivity
        private void HideUiTimer_Tick(object sender, EventArgs e)
        {
            HideControls();
        }

        /*- CountdownTimer_Tick ----------------------------------------------------- */
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            TxtTimer.Text = $"Next in: {timeRemaining}s";

            if (timeRemaining <= 0)
            {
                countdownTimer.Stop();
                LoadMedia(mediaManager.GetNextMedia());
            }
        }

        /*- LoadMedia -------------------------------------------------------------- */
        private void LoadMedia(string filePath)
        {
            if (filePath == null) return;

            string extension = System.IO.Path.GetExtension(filePath).ToLower();
            if (extension == ".jpg" || extension == ".png" || extension == ".heic")
            {
                VideoDisplay.Visibility = Visibility.Collapsed;
                ImageDisplay.Visibility = Visibility.Visible;
                ImageDisplay.Source = new BitmapImage(new Uri(filePath));
            }
            else
            {
                ImageDisplay.Visibility = Visibility.Collapsed;
                VideoDisplay.Visibility = Visibility.Visible;
                VideoDisplay.Source = new Uri(filePath);
                VideoDisplay.Play();
            }

            // Set output to filename
            textBlockOutput.Text = System.IO.Path.GetFileName(filePath);

            // Reset Countdown
            timeRemaining = 5;
            TxtTimer.Text = $"Next in: {timeRemaining}s";
            countdownTimer.Start();

            // Update media list selection
            mediaManager.LoadMediaFiles();
            ShowMediaList();
        } // LoadMedia

        /*- ShowMediaList ---------------------------------------------------------- */
        private void ShowMediaList()
        {
            MediaList.Items.Clear(); // Clear any existing items

            string currentMediaFileName = System.IO.Path.GetFileName(mediaManager.GetCurrentMedia()); // Get only filename

            // Get a list of all media file paths
            foreach (var file in mediaManager.GetMediaFiles())
            {
                string fileName = System.IO.Path.GetFileName(file); // Get just the file name
                MediaList.Items.Add(fileName); // Add file name to the list

                // Highlight the current media file in the list
                if (fileName == currentMediaFileName)
                {
                    MediaList.SelectedItem = fileName;
                }
            }

            // Don't force MediaList visibility here; it will only change on mouse movement
        }



        /*- HideMediaList ---------------------------------------------------------- */
        private void HideMediaList()
        {
            MediaList.Visibility = Visibility.Collapsed; // Hide the list
        }

    }
}
