using System.Security.Cryptography;
namespace Tellez_LoginApplication;
public static class PasswordSecurity
{
    // PBKDF2 makes guessing passwords more expensive. Each account gets its own random salt.
    public const int Iterations = 600000;
    public static byte[] CreateSalt() => RandomNumberGenerator.GetBytes(16);
    public static byte[] Hash(string password, byte[] salt, int iterations)
    {
        // A hash is one-way: I never save the original password in the database.
        return Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, 32);
    }
    public static bool Verify(string password, byte[] salt, byte[] savedHash, int iterations)
    {
        // Hash the entered password again and compare it to the saved hash.
        return CryptographicOperations.FixedTimeEquals(Hash(password, salt, iterations), savedHash);
    }
}
