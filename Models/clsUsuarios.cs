namespace AppRaypal_Blazor.Models
{
    public class clsUsuarios
    {
        #region Propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public bool estado { get; set; }
        public clsEmpresa miEmpresa { get; set; }
        public clsPerfil miPerfil { get; set; }
        public string token { get; set; }
        public int tipoConsulta { get; set; }
        public clsAuditoria miAccion { get; set; }
        #endregion
    }
}
