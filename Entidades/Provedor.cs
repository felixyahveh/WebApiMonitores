namespace WebApiMonitores.Entidades
{
    public class Provedor
    {
        public int Id { get; set; }
        public string Compania { get; set;}
        public string RFC { get; set;}
        public string Telefono { get; set;}
        public string Direccion { get; set;}
        public List<Entidades.Monitor> Monitores { get; set;}
    }
}
