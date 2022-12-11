﻿using BlazorContactos.Server.Model;
using BlazorContactos.Shared.DTOs.Contactos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorContactos.Server.Controllers
{
    [ApiController, Route("api/contactos")]
    public class ContactosController : ControllerBase
    {
       
            private readonly ApplicationDbContext context;

            public ContactosController(ApplicationDbContext context)
            {
                this.context = context;
            }
        
        [HttpGet]
        public async Task<ActionResult<List<ContactoDTO>>> GetContactos()
        {
            var contactos = await context.Contactos.ToListAsync();

            var contactosDto = new List<ContactoDTO>();

            foreach(var contacto in contactos)
            {
                var contactoDto = new ContactoDTO();
                contactoDto.Id = contacto.Id;
                contactoDto.Nombre = contacto.Nombre;

                contactosDto.Add(contactoDto);
            }
            return contactosDto;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContactoDTO>> GetContacto(int id)
        {
            var contacto = await context.Contactos.FirstOrDefaultAsync(x => x.Id == id);

            context.Contactos.Include(m => m.Medios).ToList();

            if (contacto == null)
            {
                return NotFound();
            }

            var contactoDto = new ContactoDTO();
            contactoDto.Id = contacto.Id;
            contacto.Nombre = contacto.Nombre;

            return contactoDto;
        }

        [HttpPost]

        public async Task<ActionResult> Edit([FromBody] ContactoDTO contactoDto)
        {
            var contactoDb = await context.Contactos.FirstOrDefaultAsync(x =>x.Id == contactoDto.Id);

            if (contactoDb == null)
            {
                return NotFound();
            }

            contactoDb.Nombre = contactoDto.Nombre;

            context.Contactos.Update(contactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var contactoDb = await context.Contactos.FirstOrDefaultAsync(x => x.Id == id);

            if (contactoDb == null)
            {
                return NotFound();
            }

            context.Contactos.Remove(contactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
