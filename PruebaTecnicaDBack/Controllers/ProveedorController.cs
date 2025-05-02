using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaDBack.Models;
using PruebaTecnicaDBack.Services;

namespace PruebaTecnicaDBack.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorService _proveedorService;
        public ProveedorController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public ActionResult<List<ProveedorModel>> GetProveedor()
        {   
            return Ok(_proveedorService.Get());
        }

        [HttpPost]
        public ActionResult<ProveedorModel> CreateProveedor(ProveedorModel proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest("Proveedor no puede ser nulo");
            }
           _proveedorService.Create(proveedor);
            return Ok(proveedor);
        }

        [HttpPatch]
        public ActionResult UpdateProveedor(ProveedorModel proveedor)
        {

            if (proveedor == null)
            {
                return BadRequest("Proveedor no puede ser nulo");
            }
            _proveedorService.Update(proveedor.Id, proveedor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProveedor(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id no puede ser nulo");
            }
            _proveedorService.Delete(id);
            return Ok();
        }

    }
}
