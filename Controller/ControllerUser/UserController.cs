using DAL.Interfaces.Usuarios;
using MDL.Dto;
using MDL.Users;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers.Controller.ControllerUser
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        IUsers _users;
        public UserController(IUsers users)
        {
            _users = users;
        }

        [HttpGet("/Users/All")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _users.GetAll();
                if (result == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //crear un usuario 
        [HttpPost("user/create")]
        public async Task<ActionResult> CreateUser(CreateDto usuario)
        {
            var result = await _users.CreateUser(usuario);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("user/inicio_sesion")]
        public async Task<ActionResult> InicisarSesion(string data)
        {
            var response = await _users.SesionInit(data);
            try
            {
                if (response == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

    }
}
