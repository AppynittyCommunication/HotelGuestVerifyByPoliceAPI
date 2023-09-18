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
    public class HotelController : ControllerBase
    {
        private readonly IRepository objRep;
        private readonly IConfiguration _configuration;

        public HotelController(IRepository repository, IConfiguration configuration)
        {
            _configuration = configuration;
            objRep = repository;
        }

        [Route("HotelGuestRegistration")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> HotelRegistration([FromBody] HotelGuestRegistration obj)
        {
            CommonAPIResponse objresponse = await objRep.saveHotelGuestReg(obj);

            return objresponse;
        }


        [Route("GetGuestCheckInOutInfo")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<HotelCheckInListResult>> checkGuestInOutStatus([FromHeader] string hotelRegNo)
        {
            HotelCheckInListResult objresponse = await objRep.checkGuestInOutStatusAsync(hotelRegNo);

            return objresponse;
        }

    }
}
