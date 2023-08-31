using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Interface
{
    public interface IRepository
    {
        Task<IEnumerable<State>> GetTestAsync();
        Task<HotelRegRes> SaveHotelReg(HotelRegBody obj);
        Task<HotelRegRes> SavePoliceReg(PoliceRegBody obj);
        Task<List<StatesList>> getStateListAsync();
        Task<List<DistrictList>> getDistrictListAsync(int stateID);
        Task<List<CityList>> getCityListAsync(int stateID,int distID);
        Task<List<PoliceStationList>> getPoliceStationListAsync(int stateID, int distID, int cityID);
    }
}
