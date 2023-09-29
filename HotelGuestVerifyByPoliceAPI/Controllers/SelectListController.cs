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

        [Route("GetCountry")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<List<CountryList>>> GetCountry()
        {
            List<CountryList> countrylist = new List<CountryList>();
            try
            {
                countrylist = await objRep.GetCountryListAsync();
                return countrylist;
            }
            catch (Exception)
            {
                return countrylist;
            }
        }


        [Route("GetCountryWiseStates")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<StatesList>> GetCountryWiseState([FromHeader] string countryCode)
        {
            StatesList statelist = new ();
            try
            {
                statelist = await objRep.GetCountryWiseStateListAsync(countryCode);
                return statelist;
            }
            catch (Exception)
            {
                return statelist;
            }
        }
        [Route("GetStates")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<StatesList>> GetState()
        {
            StatesList statelist = new ();
            try
            {
                statelist = await objRep.GetStateListAsync();
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
        public async Task<ActionResult<List<DistrictList>>> GetDistrict([FromHeader] int stateID)
        {
            List<DistrictList> distlist = new List<DistrictList>();
            try
            {
                distlist = await objRep.GetDistrictListAsync(stateID);
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
        public async Task<ActionResult<List<CityList>>> GetCities([FromHeader] int stateID, [FromHeader] int distID)
        {
            List<CityList> citylist = new List<CityList>();
            try
            {
                citylist = await objRep.GetCityListAsync(stateID, distID);
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
        public async Task<ActionResult<List<PoliceStationList>>> GetPoliceStation([FromHeader] int stateID, [FromHeader] int distID, [FromHeader] int cityID)
        {
            List<PoliceStationList> pslist = new List<PoliceStationList>();
            try
            {
                pslist = await objRep.GetPoliceStationListAsync(stateID, distID, cityID);
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
        public async Task<ActionResult<List<DepartmentTypeList>>> GetDepartmentType()
        {
            List<DepartmentTypeList> deptTypeList = new List<DepartmentTypeList>();
            try
            {
                deptTypeList = await objRep.GetDepartmentTypeListAsync();
                return deptTypeList;
            }
            catch (Exception)
            {
                return deptTypeList;
            }
        }

    }
}
