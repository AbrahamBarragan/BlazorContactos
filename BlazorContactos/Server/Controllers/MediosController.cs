using BlazorContactos.Server.Model;
using BlazorContactos.Server.Model.Entities;
using BlazorContactos.Shared.DTOs.MediosContactos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorContactos.Server.Controllers
{
    [ApiController, Route("api/medioz")]
    public class MediosController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public MediosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedioContactoDTO>>> GetContactos()
        {
            var medios = await context.Medios.ToListAsync();

            var mediosDto = new List<MedioContactoDTO>();

            foreach (var medio in medios)
            {
                var medioDto = new MedioContactoDTO();
                medioDto.Id = medio.Id;
                medioDto.Email = medio.Email;
                medioDto.Telefono = medio.Telefono;
                medioDto.Celular = medio.Celular;

                mediosDto.Add(medioDto);
            }
            return mediosDto;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MedioContactoDTO>> GetContacto(int id)
        {
            var medio = await context.Medios.FirstOrDefaultAsync(x => x.Id == id);


            if (medio == null)
            {
                return NotFound();
            }

            var medioDto = new MedioContactoDTO();
            medioDto.Id = medio.Id;
            medioDto.Email = medio.Email;
            medioDto.Telefono = medio.Telefono;
            medioDto.Celular = medio.Celular;

            return medioDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MedioContactoDTO  medioDto)
        {
            var medio = new MediosContacto();
            medio.Id = medioDto.Id;
            medio.Email = medioDto.Email;
            medio.Telefono = medioDto.Telefono;
            medio.Celular = medioDto.Celular;

            context.Medios.Add(medio);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]

            public async Task<ActionResult> Edit([FromBody] MedioContactoDTO medioDto)
            {
                var medioDb = await context.Medios.FirstOrDefaultAsync(x => x.Id == medioDto.Id);

                if (medioDb == null)
                {
                    return NotFound();
                }

                medioDb.Email = medioDto.Email;
                medioDb.Telefono = medioDto.Celular;
                medioDb.Celular = medioDto.Celular;

                context.Medios.Update(medioDb);
                await context.SaveChangesAsync();
                return Ok();
            }

            [HttpDelete("{id:int}")]

            public async Task<ActionResult> Delete(int id)
            {
                var medioDb = await context.Contactos.FirstOrDefaultAsync(x => x.Id == id);

                if (medioDb == null)
                {
                    return NotFound();
                }

                context.Contactos.Remove(medioDb);
                await context.SaveChangesAsync();
                return Ok();
            }
    }
}
