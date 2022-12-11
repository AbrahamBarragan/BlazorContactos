using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Server.Model.Entities
{
    public class MediosContacto
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public string Telefono { get; set; }
        
        public string Celular { get; set; }

        
        public int ContactoId { get; set; }
        public Contacto Contacto { get;set; }
    }
}
