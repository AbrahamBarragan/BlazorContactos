using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContactos.Shared.DTOs.Paises
{
	public class PaisDTO
	{
        public int Id { get; set; }

        [Required (ErrorMessage ="El campo {0} es requerido")]
        public string Nombre { get; set; }
        public string Continente { get; set; }
        public string Estado { get; set; }
    }
}
