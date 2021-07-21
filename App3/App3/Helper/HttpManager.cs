using App3.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.Helper
{
    public class HttpManager
    {
        static App app = Application.Current as App;
       
        public static async Task<Articals> GetAsync(string requestUrl)
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    HttpClientHandler handler = new HttpClientHandler();
                    handler.UseDefaultCredentials = true;

                    HttpClient client = new HttpClient(handler);

                    HttpResponseMessage response = new HttpResponseMessage();
                    try
                    {
                        response = await client.GetAsync(requestUrl).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    if (response != null)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var responseJson = await response.Content.ReadAsStringAsync();
                            var JsonObject = JsonConvert.DeserializeObject<Articals>(responseJson);
                            return JsonObject;
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("", "Something went wrong", "Ok");
                            return null;
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Something went wrong", "Ok");

                        return null;
                    }
                    
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("", "Please check your internet connection and try again later", "Ok");
                    return null;
                }

            }
            catch (System.Exception exp)
            {
                await Application.Current.MainPage.DisplayAlert("", "Something went wrong", "Ok");
                return null;
            }

        }
    }
}
