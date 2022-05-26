#define Name "Playlist of songs"

#define Version "0.0.1"

#define Publisher "Programming"

#define ExeName "PlaylistOfSongs.exe"

#define IconDir "Resources\music_folder_64x64.ico"

[Setup]

AppId = {{86E63F5A-0E81-4251-8976-9A643CD4FF2E}

PrivilegesRequired = admin

AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}

DefaultDirName={commonpf}\{#Name}

DefaultGroupName={#Name}

OutputDir=C:\PlaylistOfSongsSetup
OutputBaseFileName=Setup

SetupIconFile=C:\music_folder_64x64.ico

Compression=lzma
SolidCompression=yes

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "PlaylistOfSongs\PlaylistOfSongs\bin\Debug\PlaylistOfSongs.exe"; DestDir: "{app}"; Flags: ignoreversion

Source: "PlaylistOfSongs\PlaylistOfSongs\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

Source: "PlaylistOfSongs\PlaylistOfSongs\Resources\*"; DestDir: "{app}\Resources"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"; WorkingDir: "{app}"; IconFilename: "{app}\{#IconDir}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\{#IconDir}"; Tasks: desktopicon

Name: "{commonprograms}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\{#IconDir}"

Name: "{commonstartup}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\{#IconDir}" 

[Run]
Filename: "{app}\{#ExeName}"; Description: "{cm:LaunchProgram,{#StringChange(Name, "&", "&&")}}"; Flags: nowait postinstall skipifsilent runascurrentuser