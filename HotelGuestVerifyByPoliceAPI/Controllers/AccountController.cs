﻿using HotelGuestVerifyByPolice.DataContext.Interface;
using HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelGuestVerifyByPoliceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepository objRep;
        private readonly IConfiguration _configuration;

        public AccountController(IRepository repository, IConfiguration configuration)
        {
            _configuration = configuration;
            objRep = repository;
        }

        [Route("HotelRegistration")]
        [HttpPost]
        [EnableCors("MyCorsPolicy")]
        public async Task<ActionResult<HotelRegRes>> GetAdminLogin([FromBody] HotelRegBody obj)
        {
            HotelRegRes objresponse = await objRep.SaveHotelReg(obj);

            return objresponse;
        }


        [Route("PoliceRegistration")]
        [HttpPost]
        public async Task<ActionResult<HotelRegRes>> GetPoliceLogin([FromBody] PoliceRegBody obj)
        {
            HotelRegRes objresponse = await objRep.SavePoliceReg(obj);

            return objresponse;
        }

    }
}
