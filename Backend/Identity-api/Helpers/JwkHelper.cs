using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace Identity_api.Helpers;

public class JwkHelper
{
    public static List<SecurityKey> ConvertJwksToSecurityKeys(string jwksJson)
    {
        var securityKeys = new List<SecurityKey>();
        var jwkArray = JsonSerializer.Deserialize<JsonElement>(jwksJson);

        foreach (var jwk in jwkArray.EnumerateArray())
        {
            if (jwk.GetProperty("kty").GetString() == "RSA")
            {
                securityKeys.Add(ConvertRsaJwkToSecurityKey(jwk));
            }
            // Add support for other key types if needed (e.g., EC keys)
        }

        return securityKeys;
    }

    private static RsaSecurityKey ConvertRsaJwkToSecurityKey(JsonElement jwk)
    {
        string modulusBase64Url = jwk.GetProperty("n").GetString();
        string exponentBase64Url = jwk.GetProperty("e").GetString();

        byte[] modulus = Base64UrlDecode(modulusBase64Url);
        byte[] exponent = Base64UrlDecode(exponentBase64Url);

        var rsa = RSA.Create();
        rsa.ImportParameters(new RSAParameters
        {
            Modulus = modulus,
            Exponent = exponent
        });

        return new RsaSecurityKey(rsa)
        {
            KeyId = jwk.GetProperty("kid").GetString()
        };
    }

    private static byte[] Base64UrlDecode(string input)
    {
        string base64 = input.Replace('-', '+').Replace('_', '/'); // Convert to Base64 standard
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }
}