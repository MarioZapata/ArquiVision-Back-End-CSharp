using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public interface ITokenValidationService
{
    TokenValidationResult ValidateToken(string token);
}

public class TokenValidationService : ITokenValidationService
{
    private readonly IConfiguration _configuration;

    public TokenValidationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenValidationResult ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return TokenValidationResult.Invalid("Token is required");
        }

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return TokenValidationResult.Valid(jwtToken);
        }
        catch (Exception ex)
        {
            return TokenValidationResult.Invalid(ex.Message);
        }
    }
}

public class TokenValidationResult
{
    public bool IsValid { get; private set; }
    public string Message { get; private set; }
    public JwtSecurityToken ValidatedToken { get; private set; }

    private TokenValidationResult(bool isValid, string message, JwtSecurityToken validatedToken)
    {
        IsValid = isValid;
        Message = message;
        ValidatedToken = validatedToken;
    }

    public static TokenValidationResult Valid(JwtSecurityToken token)
    {
        return new TokenValidationResult(true, string.Empty, token);
    }

    public static TokenValidationResult Invalid(string message)
    {
        return new TokenValidationResult(false, message, null);
    }
}
