using App3.Helper;
using App3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Services
{
    public class ArticalsServices
    {
        public async Task<Articals> GetArticals(string source, string apikey)
        {

            var res = await HttpManager.GetAsync(App.BaseURL+ $"articles?source={source}&apikey={apikey}").ConfigureAwait(false);
            return res;
        }
    }
}
