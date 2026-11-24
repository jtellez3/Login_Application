using Microsoft.Data.SqlClient;
namespace Tellez_LoginApplication;
public partial class Form1 : Form
{
    // These objects keep validation and database work separate from my form.
    private readonly UserValidator validator = new();
    private readonly UserDatabase database = new();
    public Form1() { InitializeComponent(); }

    private void btnCreateUser_Click(object? sender, EventArgs e)
    {
        string username = txtNewUsername.Text.Trim();
        string password = txtNewPassword.Text;
        string? error = validator.ValidateNewUser(username, password, txtConfirmPassword.Text);
        if (error != null) { MessageBox.Show(error); return; }
        try
        {
            if (!database.CreateUser(username, password))
            { MessageBox.Show("That username already exists. Please choose a different username."); return; }
            MessageBox.Show("Account created successfully! You can now log in.");
            txtUsername.Text = username;
            txtNewUsername.Clear(); txtNewPassword.Clear(); txtConfirmPassword.Clear();
            txtPassword.Focus();
        }
        catch (SqlException ex) { ShowDatabaseError(ex); }
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string? error = validator.ValidateLogin(username, txtPassword.Text);
        if (error != null) { MessageBox.Show(error); return; }
        try
        {
            if (!database.Authenticate(username, txtPassword.Text))
            { MessageBox.Show("Incorrect username or password."); return; }
            // Clear passwords and hide the login form while the second form is open.
            txtPassword.Clear(); txtNewPassword.Clear(); txtConfirmPassword.Clear();
            using var loggedIn = new LoggedInForm(username);
            Hide();
            loggedIn.ShowDialog();
            if (loggedIn.ExitRequested) Close();
            else { Show(); txtUsername.Clear(); txtUsername.Focus(); }
        }
        catch (SqlException ex) { ShowDatabaseError(ex); }
    }

    private void ShowDatabaseError(SqlException ex)
    {
        MessageBox.Show("Could not complete the database operation. Check SQL Server and run DatabaseSetup.sql.\n\n" + ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
