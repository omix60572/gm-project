using GM.Services.Interfaces;
using GM.Services.Settings;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GM.Services;

public class TokenService : ITokensService
{
    private readonly JwtSettings settings;
    private readonly Logger logger;

    public TokenService(JwtSettings settings)
    {
        this.settings = settings;
        this.logger = LogManager.GetCurrentClassLogger();
    }

    public string CreateToken(string applicationName)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, applicationName),            // Subject
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())   // (JWT ID) claim provides a unique identifier for the JWT
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(this.settings.ExpireHours),
            signingCredentials: credentials,
            audience: this.settings.ValidAudience,
            issuer: this.settings.ValidIssuer
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        return tokenString;
    }

    public uint GetExpireHours() =>
        this.settings.ExpireHours;

    public bool ValidateToken(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.settings.Key)),
                ValidIssuer = this.settings.ValidIssuer,
                ValidAudience = this.settings.ValidAudience,
                ClockSkew = TimeSpan.Zero // No tolerance
            };

            // Throws if validation fails
            var _ = handler.ValidateToken(token, validationParameters, out var _);
            return true;
        }
        catch (Exception ex)
        {
            this.logger.Error(ex, "Token validation failed");
        }

        return false;
    }

    public DateTime GetExpireDateTime(string tokenString)
    {
        var token = new JwtSecurityToken(tokenString);
        return token.ValidTo;
    }
}
