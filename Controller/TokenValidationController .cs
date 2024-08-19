using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TokenValidationController : ControllerBase
{
    private readonly ITokenValidationService _tokenValidationService;

    public TokenValidationController(ITokenValidationService tokenValidationService)
    {
        _tokenValidationService = tokenValidationService;
    }

    [HttpPost("validate")]
    [AllowAnonymous]
    public IActionResult ValidateToken([FromBody] TokenRequest tokenRequest)
    {
        if (tokenRequest == null || string.IsNullOrWhiteSpace(tokenRequest.Token))
        {
            return BadRequest("Token is required");
        }

        var token = tokenRequest.Token.Trim();
        var validationResult = _tokenValidationService.ValidateToken(token);

        if (validationResult.IsValid)
        {
            return Ok(new { IsValid = true, Token = validationResult.ValidatedToken });
        }
        else
        {
            return BadRequest(new { IsValid = false, Message = validationResult.Message });
        }
    }
}

public class TokenRequest
{
    public string Token { get; set; }
}
