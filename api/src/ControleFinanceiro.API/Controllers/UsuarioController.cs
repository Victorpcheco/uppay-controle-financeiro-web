using ControleFinanceiro.Application.Users.Commands.LoginUsuario;
using ControleFinanceiro.Application.Users.Commands.RegistrarUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController(IMediator mediator) : ControllerBase
{
    [HttpPost("registrar")]
    public async Task<ActionResult> RegistrarUsuario([FromBody] RegistrarUsuarioCommand command)
    {
        var token = await mediator.Send(command);
        return Ok(token);
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginUsuario([FromBody] LoginUsuarioCommand command)
    {
        var token = await mediator.Send(command);
        return Ok(token);
    }
}