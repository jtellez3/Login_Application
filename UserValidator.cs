namespace Tellez_LoginApplication;
public class UserValidator
{
    // Return an error message if the information is invalid or null if it is valid.
    public string? ValidateLogin(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return "Please enter a username and password.";
        if (username.Length > 50 || password.Length > 128)
            return "Username or password is too long.";
        return null;
    }

    public string? ValidateNewUser(string username, string password, string confirm)
    {
        string? error = ValidateLogin(username, password);
        if (error != null) return error;
        // Compare both passwords before sending anything to SQL
        if (password != confirm) return "Passwords must match.";
        if (password.Length < 8) return "Please use at least 8 characters for your password.";
        return null;
    }
}
