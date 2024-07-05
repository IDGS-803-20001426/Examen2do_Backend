using Backed_Guitarras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Guitarras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarrasController : ControllerBase
    {
        //variable de contexto de la bd
        private readonly GuitarrasExamenContext _baseDatos;

        public GuitarrasController(GuitarrasExamenContext baseDatos)
        {
            this._baseDatos = baseDatos;
        }

        //Metodos de la API

        //Método GET Lista guitarras
        [HttpGet]
        [Route("ListaGuitarras")]
        public async Task<IActionResult> Lista()
        {
            var listaGuitarras = await _baseDatos.Guitarras
                                          .Include(g => g.IdCategoriaNavigation)
                                          .Select(g => new
                                          {
                                              Id = g.Id,
                                              Nombre = g.Nombre,
                                              Descripcion = g.Descripcion,
                                              Precio = g.Precio,
                                              Imagen = g.Imagen,
                                              IdCategoria = g.IdCategoria ?? 0,
                                              Categoria = g.IdCategoriaNavigation.Nombre
                                          })
                                          .ToListAsync();

            return Ok(listaGuitarras);
        }

        //Método GET Lista guitarras
        [HttpGet]
        [Route("GuitarrasPrincipales")]
        public async Task<IActionResult> ListaPrincipales()
        {
            var listaGuitarras = await _baseDatos.Guitarras
                                          .Include(g => g.IdCategoriaNavigation)
                                          .OrderBy(g => Guid.NewGuid())
                                          .Take(3)
                                          .Select(g => new
                                          {
                                              Id = g.Id,
                                              Nombre = g.Nombre,
                                              Descripcion = g.Descripcion,
                                              Precio = g.Precio,
                                              Imagen = g.Imagen,
                                              IdCategoria = g.IdCategoria ?? 0,
                                              Categoria = g.IdCategoriaNavigation.Nombre
                                          })
                                          .ToListAsync();

            return Ok(listaGuitarras);
        }
    }
}
