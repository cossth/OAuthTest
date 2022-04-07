using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuthTest.Controllers;

public class KV {
    public string name {get; set;} 
    public string value {get; set;} 

    public KV(string name , string value)
    {
        this.name = name;
        this.value = value;
    }
}

[ApiController]
[Route("")]
[Authorize]
public class ClaimsController : ControllerBase
{
    [HttpGet("")]
    public IEnumerable<KV> Get()
    {
        return HttpContext.User.Claims.Select((a) => {
            return new KV(a.Type, a.Value);
        });
    }
}
