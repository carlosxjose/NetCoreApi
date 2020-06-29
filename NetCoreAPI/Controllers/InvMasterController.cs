using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Entities.DTOs;
using NetCoreAPI.Entities.Models;
using NetCoreAPI.Services;
using Newtonsoft.Json;

namespace NetCoreAPI.Controllers
{
    public class InvMasterController : Controller
    {
        [Route("api/v1/NetCoreAPI/[controller]")]
        public class InvGrp1Controller : Controller
        {
            private UnitOfWork _unitOfWork = new UnitOfWork(new NetCoreAPIContext());

            [HttpGet]
            public IActionResult GetAllInvMaster()
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

            [HttpGet("idInvMaster")]
            public IActionResult GetById(int id)
            {
                if (id != 0)
                {
                    var maestro = _unitOfWork.inv_master.Get(x => x.Key1 == id);

                    if (maestro != null)
                    {
                        var contactos = _unitOfWork.inv_master.Get(x => x.Key1 == id);
                        var result = CreateMappedObject(contactos, id);
                        var serializedList = JsonConvert.SerializeObject(result, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        });
                        return Ok(serializedList);
                    }
                    else
                        return BadRequest();
                }
                else
                    return BadRequest();
            }

            private InvMasteList CreateMappedObject(IEnumerable<InvMaster> invMasters, int id)
            {
                InvMasteList ListainvMaster = new InvMasteList();

                foreach(var item in invMasters)
                {
                    InvMaster m = _unitOfWork.inv_master.GetById(item.Key1);
                    ListainvMaster.invMastersAgregados.Add(m);
                }
                ListainvMaster.key1 = id;

                return ListainvMaster;
            }

            [HttpPost]//Pendiente actulizar
            public IActionResult CreateInv_master([FromBody] InvMaster m)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.inv_master.Insert(m);
                        _unitOfWork.Save();

                        return Created("NetCoreAPI/CreateInv_master", m);
                    }
                }
                catch(DataException ex)
                {
                    return BadRequest(ex);
                }
                return BadRequest(m);
            }
            [HttpPut("{id}")]
            public IActionResult UpdateInvMaster([FromBody] int id,InvMaster invMaster)
            {
                InvMaster busquedaMaestro = _unitOfWork.inv_master.GetById(id);

                if (busquedaMaestro != null)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            _unitOfWork.inv_master.Update(invMaster);
                            _unitOfWork.Save();

                            return Ok();
                        }
                    }
                    catch (DataException ex)
                    {
                        return BadRequest(ex);
                    }
                }
                else
                {
                    return NotFound("El articulo que intenta actualizar no existe");
                }
                return BadRequest();
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
}
