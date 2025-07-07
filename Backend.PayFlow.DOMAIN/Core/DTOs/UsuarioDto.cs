namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        // Datos personales
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        // Datos de cuenta
        public string Usuario { get; set; } = string.Empty;
        public string? Contrasena { get; set; }  // Solo se usa en registro
        public string? NuevaContrasena { get; set; }  // Solo para cambio de contraseña

        // Metadatos
        public DateTime? FechaRegistro { get; set; }
        public string? Estado { get; set; }
    }
}
