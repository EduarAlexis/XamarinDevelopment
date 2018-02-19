using System;
using System.Net.Http;
using Android.Util;
using ModernHttpClient;
using System.Threading.Tasks;

namespace Video8_RestService.REST
{
    public static class Client
    {
        public async static Task<T> GetRequest<T>(this string url)
        {
            try
            {
                //HttpClient client = new HttpClient(); //Genera error. Hay que llamarlo HttpClient(new NativeMessageHandler()), e importar el niuget ModernHttpClient
                HttpClient client = new HttpClient(new NativeMessageHandler());
                var uri = new Uri(string.Format(url, string.Empty));
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Log.Info("Eduar Rest", "servicio");
                    System.Diagnostics.Debug.WriteLine(json);
                    //Newtonsoft, permite convertir un dato en JSon a un tipo Generico, Newtonsoft hay que agregarlo como nuget.
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    return default(T);
                }
            }
            catch
            {
                //Log.Info("Error GetRequest", e.ToString());
                return default(T);
            }
        }
    }
}
