namespace AppRaypal_Blazor.Models
{
    public class clsEmpresa
    {
        #region Propiedades
        public int id { get; set; }
        public string telefono { get; set; }
        public string fax { get; set; }
        public string nombrecomercial { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string cedula { get; set; }
        public bool estado { get; set; }
        public string datosHacienda { get; set; }
        public string datosJson { get; set; }
        public bool isTradicional { get; set; }
        public int tipoConsulta { get; set; }
        public clsAuditoria miAccion { get; set; }

        #endregion
    }
}
