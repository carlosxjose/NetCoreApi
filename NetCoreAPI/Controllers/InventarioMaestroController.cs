using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreAPI.Entities.Models;
using NetCoreAPI.Models;
using NetCoreAPI.Services;
using Newtonsoft.Json;

namespace NetCoreAPI.Controllers
{
    [BasicAuthorize("my-example-realm.com")]
    [Route("api/v1/NetCoreAPI/[controller]")]
    public class InventarioMaestroController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new Data.DenariusAPIContext());        

        [HttpGet]
        //[Authorize]
        public IActionResult GetAllMaestro()
        {
            var invMaster = _unitOfWork.inv_master.Get();

            if (invMaster != null)
            {
                return Ok(invMaster);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            if (id != 0)
            {
                var maestro = _unitOfWork.inv_master.Get(x => x.key1 == id);

                if (maestro != null)
                {
                    return Ok(maestro);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }
        [HttpPost]
        [HttpPut]
        public IActionResult UpdateCreateMaestro([FromBody]inv_master m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (m.key1 != 0)
                        _unitOfWork.inv_master.Update(m);
                    else
                        _unitOfWork.inv_master.Insert(m);

                    _unitOfWork.Save();

                    return Ok(m);
                }
                else
                return BadRequest(ModelState);
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteInvMaster(int id)
        {
            if (id != 0)
            {
                _unitOfWork.inv_master.Delete(id);
                _unitOfWork.Save();

                return Ok("Articulo eliminado");
            }
            else
            {
                return BadRequest("Articulo con id invalido");
            }
        }
    }
}

