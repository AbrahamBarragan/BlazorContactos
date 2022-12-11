using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContactos.Shared.DTOs.MediosContactos
{
    internal class MedioContactoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Email { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Celular { get; set; }
    }
}
