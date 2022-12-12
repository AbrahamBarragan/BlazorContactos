using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Server.Model.Entities
{
	public class Pais
	{
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; }
		public string Continente { get; set; }
		public string Estado { get; set; }
		public List<MediosContacto> mediosContactos { get; set; }
    }
}
