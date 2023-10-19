using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
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
            countrylist = await objRep.GetCountryListAsync();
            if (countrylist.status == "error" && countrylist.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return countrylist;
        }


        [Route("GetCountryWiseStates")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<StatesList>> GetCountryWiseState([FromHeader] string countryCode)
        {
            StatesList statelist = new();
            statelist = await objRep.GetCountryWiseStateListAsync(countryCode);
            if (statelist.status == "error" && statelist.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return statelist;
        }


        [Route("GetStates")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<StatesList>> GetState()
        {
            StatesList statelist = new();
            statelist = await objRep.GetStateListAsync();
            if (statelist.status == "error" && statelist.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return statelist;
        }

        [Route("GetDistrict")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<DistrictList>> GetDistrict([FromHeader] int stateID)
        {
            DistrictList distlist = new DistrictList();
            distlist = await objRep.GetDistrictListAsync(stateID);
            if (distlist.status == "error" && distlist.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return distlist;
        }

        [Route("GetCities")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<CityList>> GetCities([FromHeader] int stateID, [FromHeader] int distID)
        {
            CityList citylist = new CityList();
            citylist = await objRep.GetCityListAsync(stateID, distID);
            if (citylist.status == "error" && citylist.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return citylist;

        }


        [Route("GetPoliceStation")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<PoliceStationList>> GetPoliceStation([FromHeader] int stateID, [FromHeader] int distID, [FromHeader] int cityID)
        {
            PoliceStationList pslist = new();
            pslist = await objRep.GetPoliceStationListAsync(stateID, distID, cityID);
            if (pslist.status == "error" && pslist.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return pslist;
        }



        [Route("GetHotel")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<HotelList>> GetHotel([FromHeader] int psId)
        {
            HotelList hlist = new();
             hlist = await objRep.GetHotelListAsync(psId);
            if (hlist.status == "error" && hlist.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return hlist;
        }


        [Route("GetDepartmentType")]
        [HttpGet]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<DepartmentTypeList>> GetDepartmentType()
        {
            DepartmentTypeList deptTypeList = new();
            deptTypeList = await objRep.GetDepartmentTypeListAsync();
            if (deptTypeList.status == "error" && deptTypeList.code != 200)
                throw new Exception("Exception Occured While Fetching The Data.");
            return deptTypeList;
        }

    }
}
