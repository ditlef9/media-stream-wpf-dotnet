// MainWindow.xaml.cs
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MediaStream.Models;
using MediaStream.Views;
using Microsoft.Win32;

namespace MediaStream;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private MediaManager mediaManager;
    private DispatcherTimer slideshowTimer;

    public MainWindow()
    {
        InitializeComponent();
        Console.WriteLine($"MainWindow()·MainWindow()·Initializing component");
        labelOutput.Content = "MainWindow()·MainWindow()·Initializing component";

        // Load config
        if (File.Exists("config.txt"))
        {
            // Read the entire content of the file
            string readConfig = File.ReadAllText("config.txt");
            labelFolderSelected.Content = readConfig;
        }

        // Start Media Manager
        /*
        mediaManager = new MediaManager();
        slideshowTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        slideshowTimer.Tick += SlideshowTimer_Tick;*/
    }

    // Select folder
    private void btnBrowse_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine($"MainWindow()·btnBrowse_Click()·Showing dialog box");
        labelOutput.Content = "btnBrowse_Click() · Showing dialog box";

        // Browse Open Folder
        var folderDialog = new OpenFolderDialog{};
        if (folderDialog.ShowDialog() == true)
        {
            // Get folder Path
            var folderPath = folderDialog.FolderName;

            // Set the folder path to label
            labelFolderSelected.Content = folderPath;

            // Save the folder path to JSON config file
            Console.WriteLine($"MainWindow()·btnBrowse_Click()·Saving folderPath to config.txt: {folderPath}");
            labelOutput.Content = $"btnBrowse_Click() · Saving folderPath to config.txt: {folderPath}";
            File.WriteAllText("config.txt", folderPath);

            //mediaManager.SetFolder(folderName);
        }
    }

    // Start slideshow
    private void btnStartSlideshow_Click(object sender, RoutedEventArgs e)
    {
        // Get folder Path
        string folderPath = (string)labelFolderSelected.Content;


        // Start Media
        if (folderPath != null)
        {
            labelOutput.Content = $"MainWindow()·btnStartSlideshow_Click()·Starting slideshow from directory ${folderPath}";
            Console.WriteLine($"btnStartSlideshow_Click() · Starting slideshow from directory ${folderPath}");

            // Start slideshow
            SlideshowWindow secondWindow = new SlideshowWindow(folderPath);
            secondWindow.Show(); // Opens the window

            // Close this window
            this.Close();
        }
    }



}