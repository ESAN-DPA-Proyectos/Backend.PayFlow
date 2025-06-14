namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DNI { get; set; }
        public string? Correo { get; set; }
        public string? Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Estado { get; set; }
    }
}
