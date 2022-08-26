namespace Financiera.Dominio
{
    public class Cliente
    {
        // GET => Leer
        // SET => Escribir
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public bool Estado { get; set; }

        public string NombreCompleto
        {
            get
            {
                return this.Nombres + " " + this.Apellidos;
            }
        }
    }
}
