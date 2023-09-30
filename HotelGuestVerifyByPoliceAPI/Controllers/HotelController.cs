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
            CommonAPIResponse objresponse = await objRep.SaveHotelGuestReg(obj);

            return objresponse;
        }


        [Route("GetGuestCheckInOutInfo")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<HotelCheckInListResult>> CheckGuestInOutStatus([FromHeader] string hotelRegNo)
        {
            HotelCheckInListResult objresponse = await objRep.CheckGuestInOutStatusAsync(hotelRegNo);

            return objresponse;
        }


        [Route("SelectRelation")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<RelationsList>> GetRelation()
        {
            RelationsList objresponse = new();
            try
            {
                objresponse = await objRep.GetRelationAsync();
                return objresponse;
            }
            catch (Exception)
            {
                return objresponse;
            }
        }


        [Route("SelectVisitPurpose")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<VisitPurposeList>> GetVisitPurpose()
        {
            VisitPurposeList objresponse = new();
            try
            {
                objresponse = await objRep.GetVisitPurposeAsync();
                return objresponse;
            }
            catch (Exception)
            {
                return objresponse;
            }
        }

        [Route("SelectSelectIDType")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<SelectIDTypeList>> GetSelectIDType()
        {
            SelectIDTypeList objresponse = new();
            try
            {
                objresponse = await objRep.GetSelectIDTypeAsync();
                return objresponse;
            }
            catch (Exception)
            {
                return objresponse;
            }
        }


        [Route("CheckOutGuest")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CommonAPIResponse>> CheckOutGuest([FromHeader] string roomBookingID)
        {
            CommonAPIResponse objresponse = await objRep.CheckOutGuestAsync(roomBookingID);
           
             return objresponse;
        }



    }
}
