using Backed_Guitarras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Guitarras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        //variable de contexto de la bd
        private readonly GuitarrasExamenContext _baseDatos;

        public CategoriasController(GuitarrasExamenContext baseDatos)
        {
            this._baseDatos = baseDatos;
        }

        //Método GET Lista guitarras
        [HttpGet]
        [Route("ListaCategorias")]
        public async Task<IActionResult> Lista()
        {
            var listaCategorias = await _baseDatos.Categoria
                                            .Select(g => new
                                            {
                                                Id = g.Id,
                                                Nombre = g.Nombre
                                            })
                                          .ToListAsync();

            return Ok(listaCategorias);
        }
    }
}
