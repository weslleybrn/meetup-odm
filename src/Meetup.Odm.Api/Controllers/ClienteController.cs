using System;
using Meetup.Odm.Application;
using Microsoft.AspNetCore.Mvc;

namespace Meetup.Odm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clienteViewModel = new ClienteViewModel ();
            return Ok(clienteViewModel);
        }

        [HttpPost]
        public IActionResult Post(ClienteViewModel clienteViewModel)
        {
            try
            {
                _clienteService.CadastrarCliente(clienteViewModel);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return Ok();
        }
    }
}
