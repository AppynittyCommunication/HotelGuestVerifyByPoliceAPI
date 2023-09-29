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

        //Select Controller
        Task<StatesList> GetStateListAsync();
        Task<List<CountryList>> GetCountryListAsync();

        Task<StatesList> GetCountryWiseStateListAsync(string countryId);
        Task<List<DepartmentTypeList>> GetDepartmentTypeListAsync();
        Task<List<DistrictList>> GetDistrictListAsync(int stateID);
        Task<List<CityList>> GetCityListAsync(int stateID, int distID);
        Task<List<PoliceStationList>> GetPoliceStationListAsync(int stateID, int distID, int cityID);
        Task<DepartmentLoginRes> CheckDeptLogin(DepartmentLoginBody obj);

        // Account Controller
        Task<IEnumerable<State>> GetTestAsync();
        Task<CommonAPIResponse> SaveHotelReg(HotelRegBody obj);
        Task<CommonAPIResponse> SavePoliceReg(PoliceRegBody obj);    
        Task<HotelLoginRes> CheckHotelLogin(HotelLoginBody obj);
        Task<CommonAPIResponse> ChangeHotelPassUsingOTP(SetHotelPassBody obj); 
        Task<CommonAPIResponse> ChangeDeptPassUsingOTP(SetDeptPassBody obj);
        Task<CommonAPIResponse> ResetHotelPassAsync(ResetHotelPassBody obj);
        Task<CommonAPIResponse> ForgetHotelPassStep2Async(PasswordRecoveryBody obj);
        Task<CommonAPIResponse> ForgetDeptPassStep2Async(DeptPasswordRecoveryBody obj);
        Task<CommonAPIResponse> CheckHotelRegExistAsync(string hotelRegNumber);
        Task<CheckHotelUsernameRes> ForgetHotePassStep1Async(string username,string mobileno);
        Task<CheckDeptUsernameRes> ForgetDeptPassStep1Async(string username, string mobileno);
        Task<CommonAPIResponse> CheckDepartUsernameExistAsync(string userId);
        Task<CommonAPIResponse> CheckHotelUsernameExistAsync(string userId); 
        Task<VerifyMobileNo> VerifyMobileNoAsync(string mobileno);
        Task<CommonAPIResponse> CheckAuthPinAsync(string authPin);
        Task<CommonAPIResponse> SaveAuthUserAsync(SaveAuthUserBody obj);

        //Hotel Controller
        Task<CommonAPIResponse> SaveHotelGuestReg(HotelGuestRegistration obj);
        Task<CommonAPIResponse> CheckOutGuestAsync(string roomBookingID);
        Task<HotelCheckInListResult> CheckGuestInOutStatusAsync(string hotelRegNo); 
   

        Task<List<RelationsList>> GetRelationAsync(); 
        Task<List<VisitPurposeList>> GetVisitPurposeAsync(); 
        Task<List<SelectIDTypeList>> GetSelectIDTypeAsync(); 


        //Department Controller
         Task<DeptDashboardRes> DepartmentDashboardAsync(string userID);
         Task<ShowHotelGuestDetailsRes> ShowHotelGuestDetailsAsync(string roomBookingID);
    }
}
