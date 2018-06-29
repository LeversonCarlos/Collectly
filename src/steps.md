# Create Directories
   ```
   mkdir Collectly.API   
   cd Collectly.API
   ```

# Create new project inside app directory
   To create a project using the directory name and the *AspNetCore template*:
   ```
   dotnet new web
   ```
   
   For a full list of options and other templates, use the folowing command:
   ```
   dotnet new -h
   ```

# Add the AspNetCore metapakage through nuget
   ```
   dotnet add package Microsoft.AspNetCore.All --version 2.1.1
   ```
   For details of whats included on this package go to [this page](https://www.nuget.org/packages/Microsoft.AspNetCore.All).

# Creating the authentication data store
   Inside \Auth\Store directories add the following classes:
   * **UserData** inheriting from Microsoft.AspNetCore.Identity.IdentityUser.
      * We will also extend with some additional properties 
   * **RoleData** inheriting from Microsoft.AspNetCore.Identity.IdentityRole.
   * **dbContext** inheriting from Microsoft.AspNetCore.Identity.IdentityDbContext
      * Using the UserData object as a generics
      * On the constructor we enforce the database creation
      * And we overrides the ModelCreating event to define tables and columns name
