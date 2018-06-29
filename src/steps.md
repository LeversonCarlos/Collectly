# Create Directories
   > mkdir Collectly.API
   > cd Collectly.API

# Create new project inside app directory
   > dotnet new web
   This will create a project using the directory name and the *AspNetCore template*.
   For a full list of options and other templates, use the folowing command:
   > dotnet new -h

# Add the Microsoft.AspNetCore.All metapakage through nuget
   > dotnet add package Microsoft.AspNetCore.All --version 2.1.1
   For details of whats included on this package go to [this page](https://www.nuget.org/packages/Microsoft.AspNetCore.All).
