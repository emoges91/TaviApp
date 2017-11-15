using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Services
{
    public static class HttpController
    {

        public static async Task<List<string>> GetAsync()
        {
            var client = new HttpClient();
            var Items = new List<string>();

            var RestUrl = "http://developer.xamarin.com:8081/api/todoitems";
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<string>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

        public static async Task PutAsync(string item, bool isNewItem = false)
        {
            var client = new HttpClient();
            var RestUrl = "http://developer.xamarin.com:8081/api/todoitems";
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Item successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

        }

        public static async Task DeleteAsync(string id)
        {
            var client = new HttpClient();
            var RestUrl = "http://developer.xamarin.com:8081/api/todoitems/{0}";
            var uri = new Uri(string.Format(RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Item successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        public static string createUrlEnconde(string myUri)
        {
            Debug.WriteLine("on httpcontroller uri:" + myUri);
            return "e";
        }


        private static string formatUrlString(string stringUri)
        {

            Debug.WriteLine("formating stringUri:" + stringUri);
            return stringUri;
        }

    }
}
