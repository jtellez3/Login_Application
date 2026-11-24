namespace Tellez_LoginApplication;
public partial class LoggedInForm : Form
{
    public bool ExitRequested { get; private set; }
    public LoggedInForm() { InitializeComponent(); }
    public LoggedInForm(string username) : this()
    {
        lblWelcome.Text = "Welcome, " + username + "!\nYou have successfully logged in.";
    }
    // Closing this form returns the user to the login screen.
    private void btnLogout_Click(object? sender, EventArgs e) { Close(); }
    // Tell the first form to close the entire application.
    private void btnExit_Click(object? sender, EventArgs e) { ExitRequested = true; Close(); }
}
