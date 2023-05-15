using System.ComponentModel.DataAnnotations;

namespace AppNotificactions.Data
{
    public class Datos
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Campo vacio")]
        public string Titulo { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Campo vacio")]
        public string Msg { get; set; }

        public DateTime FechaEnvio { get; set; }

        // Propiedad de navegación para el Topic al que pertenece este Dato
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

    }
}
