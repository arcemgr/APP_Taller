using System;

namespace AppRaypal_Blazor.Models
{
    public class clsAuditoria
    {
        #region propiedades        
        public string id { get; set; }
        public DateTime fecha { get; set; }
        public string accion { get; set; }
        public string table { get; set; }
        public clsUsuarios miUsuario { get; set; }
        #endregion propiedades
    }
}
