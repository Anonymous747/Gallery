using Gallery.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Core.Services.Interfaces
{
    public interface ICityServise
    {
        Task<PagedResult<City>> GetCitiesAsync(string url = null);
    }
}
