using Microsoft.AspNetCore.Mvc;
using BlazorContactos.Server.Model;
using BlazorContactos.Shared.DTOs.Paises;
using Microsoft.EntityFrameworkCore;
using BlazorContactos.Client.Pages.Medios;
using BlazorContactos.Shared.DTOs.MediosContactos;

namespace BlazorContactos.Server.Controllers
{
    [ApiController, Route("api/Paiz")]
    public class PaisesController : ControllerBase
	{
        private readonly ApplicationDbContext context;

        public PaisesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaisDTO>>> GetContactos()
        {
            var paises = await context.Paises.ToListAsync();

            var paisesDto = new List<PaisDTO>();

            foreach (var pais in paises)
            {
                var paisDto = new PaisDTO();
                paisDto.Id = pais.Id;
                paisDto.Nombre = pais.Nombre;
                paisDto.Continente = pais.Continente;
                paisDto.Estado = pais.Estado;

                paisesDto.Add(paisDto);
            }
            return paisesDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PaisDTO>> GetPais(int id)
        {
            var pais = await context.Paises.FirstOrDefaultAsync(x => x.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            var paisDto = new PaisDTO();
            paisDto.Id = pais.Id;
            paisDto.Nombre = pais.Nombre;
            paisDto.Continente = pais.Continente;
            paisDto.Estado = pais.Estado;

            return paisDto;
        }


    }
}
