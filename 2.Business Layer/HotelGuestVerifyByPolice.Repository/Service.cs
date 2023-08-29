using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using HotelGuestVerifyByPolice.DataContext.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.Repository
{
    public class Service : IService
    {
        private readonly IRepository _Repository;

        public Service(IRepository repository)
        {
            _Repository = repository;
        }

        public async Task<IEnumerable<State>> GetTestAsync()
        {
            return await _Repository.GetTestAsync();
        }
    }
}
