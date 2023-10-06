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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns a 400 Bad Request with validation errors
            }
            else
            {
                CommonAPIResponse objresponse = await objRep.SaveHotelReg(obj);
                return objresponse;
            }
          
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
            CommonAPIResponse objresponse = await objRep.ResetHotelPassAsync(obj);

            return objresponse;
        }

        [Route("ForgetHotelPasswordStep2")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? ForgetHotelPassStep2([FromBody] PasswordRecoveryBody obj)
        {
            CommonAPIResponse objresponse = await objRep.ForgetHotelPassStep2Async(obj);

            return objresponse;
        }

        [Route("ForgetDeptPassStep2")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? ForgetDeptPassStep2([FromBody] DeptPasswordRecoveryBody obj)
        {
            CommonAPIResponse objresponse = await objRep.ForgetDeptPassStep2Async(obj);

            return objresponse;
        }


        [Route("HotelRegExist")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? CheckHotelRegExist([FromHeader] string hotelRegNumber)
        {
            CommonAPIResponse objresponse = await objRep.CheckHotelRegExistAsync(hotelRegNumber);

            return objresponse;
        }


        [Route("UsernameExist")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>>? CheckUserExist([FromHeader] string userId)
        {
            CommonAPIResponse objresponse = await objRep.CheckUsernameExistAsync(userId);

            return objresponse;
        }



        [Route("ForgetHotelPasswordStep1")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CheckHotelUsernameRes>> ForgetHotePassStep1([FromHeader] string username, [FromHeader] string mobileno)
        {
            CheckHotelUsernameRes objresponse = await objRep.ForgetHotePassStep1Async(username,mobileno);

            return objresponse;
        }


        [Route("ForgetDeptPassStep1")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CheckDeptUsernameRes>> ForgetDeptPassStep1([FromHeader] string username, [FromHeader] string mobileno)
        {
            CheckDeptUsernameRes objresponse = await objRep.ForgetDeptPassStep1Async(username, mobileno);

            return objresponse;
        }



        [Route("VerifyMobileNo")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<VerifyMobileNo>> VerifyMobileNo([FromHeader] string mobileno)
        {
            VerifyMobileNo objresponse = await objRep.VerifyMobileNoAsync(mobileno);

            return objresponse;
        }


        [Route("CheckAuthPin")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> CheckAuthPin([FromHeader] string authPin)
        {
            CommonAPIResponse objresponse = await objRep.CheckAuthPinAsync(authPin);

            return objresponse;
        }

       

    }
}
