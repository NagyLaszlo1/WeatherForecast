using Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    public interface IDarkSkyAgent
    {
        Task<ForecastResult> GetForecast(double lat, double lon, string langCode);
    }
}
