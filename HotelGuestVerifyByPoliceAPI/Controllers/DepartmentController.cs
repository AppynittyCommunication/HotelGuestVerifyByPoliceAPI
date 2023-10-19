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
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IRepository repository, IConfiguration configuration, ILogger<DepartmentController> logger)
        {
            _configuration = configuration;
            objRep = repository;
            _logger = logger;
            _logger.LogInformation("\n\nDepartmentController Logs : \n");
        }


        [Route("DeptDashboard")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<DeptDashboardRes>> DepartmentDashboard([FromHeader] string userID)
        {
            DeptDashboardRes objresponse = await objRep.DepartmentDashboardAsync(userID);

            return objresponse;
        }

        [Route("ShowHotelGuestDetails")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<ShowHotelGuestDetailsRes>> ShowHotelGuestDetails([FromHeader] string roomBookingID)
        {
            ShowHotelGuestDetailsRes objresponse = await objRep.ShowHotelGuestDetailsAsync(roomBookingID);

            return objresponse;
        }

        [Route("SearchHotel")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<SearchHotelResponse>> SearchHotel([FromHeader] string hotelRegNo)
        {
            SearchHotelResponse objresponse = await objRep.SearchHotelAsync(hotelRegNo);

            return objresponse;
        }


    }
}
