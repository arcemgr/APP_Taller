using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AppRaypal_Blazor.Helpers
{
    public interface IMostrarMensajes
    {
        Task MostrarMensajeError(string mensaje);
        Task MostrarMensajeExitoso(string mensaje);
        Task MostrarMensajeAlerta(string mensaje);
        Task MostrarMensajeinfo(string mensaje);
    }


    public class MostrarMensajes : IMostrarMensajes
    {
        private readonly IJSRuntime js;

        public MostrarMensajes(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task MostrarMensajeError(string mensaje)
        {
            await MostrarMensaje("Error", mensaje, "error");
        }

        public async Task MostrarMensajeinfo(string mensaje)
        {
            await MostrarMensaje("Alerta", mensaje, "info");
        }


        public async Task MostrarMensajeAlerta(string mensaje)
        {
            await MostrarMensaje("Alerta", mensaje, "warning");
        }

        public async Task MostrarMensajeExitoso(string mensaje)
        {
            await MostrarMensaje("Exitoso", mensaje, "success");
        }

        private async ValueTask MostrarMensaje(string titulo, string mensaje, string tipoMensaje)
        {
            await js.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipoMensaje);
        }
    }
}
