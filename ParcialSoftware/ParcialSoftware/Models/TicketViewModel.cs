using ParcialSoftware.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ParcialSoftware.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombres y Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]

        public string? Name { get; set; }

        [Display(Name = "Documento de Identidad")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]

        public string? Document { get; set; }

        public DateTime? Date { get; set; }
        [JsonIgnore]

        public ICollection<TicketEntrance>? TicketEntrances { get; set; }

        [Display(Name = "Entradas")]
        public int? EntrancesNumber => TicketEntrances == null ? 0 : TicketEntrances.Count;
        public bool WasUsed { get; set; }
    }
}
