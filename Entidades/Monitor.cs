namespace WebApiMonitores.Entidades
{
    public class Monitor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set;}
        public float Precio { get; set;}
        public int ProvedorId { get; set; }
        //public Provedor Provedor { get; set; }
    }
}
