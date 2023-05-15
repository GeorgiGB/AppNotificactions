namespace AppNotificactions.Data
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propiedad de navegación para los Datos asociados a este Topic
        public ICollection<Datos> Datos { get; set; }
    }
}
