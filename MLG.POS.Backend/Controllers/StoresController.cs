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
    public class StoresController : ControllerBase
    {
        IConfiguration _config;
        IMapper _mapper;
        IServiceStores _serviceServiceStores;

        public StoresController(IConfiguration configuration, IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
            _serviceServiceStores = new ServiceStores(_config, _mapper);
        }



        [HttpPost("AddStore", Name = "AddStore")]
        public IActionResult AddStore([FromBody] StoreDto store)
        {
            ActionResult result = null;
            try
            {
                Store objStore = _serviceServiceStores.InsertStore(store);

                result = Ok(objStore);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpGet("GetStores", Name = "GetStores")]
        public IActionResult GetStores()
        {
            ActionResult result = null;
            try
            {
                IEnumerable<Store> Clients = _serviceServiceStores.GetStores();

                result = Ok(Clients);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpPatch("UpdateStore", Name = "UpdateStore")]
        public IActionResult UpdateStore([FromBody] StoreDto store)
        {
            ActionResult result = null;
            try
            {
                _serviceServiceStores.UpdateStore(store);

                result = Ok();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpDelete("DeleteStore", Name = "DeleteStore")]
        public IActionResult DeleteStore(int id)
        {
            ActionResult result = null;
            try
            {
                _serviceServiceStores.DeleteStore(id);

                result = Ok();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

    }
}
