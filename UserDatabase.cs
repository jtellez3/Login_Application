using Microsoft.Data.SqlClient;
using System.Data;
namespace Tellez_LoginApplication;
public class UserDatabase
{
    private const string ConnectionString = @"Server=JAYKA\SQLJAYKA;Database=LoginDatabase;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5";

    public bool CreateUser(string username, string password)
    {
        byte[] salt = PasswordSecurity.CreateSalt();
        byte[] hash = PasswordSecurity.Hash(password, salt, PasswordSecurity.Iterations);
        // Using automatically closes the connection when the method finishes
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        using var command = new SqlCommand("INSERT INTO dbo.Users (Username, PasswordHash, PasswordSalt, Iterations) VALUES (@username, @hash, @salt, @iterations)", connection);
        // Parameters keep user input separate from SQL commands
        command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
        command.Parameters.Add("@hash", SqlDbType.VarBinary, 32).Value = hash;
        command.Parameters.Add("@salt", SqlDbType.VarBinary, 16).Value = salt;
        command.Parameters.Add("@iterations", SqlDbType.Int).Value = PasswordSecurity.Iterations;
        try { command.ExecuteNonQuery(); return true; }
        // The UNIQUE rule in SQL prevents two accounts with the same username
        catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627) { return false; }
    }

    public bool Authenticate(string username, string password)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT PasswordHash, PasswordSalt, Iterations FROM dbo.Users WHERE Username = @username", connection);
        command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return false;
        // Read the saved security values and check the entered password.
        return PasswordSecurity.Verify(password, (byte[])reader[1], (byte[])reader[0], reader.GetInt32(2));
    }
}
