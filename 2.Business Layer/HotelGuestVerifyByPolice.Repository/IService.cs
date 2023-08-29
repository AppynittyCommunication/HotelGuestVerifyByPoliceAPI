using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.Repository
{
    public interface IService
    {
        Task<IEnumerable<State>> GetTestAsync();
    }
}
