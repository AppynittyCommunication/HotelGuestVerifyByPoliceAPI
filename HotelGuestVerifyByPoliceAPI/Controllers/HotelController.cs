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
        private readonly ILogger<HotelController> _logger;

        public HotelController(IRepository repository, IConfiguration configuration, ILogger<HotelController> logger)
        {
            _configuration = configuration;
            objRep = repository;
            _logger = logger;
            _logger.LogInformation("\n\nHotelController Logs : \n");
        }

        [Route("HotelGuestRegistration")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> HotelRegistration([FromBody] HotelGuestRegistration obj)
        {
            CommonAPIResponse objresponse = await objRep.SaveHotelGuestReg(obj);

            return objresponse;
        }


        [Route("GetGuestCheckInOutInfo")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<HotelCheckInListResult>> CheckGuestInOutStatus([FromHeader] string hotelRegNo)
        {
            HotelCheckInListResult objresponse = await objRep.CheckGuestInOutStatusAsync(hotelRegNo);
            if (objresponse.status == "error" && objresponse.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return objresponse;
        }

        [Route("GetGuestCheckInList")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<GuestCheckedInList>> CheckGuestInList([FromHeader] string hotelRegNo)
        {
            GuestCheckedInList objresponse = new();
            objresponse = await objRep.CheckGuestInListAsync(hotelRegNo);
            if (objresponse.status == "error" && objresponse.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return objresponse;

        }


        [Route("SelectRelation")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<RelationsList>> GetRelation()
        {
            RelationsList objresponse = new();
            objresponse = await objRep.GetRelationAsync();
            if (objresponse.status == "error" && objresponse.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return objresponse;

        }


        [Route("SelectVisitPurpose")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<VisitPurposeList>> GetVisitPurpose()
        {
            VisitPurposeList objresponse = new();

            objresponse = await objRep.GetVisitPurposeAsync();
            if (objresponse.status == "error" && objresponse.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return objresponse;
        }

        [Route("SelectSelectIDType")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<SelectIDTypeList>> GetSelectIDType()
        {
            SelectIDTypeList objresponse = new();

            objresponse = await objRep.GetSelectIDTypeAsync();
            if (objresponse.status == "error" && objresponse.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return objresponse;
        }


        [Route("CheckOutGuest")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> CheckOutGuest([FromHeader] string roomBookingID)
        {
            CommonAPIResponse objresponse = await objRep.CheckOutGuestAsync(roomBookingID);
            if (objresponse.status == "error" && objresponse.code != 200)
                throw new Exception("Exception Occured While Checking Out Guest.");
            return objresponse;
        }


        [Route("ShowGuestDetails")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<ShowGuestDetailsRes>> ShowGuestDetails([FromHeader] string roomBookingID)
        {
            ShowGuestDetailsRes objresponse = await objRep.ShowGuestDetailsAsync(roomBookingID);
            if (objresponse.status == "error" && objresponse.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return objresponse;
        }


    }
}
