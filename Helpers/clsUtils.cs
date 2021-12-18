using AppRaypal_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppRaypal_Blazor.Helpers
{
    public static class clsUtils
    {
        public static clsUsuarios miUsuarioLogueado { get; set; }

        public static JsonSerializerOptions OpcionesPorDefectoJSON =>
             new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public static string encodePassword(string password)
        {
            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(password);

            using (var sha1 = new SHA256Managed())
            {
                byte[] hash = sha1.ComputeHash(inputBytes);
                return Convert.ToBase64String(hash);
            } 
        }
    }
}

