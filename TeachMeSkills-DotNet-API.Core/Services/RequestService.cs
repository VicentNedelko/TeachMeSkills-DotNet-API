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

        public Task<IEnumerable<Brewery>> RequestByState(string s)
        {
        }

        public async Task<IEnumerable<Brewery>> RequestByType()
        {
            Types type = Types.bar;
            Console.WriteLine("Enter type : ");
            Console.WriteLine("micro - m" + "; " +
                                "nano - n" + "; " +
                                "regional - r" + "; " +
                                "brewpub - b" + "; " +
                                "large - l" + "; " +
                                "planning - p" + "; " +
                                "bar - a" + "; " +
                                "contract - c" + "; " +
                                "proprietor - h" + "; " +
                                "closed - x");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.M:
                    type = Types.micro;
                    break;
                case ConsoleKey.N:
                    type = Types.nano;
                    break;
                case ConsoleKey.R:
                    type = Types.regional;
                    break;
                case ConsoleKey.B:
                    type = Types.brewpub;
                    break;
                case ConsoleKey.L:
                    type = Types.large;
                    break;
                case ConsoleKey.P:
                    type = Types.planning;
                    break;
                case ConsoleKey.A:
                    type = Types.bar;
                    break;
                case ConsoleKey.C:
                    type = Types.contract;
                    break;
                case ConsoleKey.H:
                    type = Types.proprietor;
                    break;
                case ConsoleKey.X:
                    type = Types.closed;
                    break;
            }
            Console.WriteLine(type.ToString());
            Console.ReadKey();
            return await url.AppendPathSegments("breweries")
                .SetQueryParam("by_type", type.ToString())
                .GetJsonAsync<Brewery[]>();
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
