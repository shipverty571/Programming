#define Name "Playlist of songs"

#define Version "1.0.0"

#define Publisher "Programming"

#define ExeName "PlaylistOfSongs.exe"

#define UninstallName "Uninstall.exe"

#define IconName "music_folder_64x64.ico"

[Setup]

AppId = {{CF1D948F-EB58-4978-81A5-98FD8AFACDBE}

PrivilegesRequired = admin

AppName = {#Name}
AppVersion = {#Version}
AppVerName = {#Name}
AppPublisher = {#Publisher}

DefaultDirName = {commonpf}\{#Name}

DefaultGroupName = {#Name}

OutputDir = /Setup
OutputBaseFilename=Setup


SetupIconFile = {#IconName}
UninstallDisplayIcon = {app}\Resources\{#IconName}


Compression = lzma
SolidCompression=yes

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\PlaylistOfSongs\PlaylistOfSongs\bin\Release\{#ExeName}"; DestDir: "{app}";  Flags: ignoreversion

Source: "..\PlaylistOfSongs\PlaylistOfSongs\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

Source: "..\PlaylistOfSongs\PlaylistOfSongs\Resources\{#IconName}"; DestDir: "{app}\Resources"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#UninstallName}"; Filename: "{uninstallexe}"; IconFilename: "{app}\Resources\{#IconName}"

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\Resources\{#IconName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; IconFilename: "{app}\Resources\{#IconName}"; Tasks: desktopicon


[Run]
Filename: "{app}\{#ExeName}"; Description: "{cm:LaunchProgram,{#StringChange(Name, "&", "&&")}}"; Flags: nowait postinstall skipifsilent runascurrentuser


