using SignLingo.Domain.Interfaces;

namespace SignLingo.API.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    
    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context, ITokenDomain tokenDomain, IUserDomain userDomain)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userEmail = tokenDomain.ValidateJwt(token);

        if (userEmail != null)
        {
            context.Items["User"] = await userDomain.GetByUserEmailAsync(userEmail);
        }
        
        await _next(context);
    }
}