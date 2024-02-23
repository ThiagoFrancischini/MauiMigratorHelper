# MauiMigratorHelper

This is a Windows Forms application attempting to help migrate old Xamarin Projects (with the .shproj file) to .NET Maui.

First, create a new .NET Maui project (this application will not generate a MAUI project).
Second, run the application and provide the name and directory of the Xamarin Solution, as well as the name and directory of the Maui solution (where the .sln file is placed).
The system will retrieve your Xamarin files and organize them within your .NET Maui project in the correct folders. It will replace the namespaces of the old solution with the new ones and change Xamarin usings to Microsoft.Maui. Afterward, it will rearrange your Android and iOS project files to the Platforms/Android or Platforms/iOS directories in .NET Maui. In these directories, the startup files will not be replaced; instead, the old ones will be moved with "backupXF" appended to the file name.

Next, the system will retrieve the packages listed in packages.config, standardize them, and move them to the .csproj file of .NET Maui. Finally, it will retrieve the images from the Drawable folder in Android and move them to the shared image folder of .NET Maui.

IMPORTANT: This helper does like 10% of the job, when you launch the final solution you will get 1k+ errors of methods that no longer exists or nuget packages that don´t have support to MAUI, is just an automatization that I made to help me and I thought could help others. If you want feel free to change the code :)

PS: Sorry for the portuguese in the code lol
