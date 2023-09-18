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
        Task<CommonAPIResponse> SaveHotelReg(HotelRegBody obj);
        Task<CommonAPIResponse> SavePoliceReg(PoliceRegBody obj);
        Task<List<StatesList>> getStateListAsync();
        Task<List<DepartmentTypeList>> getDepartmentTypeListAsync();

        Task<List<DistrictList>> getDistrictListAsync(int stateID);
        Task<List<CityList>> getCityListAsync(int stateID,int distID);
        Task<List<PoliceStationList>> getPoliceStationListAsync(int stateID, int distID, int cityID);
        Task<DepartmentLoginRes> CheckDeptLogin(DepartmentLoginBody obj);
        Task<HotelLoginRes> CheckHotelLogin(HotelLoginBody obj);
        Task<CommonAPIResponse> ChangeHotelPassUsingOTP(SetHotelPassBody obj); 
        Task<CommonAPIResponse> ChangeDeptPassUsingOTP(SetDeptPassBody obj);
        Task<CommonAPIResponse> resetHotelPass(ResetHotelPassBody obj);
        Task<CommonAPIResponse> hotelPasswordRecoveryResponse(PasswordRecoveryBody obj);
        Task<CommonAPIResponse> deptPasswordRecoveryResponse(DeptPasswordRecoveryBody obj);
        Task<CommonAPIResponse> checkHotelRegExistAsync(string hotelRegNumber);
        Task<CheckHotelUsernameRes> checkHotelUsernameExistAsync(string username,string mobileno);
        Task<CheckDeptUsernameRes> checkDeptUsernameExistAsync(string username, string mobileno);
        Task<CommonAPIResponse> checkDepartUsernameExistAsync(string userId);
        Task<CommonAPIResponse> checkHotelUsernameExistAsync(string userId);
        Task<VerifyMobileNo> sendOTPToMobile(string mobileno);


        //Hotel Guest
        Task<CommonAPIResponse> saveHotelGuestReg(HotelGuestRegistration obj);

        Task<GuestInOutStatusResponse> checkGuestInOutStatusAsync(string hotelRegNo);
       
    }
}
