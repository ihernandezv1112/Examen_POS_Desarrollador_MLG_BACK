using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using AutoMapper;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using MLG.POS.Backend.Services.Interfaces;
using MLG.POS.Backend.Services.Services;

namespace MLG.POS.Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        IConfiguration _config;
        IMapper _mapper;
        IServiceClients _serviceServiceClients;

        public ClientsController(IConfiguration configuration, IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
            _serviceServiceClients = new ServiceClients(_config, _mapper);
        }


        [HttpPost("AddClient", Name = "AddClient")]
        public IActionResult AddClient([FromBody]  ClientDto client)
        {
            ActionResult result = null;
            try
            {
                Client objClient = _serviceServiceClients.InsertClient(client);

                result = Ok(objClient);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpGet("GetClients", Name = "GetClients")]
        public IActionResult GetClients()
        {
            ActionResult result = null;
            try
            {
                IEnumerable<Client> Clients = _serviceServiceClients.GetClients();

                result = Ok(Clients);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpPatch("UpdateClient", Name = "UpdateClient")]
        public IActionResult UpdateClient([FromBody] ClientDto client)
        {
            ActionResult result = null;
            try
            {
                _serviceServiceClients.UpdateClient(client);

                result = Ok();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpDelete("DeleteClient", Name = "DeleteClient")]
        public IActionResult DeleteClient(int id)
        {
            ActionResult result = null;
            try
            {
                _serviceServiceClients.DeleteClient(id);

                result = Ok();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }


        [HttpPost("Login", Name = "Login")]
        public bool Login(Login login)
        {

            try
            {
               return _serviceServiceClients.Login(login);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
