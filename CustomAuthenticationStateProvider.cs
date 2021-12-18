using AppRaypal_Blazor.Helpers;
using AppRaypal_Blazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppRaypal_Blazor
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        enum StorageType
        {
            token,
            expiry
        }

        string TokenGeneral = "";
        private readonly IJSRuntime jSRuntime;
        public CustomAuthenticationStateProvider(IJSRuntime runtime)
        {
            jSRuntime = runtime;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await GetTokenAsync();
            var identity = string.IsNullOrEmpty(token) ? new ClaimsIdentity() : new ClaimsIdentity(ParseClaimsFromJWT(token), "JWT");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        public async Task SetTokenAsync(string token, string expiry)
        {
            if (token == null)
            {
                var a = await jSRuntime.InvokeAsync<object>("RemoveData", StorageType.token);
                var b = await jSRuntime.InvokeAsync<object>("RemoveData", StorageType.expiry);
            }
            else
            {
                TokenGeneral = token;
                var x = await jSRuntime.InvokeAsync<object>("SaveData", StorageType.token, token);
                var y = await jSRuntime.InvokeAsync<object>("SaveData", StorageType.expiry, expiry);
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task<string> GetTokenAsync()
        {
            string valor = await jSRuntime.InvokeAsync<string>("GetData", StorageType.expiry);
             

            if (valor != null)
            {
                if (DateTime.Parse(valor.ToString()) > DateTime.Now)
                {
                    string valor2 = await jSRuntime.InvokeAsync<string>("GetData", StorageType.token); 
                    return valor2;
                }
                else
                {
                    await SetTokenAsync(null, null);
                }
            }
            return null;
        }


        public async Task<clsUsuarios> getEmployee()
        {
            string valor = await jSRuntime.InvokeAsync<string>("GetData", StorageType.expiry);
             
            if (valor != null)
            {
                if (DateTime.Parse(valor.ToString()) > DateTime.Now)
                {
                    string valor2 = await jSRuntime.InvokeAsync<string>("GetData", StorageType.token); 

                    return JsonSerializer.Deserialize<clsUsuarios>(valor2, clsUtils.OpcionesPorDefectoJSON);
                }
                else
                {
                    await SetTokenAsync(null, null);
                }
            }
            return null;
        }


        private IEnumerable<Claim> ParseClaimsFromJWT(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64Withoutpadding(payload);
            var keyValuesPairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            List<Claim> result = new List<Claim>();
            Claim aux;
            foreach (var data in keyValuesPairs)
            {

                aux = new Claim(data.Key, data.Value.ToString());


                result.Add(aux);
            }
            return result;//keyValuesPairs.Select(kv => new Claim(kv.Key,kv.Value.ToString()));
        }
        private byte[] ParseBase64Withoutpadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
