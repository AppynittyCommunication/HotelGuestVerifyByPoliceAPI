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
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository objRep;
        private readonly IConfiguration _configuration;

        public DepartmentController(IRepository repository, IConfiguration configuration)
        {
            _configuration = configuration;
            objRep = repository;
        }


        [Route("DeptDashboard")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<DeptDashboardRes>> DepartmentDashboard([FromHeader] string userID)
        {
            DeptDashboardRes objresponse = await objRep.DepartmentDashboardAsync(userID);

            return objresponse;
        }

        [Route("ShowHotelGuestDetails")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<ShowHotelGuestDetailsRes>> ShowHotelGuestDetails([FromHeader] string roomBookingID)
        {
            ShowHotelGuestDetailsRes objresponse = await objRep.ShowHotelGuestDetailsAsync(roomBookingID);

            return objresponse;
        }

        [Route("SearchHotel")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<SearchHotelResponse>> SearchHotel([FromHeader] string hotelRegNo)
        {
            SearchHotelResponse objresponse = await objRep.SearchHotelAsync(hotelRegNo);

            return objresponse;
        }


    }
}
