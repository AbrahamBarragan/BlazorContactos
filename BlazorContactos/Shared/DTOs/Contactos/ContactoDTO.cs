using System.ComponentModel.DataAnnotations;
using BlazorContactos.Shared.DTOs.MediosContactos;

namespace BlazorContactos.Shared.DTOs.Contactos
{
    public class ContactoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        public List<MedioContactoDTO> Medios { get; set; } = new List<MedioContactoDTO>();
    }
}
