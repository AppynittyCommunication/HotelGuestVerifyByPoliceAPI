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
        public async Task<ActionResult<HotelRegRes>> HotelRegistration([FromBody] HotelRegBody obj)
        {
            HotelRegRes objresponse = await objRep.SaveHotelReg(obj);

            return objresponse;
        }


        [Route("PoliceRegistration")]
        [HttpPost]
        public async Task<ActionResult<HotelRegRes>> PoliceRegistration([FromBody] PoliceRegBody obj)
        {
            HotelRegRes objresponse = await objRep.SavePoliceReg(obj);

            return objresponse;
        }
        [Route("HotelLogin")]
        [HttpPost]
        public async Task<ActionResult<HotelLoginRes>> HotelLogin([FromBody] HotelLoginBody obj)
        {
            HotelLoginRes objresponse = await objRep.CheckHotelLogin(obj);
           
            return objresponse;
        }

        [Route("ResetHotelPasswordUsingOTP")]
        [HttpPost]
        public async Task<ActionResult<SetHotelLoginPassRes>> SetHotelLoginPassUsingOTP([FromBody] SetHotelPassBody obj)
        {
            SetHotelLoginPassRes objresponse = await objRep.ChangeHotelPassUsingOTP(obj);

            return objresponse;
        }

        [Route("ResetHotelPassword")]
        public async Task<ActionResult<SetHotelLoginPassRes>> ResetHotelPassword([FromBody] ResetHotelPassBody obj)
        {
            SetHotelLoginPassRes objresponse = await objRep.ResetHotelPass(obj);

            return objresponse;
        }
    }
}
