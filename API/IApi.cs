using AppRaypal_Blazor.Models;
using System.Threading.Tasks;

namespace AppRaypal_Blazor.API
{
    public interface IApi
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Controller">Controlador del Api</param>
        /// <param name="Metodo">Metodo al que se llama</param>
        /// <param name="enviar">Objeto a Enviar, sin Serializar</param>
        /// <param name="NeedToken">Usa TOKEN si el controlador tiene Authorize</param>
        /// <param name="encriptado">Enviar Datos Encriptados</param>
        /// <returns></returns>
        Task<clsRespuesta> Post<T>(string Controller, string Metodo, T enviar, bool NeedToken = true, bool encriptado = false, string Token = null);
    }
}
