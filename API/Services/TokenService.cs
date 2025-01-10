using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Activities;
using Domain;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService
{
    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
        };
        //Create key for the token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DTcKvYAr3xFuHLYs8C3VZSSecBd5Tv56asXkAGKxHP8syekwvWkp4MvzCt5tx2nG"));
        //Our token has to be signed with the key and we chose a signature algo 
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        //Describe our token
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHanlder = new JwtSecurityTokenHandler();

        var token = tokenHanlder.CreateToken(tokenDescriptor);

        return tokenHanlder.WriteToken(token);
        
    }
}