namespace Tellez_LoginApplication;
partial class LoggedInForm
{
    // Controls created for the Visual Studio form designer.
    private Label lblWelcome = null!;
    private Button btnLogout = null!;
    private Button btnExit = null!;
    private void InitializeComponent()
    {
        lblWelcome = new Label();
        btnLogout = new Button();
        btnExit = new Button();
        SuspendLayout();
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Location = new Point(20, 25);
        lblWelcome.Size = new Size(420, 100);
        lblWelcome.Text = "You have successfully logged in.";
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
        Controls.Add(lblWelcome);
        btnLogout.Name = "btnLogout";
        btnLogout.Location = new Point(55, 145);
        btnLogout.Size = new Size(160, 40);
        btnLogout.Text = "Logout";
        btnLogout.Click += btnLogout_Click;
        Controls.Add(btnLogout);
        btnExit.Name = "btnExit";
        btnExit.Location = new Point(245, 145);
        btnExit.Size = new Size(160, 40);
        btnExit.Text = "Exit";
        btnExit.Click += btnExit_Click;
        Controls.Add(btnExit);
        ClientSize = new Size(460, 210);
        AutoScaleMode = AutoScaleMode.Font;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Text = "Logged In";
        ResumeLayout(false);
    }
}
