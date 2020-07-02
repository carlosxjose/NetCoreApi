using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreAPI.Entities.Models;
using NetCoreAPI.Models;
using NetCoreAPI.Services;
using Newtonsoft.Json;

namespace NetCoreAPI.Controllers
{
    [Route("api/v1/NetCoreAPI/[controller]")]
    public class InventarioMaestroController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new NetCoreAPIContext());        

        [HttpGet]
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
                var maestro = _unitOfWork.inv_master.Get(x => x.Key1 == id);

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

        [HttpPut]
        public IActionResult UpdateCreateMaestro([FromBody]InvMaster m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (m.Key1 != 0)
                        _unitOfWork.inv_master.Update(m);
                    else
                        _unitOfWork.inv_master.Insert(m);

                    _unitOfWork.Save();

                    return Ok(m);
                }
                else
                    return BadRequest();
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

