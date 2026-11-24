# Tellez Login Application
C# Windows Forms classroom lab. Open LoginApplication.csproj in Visual Studio. The project targets .net10.0-windows in the project file. 

## Setup
1. Extract the ZIP to a new folder separate from your original blank project.
2. Open the .csproj file. Allow NuGet to restore Microsoft.Data.SqlClient 
3. Open SQL Server Management Studio or Visual Studio View > SQL Server Object Explorer. Connect to .\SQLEXPRESS using Windows Authentication. If your instance differs, use its actual name (e.g. (localdb)\MSSQLLocalDB) here and in UserDatabase.cs.
4. Open DatabaseSetup.sql in a SQL query window connected to that server and execute the whole script. You need permission to create a database.
5. Build > Build Solution, then press F5.

## Test checklist
- Create an account with a made-up username and matching password of at least 8 characters.
- Try creating the same username again: duplicate warning.
- Try mismatched passwords or empty fields: validation warning.
- Try an incorrect password: login rejected.
- Log in correctly: welcome form opens.
- Logout: login form returns. Log in again and choose Exit: application closes.
- Restart the application and log in again: account persists in SQL.
- Run the SELECT at the end of DatabaseSetup.sql: only hash and salt are stored, not plaintext.

## Code guide
Form1 handles the interface; LoggedInForm handles the success screen; UserValidator checks input; UserDatabase uses parameterized SQL; PasswordSecurity uses salted PBKDF2-SHA256. Hashing is intentionally one-way, unlike reversible encryption. The eight-character minimum is an additional classroom design choice. The local SQL connection trusts the server certificate; production applications should validate certificates and use a server-side authentication service.

## Submit
Use Visual Studio Git > Create Git Repository to publish to GitHub. Included source files, project file, README and SQL script. Did not include real passwords, .vs, bin or obj. Submit the repository URL to the dropbox
