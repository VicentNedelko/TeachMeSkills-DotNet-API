using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills_DotNet_API.Core.Models;

namespace TeachMeSkills_DotNet_API.Core.Interfaces
{
    public interface IRequestService
    {
        public enum Types
        {
            micro = 1,
            nano,
            regional,
            brewpub,
            large,
            planning,
            bar,
            contract,
            proprietor,
            closed,
        }
        public Task<IEnumerable<Brewery>> RequestDataByCity(string s);
        public Task<IEnumerable<Brewery>> RequestFullList();
        public Task<IEnumerable<Brewery>> RequestByState(string s);
        public Task<IEnumerable<Brewery>> RequestByType();
    }
}
