using HotelGuestVerifyByPolice.DataContext.Interface;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelGuestVerifyByPoliceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectListController : ControllerBase
    {
        private readonly IRepository objRep;
        private readonly IConfiguration _configuration;

        public SelectListController(IRepository repository, IConfiguration configuration)
        {
            _configuration = configuration;
            objRep = repository;
        }

        [Route("GetStates")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<StatesList>>> getState()
        {
            List<StatesList> statelist = new List<StatesList>();
            try
            {
                statelist = await objRep.getStateListAsync();
                return statelist;
            }
            catch (Exception)
            {
                return statelist;
            }
        }

        [Route("GetDistrict")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<DistrictList>>> getDistrict([FromHeader] int stateID)
        {
            List<DistrictList> distlist = new List<DistrictList>();
            try
            {
                distlist = await objRep.getDistrictListAsync(stateID);
                return distlist;
            }
            catch (Exception)
            {
                return distlist;
            }
        }

        [Route("GetCities")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<CityList>>> getCities([FromHeader] int stateID, [FromHeader] int distID)
        {
            List<CityList> citylist = new List<CityList>();
            try
            {
                citylist = await objRep.getCityListAsync(stateID, distID);
                return citylist;
            }
            catch (Exception)
            {
                return citylist;
            }
        }


        [Route("GetPoliceStation")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<PoliceStationList>>> getPoliceStation([FromHeader] int stateID, [FromHeader] int distID, [FromHeader] int cityID)
        {
            List<PoliceStationList> pslist = new List<PoliceStationList>();
            try
            {
                pslist = await objRep.getPoliceStationListAsync(stateID, distID, cityID);
                return pslist;
            }
            catch (Exception)
            {
                return pslist;
            }
        }


        [Route("GetDepartmentType")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<DepartmentTypeList>>> getDepartmentType()
        {
            List<DepartmentTypeList> deptTypeList = new List<DepartmentTypeList>();
            try
            {
                deptTypeList = await objRep.getDepartmentTypeListAsync();
                return deptTypeList;
            }
            catch (Exception)
            {
                return deptTypeList;
            }
        }

    }
}
