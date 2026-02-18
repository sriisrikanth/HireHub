using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HireHub.Shared.Authentication.Interface;
using HireHub.Shared.Authentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace HireHub.Shared.Authentication.Service;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public string GenerateToken(string userId, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer[0],
            audience: _jwtSettings.Audiens[0],
            claims: [
                    new (ClaimTypes.NameIdentifier, userId),
                    new (ClaimTypes.Name, userId),
                    new (ClaimTypes.Role, role)
             ],
            expires : DateTime.UtcNow.AddHours(_jwtSettings.ExpireInHours),
            signingCredentials : new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        );

        return tokenHandler.WriteToken(token);
    }

    public List<Claim>? ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = _jwtSettings.Issuer is not null,
                ValidIssuers = _jwtSettings.Issuer,
                ValidateAudience = _jwtSettings.Audiens is not null,
                ValidAudiences = _jwtSettings.Audiens,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return jwtToken.Claims.ToList();
        }
        catch
        {
            return null; // token invalid
        }
    }
}