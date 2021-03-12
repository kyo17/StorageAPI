using System;
using System.Threading.Tasks;
using AzureStorage.Database;
using AzureStorage.Interface;
using AzureStorage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureStorage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogoController : Controller
    {
        private readonly Context db;
        private IAzure azure;
        private readonly string contenedor = "catalogo";
        private string ext = ".png";

        public CatalogoController(Context context, IAzure _azure)
        {
            db = context;
            azure = _azure;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await db.Catalogos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOne(string id)
        {

            return Ok(await db.Catalogos.FirstOrDefaultAsync(x => x.id == id));
        }

        [HttpPost]
        public async Task<IActionResult> insert([FromBody] Catalogo catalogo)
        {
            if (catalogo == null)
            {
                return BadRequest();
            }

            if (!string.IsNullOrEmpty(catalogo.foto))
            {
                var foto = Convert.FromBase64String(catalogo.foto);
                catalogo.foto = await azure.savePhoto(contenedor,foto, ext);
            }

            db.Catalogos.Add(catalogo);
            await db.SaveChangesAsync();
            
            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> modify([FromBody] Catalogo catalogo, string id)
        {

            return Created("Upd", true);
        }
    }
}
