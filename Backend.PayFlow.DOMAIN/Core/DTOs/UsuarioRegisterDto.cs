namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class UsuarioRegisterDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
