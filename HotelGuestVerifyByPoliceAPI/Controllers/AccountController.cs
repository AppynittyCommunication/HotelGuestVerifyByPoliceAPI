using HotelGuestVerifyByPolice.DataContext.Interface;
using HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelGuestVerifyByPoliceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepository objRep;
        private readonly IConfiguration _configuration;

        public AccountController(IRepository repository, IConfiguration configuration)
        {
            _configuration = configuration;
            objRep = repository;
        }

        [Route("HotelRegistration")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> HotelRegistration([FromBody] HotelRegBody obj)
        {
            CommonAPIResponse objresponse = await objRep.SaveHotelReg(obj);

            return objresponse;
        }


        [Route("PoliceRegistration")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> PoliceRegistration([FromBody] PoliceRegBody obj)
        {
            CommonAPIResponse objresponse = await objRep.SavePoliceReg(obj);

            return objresponse;
        }
        [Route("HotelLogin")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<HotelLoginRes>> HotelLogin([FromBody] HotelLoginBody obj)
        {
            HotelLoginRes objresponse = await objRep.CheckHotelLogin(obj);
           
            return objresponse;
        }

        [Route("DeptLogin")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<DepartmentLoginRes>> DeptLogin([FromBody] DepartmentLoginBody obj)
        {
            DepartmentLoginRes objresponse = await objRep.CheckDeptLogin(obj);

            return objresponse;
        }



        [Route("ResetHotelPasswordUsingOTP")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> SetHotelLoginPassUsingOTP([FromBody] SetHotelPassBody obj)
        {
            CommonAPIResponse objresponse = await objRep.ChangeHotelPassUsingOTP(obj);

            return objresponse;
        }

        [Route("ResetDeptPasswordUsingOTP")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> SetDeptLoginPassUsingOTP([FromBody] SetDeptPassBody obj)
        {
            CommonAPIResponse objresponse = await objRep.ChangeDeptPassUsingOTP(obj);

            return objresponse;
        }



        [Route("ResetHotelPassword")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> ResetHotelPassword([FromBody] ResetHotelPassBody obj)
        {
            CommonAPIResponse objresponse = await objRep.resetHotelPass(obj);

            return objresponse;
        }

        [Route("ForgetHotelPassword")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? forgetHotelPassword([FromBody] PasswordRecoveryBody obj)
        {
            CommonAPIResponse objresponse = await objRep.hotelPasswordRecoveryResponse(obj);

            return objresponse;
        }

        [Route("ForgetDeptPassword")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? forgetDeptPassword([FromBody] DeptPasswordRecoveryBody obj)
        {
            CommonAPIResponse objresponse = await objRep.deptPasswordRecoveryResponse(obj);

            return objresponse;
        }


        [Route("HotelRegExist")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? checkHotelRegExist([FromHeader] string hotelRegNumber)
        {
            CommonAPIResponse objresponse = await objRep.checkHotelRegExistAsync(hotelRegNumber);

            return objresponse;
        }

        [Route("DepartUsernameExist")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? checkDepartUserExist([FromHeader] string userId)
        {
            CommonAPIResponse objresponse = await objRep.checkDepartUsernameExistAsync(userId);

            return objresponse;
        }

        [Route("HotelUsernameExist")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? checkHotelUserExist([FromHeader] string userId)
        {
            CommonAPIResponse objresponse = await objRep.checkHotelUsernameExistAsync(userId);

            return objresponse;
        }



        [Route("CheckHotelUsername")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CheckHotelUsernameRes>> checkHotelUsername([FromHeader] string username, [FromHeader] string mobileno)
        {
            CheckHotelUsernameRes objresponse = await objRep.checkHotelUsernameExistAsync(username,mobileno);

            return objresponse;
        }


        [Route("CheckDeptUsername")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CheckDeptUsernameRes>> checkDeptUsername([FromHeader] string username, [FromHeader] string mobileno)
        {
            CheckDeptUsernameRes objresponse = await objRep.checkDeptUsernameExistAsync(username, mobileno);

            return objresponse;
        }



        [Route("VerifyMobileNo")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<VerifyMobileNo>> mobileNoVerification([FromHeader] string mobileno)
        {
            VerifyMobileNo objresponse = await objRep.sendOTPToMobile(mobileno);

            return objresponse;
        }
    }
}
