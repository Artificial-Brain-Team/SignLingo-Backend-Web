using SignLingo.Domain.Interfaces;

namespace SignLingo.Domain;

public class EncryptDomain : IEncryptDomain
{
    public string Encrypt(string password)
    {        
        try
        {
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error in base64Encode{ex.Message}");
        }
    }
}