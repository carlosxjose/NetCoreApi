using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Entities.Models;
using NetCoreAPI.Services;

namespace NetCoreAPI.Controllers
{
    [Route("api/v1/NetCoreAPI/[controller]")]
    public class InvGrp1Controller : Controller
    {
        private NetCoreAPIContext _context = new NetCoreAPIContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new NetCoreAPIContext());

        [HttpGet]
        public IActionResult GetAllInvGrp1()
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
            InvGrp1 invGrp1 = _unitOfWork.inv_grp1.GetById(id);

            if (invGrp1 != null)
            {
                return Ok(invGrp1);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro");
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody]InvGrp1 invGrp1)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.inv_grp1.Update(invGrp1);
                    _unitOfWork.Save();

                    return Ok();
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
