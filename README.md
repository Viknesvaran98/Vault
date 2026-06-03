# Vault - Password Manager

Password manager written in C#.

## Features

- Save website, username, and password entries
- Encrypt passwords before saving to disk
- Store entries in `passwords.json`
- Reveal/hide passwords with a toggle button
- Delete saved entries from the grid

## Requirements

- .NET 5 SDK
- Windows operating system

## Project files

- `MainForm.cs` — main form logic and UI event handlers
- `MainForm.Designer.cs` — generated WinForms designer for the main form
- `Program.cs` — application entry point
- `PasswordEntry.cs` — password entry model
- `EncryptionService.cs` — AES encryption and decryption helpers
- `FileService.cs` — JSON file save/load logic
- `PasswordManager.csproj` — .NET project file

## Build and Run

From the project root folder:

```powershell
dotnet build
dotnet run --project "PasswordManager.csproj"
```

## Usage

1. Enter a website name
2. Enter a username
3. Enter a password
4. Click **Add** to save the entry
5. Click the eye button to reveal or hide the password
6. Click **Delete** to remove an entry

## Notes

- Passwords are encrypted in the saved `passwords.json` file.
- The eye toggle shows the decrypted password only in the grid.
- The application currently targets `.NET 5.0-windows`.

## License

This repository does not include a license file yet. Add a `LICENSE` if you want to publish the project publicly.
