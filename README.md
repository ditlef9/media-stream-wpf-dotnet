# 📸 MediaStream – Dynamic Slideshow for Images & Videos

MediaStream is a real-time media player that automatically plays images and videos from a folder. 
Perfect for **photo booths, event displays, and digital signage**, 
it seamlessly updates when new media is added—no need to restart the slideshow! 🎥✨
It is programmed in C# WPF .net by S. Ditlefsen.


1. [⬇️ Download Exe file](#1-%EF%B8%8F-download-exe-file)
2. [💡 How it works](#2--how-it-works)
3. [✨ Features](#3--features)
4. [🎯 Use Cases](#4--use-cases)
5. [🛠 Installation of source code in Visual Studio](#5--installation)
6. [📂 How to Use](#6--how-to-use)
7. [⚙️ Create installation file](#7-%EF%B8%8F-create-installation-file)
8. [📜 License](#8--license)
9. [🤝 Contributing](#9--contributing)
10. [📬 Contact](#10--contact)


## 1 ⬇️ Download Exe file

![Download](docs/download_24dp_2854C5_FILL0_wght400_GRAD0_opsz24.png) 
[Download MediaStreamSetup.exe](https://github.com/ditlef9/media-stream-wpf-dotnet/raw/refs/heads/main/Installer/Output/MediaStreamInstaller.exe)
(Licensed under 
[Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0))

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


## 2 💡 How it works
1. Select folder where your pictures and videoes are located and Select "Start Slideshow". 
![Select folder](docs/main-window.png)

2. Slideshow starts automatically:
![Select folder](docs/slideshow-without-controls.jpg)

3. Move mouse to view the controls: 
![Select folder](docs/slideshow-with-controls.jpg)
 
4. Drop new files into the folder and they will be added to the slideshow automatically! Perfect for picture booths!

## 3 ✨ Features
- ✅ **Auto-Updating Slideshow** – Instantly plays new images & videos when added.
- ✅ **Supports Multiple Formats** – Works with `.jpg`, `.png`, `.mp4`, `.mov`, etc.
- ✅ **Smooth Transitions** – Provides a seamless viewing experience.
- ✅ **Folder Watching** – Detects and adds new files automatically.
- ✅ **Customizable Playback Speed** – Adjust transition times.
- ✅ **Lightweight & Fast** – Uses minimal system resources.

## 4 🎯 Use Cases
- **Photo Booths** – Instantly display pictures & videos taken at events.
- **Event Displays** – Perfect for conferences, weddings, or exhibitions.
- **Digital Signage** – Auto-updating promotional content.
- **Memory Slideshows** – Continuous playback of family photos & videos.

## 5 🛠 Installation of source code in Visual Studio
1. **Clone the repository**:
   ```sh
   git clone https://github.com/ditlef9/media-stream-wpf-dotnet.git
   cd MediaStream
   ```
2. **Open the project in Visual Studio**.
3. **Build & Run** the WPF application.

## 6 📂 How to Use
1. Place images & videos in the selected folder.
2. Run the app – it will start playing automatically!
3. Add new media anytime, and it will appear instantly.


## 7 ⚙️ Create installation file

1. Download Inno Setup: https://jrsoftware.org/isdl.php
2. Visual Studio > Build > Publish MediaStream


## 8 📜 License
This project is licensed under the
[Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0).

```
Copyright 2024 github.com/ditlef9

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0
```

## 9 🤝 Contributing
Pull requests are welcome! If you have suggestions for improvements, feel free to open an issue or create a PR.

## 10 📬 Contact
For questions or support, reach out via **[GitHub Issues](https://github.com/ditlef9/media-stream-wpf-dotnet/issues)**.

---
Made with ❤️ by Sindre
