using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreAPI.Data;
using NetCoreAPI.Entities.Models;
using NetCoreAPI.Models;
using NetCoreAPI.Services;

namespace NetCoreAPI.Controllers
{
    [BasicAuthorize("my-example-realm.com")]
    [Route("api/v1/NetCoreAPI/[controller]")]

    public class InventarioSubGruposController : Controller
    {
        private Entities.DTOs.Configurations _config;

        public InventarioSubGruposController(Entities.DTOs.Configurations config)
        {
            _config = config;
        }

        private UnitOfWork _unitOfWork = new UnitOfWork(new DenariusAPIContext());


        [BasicAuthorize("my-example-realm.com")]
        [HttpGet]
        public IActionResult GetAllSubGrupos()
        {
            var invGrp1 = _unitOfWork.inv_grp1.Get();

            if (invGrp1 != null)
            {
                return Ok(invGrp1);
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
                var invGrp1 = _unitOfWork.inv_grp1.GetById(id);

                if (invGrp1 != null)
                {
                    return Ok(invGrp1);
                }
                else
                    return BadRequest();                
            }
            else
                return BadRequest();
        }
        [HttpPost]
        [HttpPut]
        public IActionResult UpdateCreateSubGrupo([FromBody]inv_grp1 invGrp1)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    if (invGrp1.key1 != 0)
                        _unitOfWork.inv_grp1.Update(invGrp1);
                    else
                        _unitOfWork.inv_grp1.Insert(invGrp1);

                    _unitOfWork.Save();

                    return Ok(invGrp1);
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
        public IActionResult DeleteInvGrp(int id)
        {
            if (id != 0)
            {
                _unitOfWork.inv_grp1.Delete(id);
                _unitOfWork.Save();

                return Ok("SubGrupo eliminado");
            }
            else
            {
                return BadRequest("Subgrupo con id invalido");
            }
        }
    }
}
