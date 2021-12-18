using AppRaypal_Blazor.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppRaypal_Blazor.API
{
    public class Servicio : IApi
    {
        private JsonSerializerOptions OpcionesPorDefectoJSON =>
             new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, IgnoreNullValues = true };
         
         private string BASEURL = "https://localhost:44377/api/";


        public async Task<clsRespuesta> Post<T>(string Controller, string Metodo, T enviar, bool NeedToken, bool encriptado = false, string Token = null)
        {
            try
            {


                using (var client = new HttpClient())
                {
                    string url = $"{BASEURL}{Controller}/{Metodo}";


                    if (NeedToken)
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");

                    string valorEnviar = JsonSerializer.Serialize(enviar, OpcionesPorDefectoJSON);



                    StringContent enviarContent = new StringContent(valorEnviar, Encoding.UTF8, "application/json");

                    HttpResponseMessage responseHttp = await client.PostAsync(url, enviarContent);

                    String responseString = await responseHttp.Content.ReadAsStringAsync();
                    clsRespuesta response = JsonSerializer.Deserialize<clsRespuesta>(responseString, OpcionesPorDefectoJSON);
                    return response;
                } 

            }
            catch (Exception ecx)
            {
                Console.WriteLine(ecx.ToString());
                return new clsRespuesta { codigoError = -404, mensaje = "Intente de Nuevo, por favor.", objeto = null, resultado = false };
            }
        }



    }
}
