using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.ILogic;
using Application.Logic;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthLogic _authLogic;
    private readonly IConfiguration _config;


    public AuthController(IAuthLogic authLogic, IConfiguration config)
    {
        _authLogic = authLogic;
        _config = config;
    }

    [HttpPost]
    public async Task<ActionResult<User>> RegisterUserAsync(UserCreationDto dto)
    {
        try
        {
            User user = await _authLogic.RegisterUserAsync(dto);

            return Created($"/users/{user.Id}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    private List<Claim> GenerateClaims(User user)
    {
        object config;
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("Username", user.Username),
            new Claim("Email", user.Email),
            new Claim("Id", user.Id.ToString()),
        };
        return claims.ToList();
    }

    private string GenerateJwt(User user)
    {
        List<Claim> claims = GenerateClaims(user);

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        JwtHeader header = new JwtHeader(signIn);

        JwtPayload payload = new JwtPayload(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            null,
            DateTime.UtcNow.AddMinutes(60));

        JwtSecurityToken token = new JwtSecurityToken(header, payload);

        string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return serializedToken;
    }

    [HttpPost, Route("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        try
        {
            User user = await _authLogic.ValidateUserAsync(userLoginDto.Username, userLoginDto.Password);
            string token = GenerateJwt(user);

            return Ok(token);
        }
        catch (Exception e)
        {
            //TODO: More specific bad request messages
            return BadRequest(e.Message);
        }
    }
}