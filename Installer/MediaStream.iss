[Setup]
AppName=MediaStream
AppVersion=1.0
DefaultDirName={pf}\MediaStream
DefaultGroupName=MediaStream
OutputBaseFilename=MediaStreamInstaller
Compression=lzma2
SolidCompression=yes
SetupIconFile=favicon.ico

[Files]
Source: "C:\Users\admin\csharp\media-stream-wpf-dotnet\bin\Release\net9.0-windows\MediaStream.exe"; DestDir: "{app}"
Source: "C:\Users\admin\csharp\media-stream-wpf-dotnet\bin\Release\net9.0-windows\*.dll"; DestDir: "{app}"
Source: "C:\Users\admin\csharp\media-stream-wpf-dotnet\bin\Release\net9.0-windows\*.*"; DestDir: "{app}"

[Icons]
Name: "{group}\MediaStream"; Filename: "{app}\MediaStream.exe"
Name: "{commondesktop}\MediaStream"; Filename: "{app}\MediaStream.exe"

[Run]
Filename: "{app}\MediaStream.exe"; Description: "Launch MediaStream"; Flags: nowait postinstall skipifsilent
