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
        Task<CountryList> GetCountryListAsync();

        Task<StatesList> GetCountryWiseStateListAsync(string countryId);
        Task<DepartmentTypeList> GetDepartmentTypeListAsync();
        Task<DistrictList> GetDistrictListAsync(int stateID);
        Task<CityList> GetCityListAsync(int stateID, int distID);
        Task<PoliceStationList> GetPoliceStationListAsync(int stateID, int distID, int cityID);

        Task<HotelList> GetHotelListAsync(string psId);
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
        Task<CommonAPIResponse> CheckUsernameExistAsync(string userId); 
        Task<VerifyMobileNo> VerifyMobileNoAsync(string mobileno);
        Task<CommonAPIResponse> CheckAuthPinAsync(string authPin);
        Task<CommonAPIResponse> SaveAuthUserAsync(SaveAuthUserBody obj);

        //Hotel Controller
        Task<CommonAPIResponse> SaveHotelGuestReg(HotelGuestRegistration obj);
        Task<CommonAPIResponse> CheckOutGuestAsync(string roomBookingID);
        Task<HotelCheckInListResult> CheckGuestInOutStatusAsync(string hotelRegNo); 
   

        Task<RelationsList> GetRelationAsync(); 
        Task<VisitPurposeList> GetVisitPurposeAsync(); 
        Task<SelectIDTypeList> GetSelectIDTypeAsync(); 


        //Department Controller
         Task<DeptDashboardRes> DepartmentDashboardAsync(string userID);
         Task<ShowHotelGuestDetailsRes> ShowHotelGuestDetailsAsync(string roomBookingID);
    }
}
