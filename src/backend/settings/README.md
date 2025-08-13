# 🔧 Application Configuration Setup

This folder contains **environment-specific configuration templates** for the application.

## 📄 settings/app.config.template.json

This file serves as a **template or example** for what your environment-specific `app.config.json` should contain. You can copy and customize it for your local setup.

## 📂 Folder Structure

Each environment (e.g., `Development`, `Production`, `Staging`, etc.) should have its own subfolder with a `app.config.json` file:

Settings/

├── Development/

│   └── app.config.json

├── Production/

│   └── app.config.json

└── app.config.json (template)

## 🛠 How It Works

During build time, the correct environment config file is automatically copied over to `appsettings.json`, depending on the build configuration:

- `Debug` → `Development/app.config.json`
- `Release` → `Production/app.config.json`

This is handled by a custom MSBuild task in the project file (`.csproj` or `Directory.Build.targets`).

## 📥 Setup Instructions

1. **Create your environment folder** (if it doesn't exist):

settings/Development/     ← for Debug

settings/Production/      ← for Release

1. **Copy the template and customize it**:
2. **Edit your `app.config.json`** with your local settings:
    - Connection strings
    - API keys
    - Feature flags
    - Logging settings
    - Etc.

## 🚫 Do Not Commit Sensitive Files

> ⚠️ Environment config files (like Development/app.config.json) should not be committed to version control.
> 

By default all the folders within the settings folder are added to gitignore file in the root folder to prevent committing sensitive data to version control:

```bash
# Ignore all folders in Settings/
src/backend/settings/*/
```

## ✅ Result

Once configured, your project will automatically use the correct config file when built or run.

---