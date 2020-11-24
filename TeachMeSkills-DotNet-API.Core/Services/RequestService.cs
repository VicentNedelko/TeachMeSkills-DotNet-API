using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills_DotNet_API.Core.Interfaces;
using TeachMeSkills_DotNet_API.Core.Models;

namespace TeachMeSkills_DotNet_API.Core.Services
{
    public class RequestService : IRequestService
    {
        private const string url = "https://api.openbrewerydb.org/";

        public Task<IEnumerable<Brewery>> RequestByState(string s)
        {
        }

        public Task<IEnumerable<Brewery>> RequestByType()
        {
        }

        public async Task<IEnumerable<Brewery>> RequestDataByCity(string str)
        {
            var brewList = await url.AppendPathSegment("breweries")
                .SetQueryParam("by_city", str.ToLower())
                .GetJsonAsync<Brewery[]>();
            return brewList;
        }

        public Task<IEnumerable<Brewery>> RequestFullList()
        {
        }
    }
}
