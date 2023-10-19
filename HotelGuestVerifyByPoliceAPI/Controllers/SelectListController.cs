using HotelGuestVerifyByPolice.DataContext.Interface;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Numerics;

namespace HotelGuestVerifyByPoliceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectListController : ControllerBase
    {
        private readonly IRepository objRep;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SelectListController> _logger;
        
        public SelectListController(IRepository repository, IConfiguration configuration, ILogger<SelectListController> logger)
        {
            _configuration = configuration;
            objRep = repository;
            _logger = logger;
            _logger.LogInformation("\n\nSelectListController Logs : \n");
        }
        


        [Route("GetCountry")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CountryList>> GetCountry()
        {
            
            CountryList countrylist = new CountryList();
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
        [HttpGet]
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
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<DistrictList>> GetDistrict([FromHeader] int stateID)
        {
            DistrictList distlist = new DistrictList();
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
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CityList>> GetCities([FromHeader] int stateID, [FromHeader] int distID)
        {
            CityList citylist = new CityList();
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
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<PoliceStationList>> GetPoliceStation([FromHeader] int stateID, [FromHeader] int distID, [FromHeader] int cityID)
        {
            PoliceStationList pslist = new ();
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



        [Route("GetHotel")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<HotelList>> GetHotel([FromHeader] int psId)
        {
            HotelList hlist = new();
            try
            {
                hlist = await objRep.GetHotelListAsync(psId);
                return hlist;
            }
            catch (Exception)
            {
                return hlist;
            }
        }


        [Route("GetDepartmentType")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<DepartmentTypeList>> GetDepartmentType()
        {
            DepartmentTypeList deptTypeList = new ();
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
