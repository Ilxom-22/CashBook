# CashBook Mobile App

This is a .NET MAUI mobile application for the CashBook system that connects to the CashBook.Api backend.

## Features

- **Search Functionality**: Search through your cashbooks using the search bar
- **Cashbook List**: View all your cashbooks with their names, balances, and last updated dates
- **Add New Cashbook**: Tap the "ADD NEW BOOK" button to create a new cashbook
- **Context Menu**: Tap the three dots (⋮) next to each cashbook to:
  - Rename the cashbook
  - Delete the cashbook

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code with C# extension
- For Android: Android SDK
- For iOS: Xcode (Mac only)
- Running CashBook.Api backend

## Setup Instructions

1. **Start the Backend API**:
   ```bash
   cd ../backend/CashBook.Api
   dotnet run
   ```
   Note the port number (usually https://localhost:7086)

2. **Update API URL** (if needed):
   Open `Services/CashbookService.cs` and update the `BaseUrl` constant if your API runs on a different port:
   ```csharp
   private const string BaseUrl = "https://localhost:YOUR_PORT/api/cashbooks";
   ```

3. **Run the Mobile App**:
   ```bash
   cd CashBook.Mobile
   dotnet build
   ```

   For Android emulator:
   ```bash
   dotnet run --framework net8.0-android
   ```

   For iOS simulator (Mac only):
   ```bash
   dotnet run --framework net8.0-ios
   ```

   For Windows:
   ```bash
   dotnet run --framework net8.0-windows10.0.19041.0
   ```

## Project Structure

```
CashBook.Mobile/
├── Models/
│   └── CashbookModel.cs          # Data model for cashbooks
├── Services/
│   ├── ICashbookService.cs       # Service interface
│   └── CashbookService.cs        # API service implementation
├── ViewModels/
│   └── MainPageViewModel.cs      # Main page view model
├── MainPage.xaml                 # Main page UI
├── MainPage.xaml.cs              # Main page code-behind
└── MauiProgram.cs                # App configuration and DI setup
```

## API Integration

The mobile app integrates with the following CashBook API endpoints:

- `GET /api/cashbooks` - Get all cashbooks
- `POST /api/cashbooks` - Create a new cashbook
- `PUT /api/cashbooks/{id}` - Update a cashbook name
- `DELETE /api/cashbooks/{id}` - Delete a cashbook

## Troubleshooting

1. **Connection Issues**: 
   - Ensure the backend API is running
   - Check that the API URL in `CashbookService.cs` matches your backend URL
   - For Android emulator, you might need to use `10.0.2.2` instead of `localhost`

2. **Build Issues**:
   - Make sure you have the latest .NET 8 SDK installed
   - Clear the bin and obj folders and rebuild

3. **Platform-specific Issues**:
   - Android: Ensure you have the Android SDK installed and an emulator configured
   - iOS: Requires Xcode on macOS
   - Windows: Requires Windows 10 version 1903 or higher

## Development Notes

- The app uses MVVM pattern with data binding
- HttpClient is configured through dependency injection
- Error handling includes basic logging to debug output
- The UI follows the provided sketch design with modern MAUI styling