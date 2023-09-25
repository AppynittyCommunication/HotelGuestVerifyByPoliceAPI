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
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<RelationsList>>> GetRelation()
        {
            List<RelationsList> objresponse = await objRep.GetRelationAsync();
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
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<VisitPurposeList>>> GetVisitPurpose()
        {
            List<VisitPurposeList> objresponse = await objRep.GetVisitPurposeAsync();
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
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<SelectIDTypeList>>> GetSelectIDType()
        {
            List<SelectIDTypeList> objresponse = await objRep.GetSelectIDTypeAsync();
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
       
    }
}
