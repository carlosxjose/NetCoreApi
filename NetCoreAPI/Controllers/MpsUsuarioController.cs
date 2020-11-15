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
    [BasicAuthorize("my-example-realm.com")]
    [Route("api/v1/NetCoreAPI/[controller]")]
    public class MpsUsuarioController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new Data.DenariusAPIContext());

        [HttpGet("user")]
        public IActionResult GetByNombre(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                var u = _unitOfWork.mps_usuario.Get(x => x.identificacion == user.ToLower() && x.nivel > 0).FirstOrDefault();

                if (u != null)
                {
                    return Ok(u);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            if (id != 0)
            {
                var u = _unitOfWork.mps_usuario.Get(x => x.key1 == id && x.nivel > 0).FirstOrDefault();

                if (u != null)
                {
                    return Ok(u);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [HttpPut]
        public IActionResult UpdateCreateUsuario([FromBody] mps_usuarios u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (u.key1 != 0)
                        _unitOfWork.mps_usuario.Update(u);
                    else
                        _unitOfWork.mps_usuario.Insert(u);

                    _unitOfWork.Save();

                    return Ok(u);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
