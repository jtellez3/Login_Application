namespace Tellez_LoginApplication;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        // Start the Windows Forms application with the login screen.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
