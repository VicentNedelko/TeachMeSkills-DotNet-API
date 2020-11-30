using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills_DotNet_API.Core.Interfaces;
using TeachMeSkills_DotNet_API.Core.Models;
using static TeachMeSkills_DotNet_API.Core.Interfaces.IRequestService;

namespace TeachMeSkills_DotNet_API.Core.Services
{
    public class RequestService : IRequestService
    {
        private const string url = "https://api.openbrewerydb.org/";

        public async Task<IEnumerable<Brewery>> RequestByState(string s)
        {
            return await url
                .AppendPathSegments("breweries")
                .SetQueryParams()
                .GetJsonAsync<Brewery[]>();
        }

        public async Task<IEnumerable<Brewery>> RequestByType()
        {
            return await url
                .AppendPathSegments("breweries")
                .SetQueryParams()
                .GetJsonAsync<Brewery[]>();
        }

        public async Task<IEnumerable<Brewery>> RequestDataByCity(string str)
        {
            var brewList = await url.AppendPathSegment("breweries")
                .SetQueryParam("by_city", str.ToLower())
                .GetJsonAsync<Brewery[]>();
            return brewList;
        }

        public async Task<IEnumerable<Brewery>> RequestFullList()
        {
            return await url
                .AppendPathSegments("breweries")
                .SetQueryParams()
                .GetJsonAsync<Brewery[]>();
        }
    }
}
