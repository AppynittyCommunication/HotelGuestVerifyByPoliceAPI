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

        [Route("ResetHotelPasswordUsingOTP")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> SetHotelLoginPassUsingOTP([FromBody] SetHotelPassBody obj)
        {
            CommonAPIResponse objresponse = await objRep.ChangeHotelPassUsingOTP(obj);

            return objresponse;
        }

        [Route("ResetHotelPassword")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> ResetHotelPassword([FromBody] ResetHotelPassBody obj)
        {
            CommonAPIResponse objresponse = await objRep.ResetHotelPass(obj);

            return objresponse;
        }

        [Route("ForgetHotelPassword")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? ForgetHotelPassword([FromBody] PasswordRecoveryBody obj)
        {
            CommonAPIResponse objresponse = await objRep.passwordRecoveryResponse(obj);

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
        [Route("CheckHotelUsername")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CheckHotelUsernameRes>> checkHotelUsername([FromHeader] string username, [FromHeader] string mobileno)
        {
            CheckHotelUsernameRes objresponse = await objRep.checkHotelUsernameExistAsync(username,mobileno);

            return objresponse;
        }

        [Route("VerifyMobileNo")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<VerifyMobileNo>> MobileNoVerification([FromHeader] string mobileno)
        {
            VerifyMobileNo objresponse = await objRep.SendOTPToMobile(mobileno);

            return objresponse;
        }
    }
}
