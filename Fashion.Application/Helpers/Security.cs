using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Fashion.Domain.Constants;
using Fashion.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Fashion.Application.Helpers;

public static class Security
{
    public static string ComputeMd5Hash(string input)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

        using (MD5 md5 = MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2")); // Convert each byte to a two-character hex string
            }

            return sb.ToString();
        }
    }

    public static string GenerateJwtToken(User user, List<string> roles, string secretKey)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(ClaimTypesExtension.UserId, user.Id)
        };

        claims.AddRange(roles?.Select(r => new Claim(ClaimTypes.Role, r)) ?? []);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
