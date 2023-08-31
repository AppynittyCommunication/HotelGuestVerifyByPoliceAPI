using HotelGuestVerifyByPolice.DataContext.Data;
using HotelGuestVerifyByPolice.DataContext.Entities;
using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Interface
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public Repository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<State>> GetTestAsync()
        {
            return await _dbcontext.States.ToListAsync();
        }

        public async Task<HotelRegRes> SaveHotelReg(HotelRegBody obj)
        {
            HotelRegRes result = new HotelRegRes();
            Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.HotelRegNo == obj.hotelRegNo).FirstOrDefaultAsync();

                    if (hotelrefdetails == null)
                    {

                        hoteldetails.HotelRegNo = obj.hotelRegNo;
                        hoteldetails.HotelName = obj.hotelName;
                        hoteldetails.UserId = obj.userId;
                        hoteldetails.Mobile = obj.mobile;
                        hoteldetails.Email = obj.email;
                        hoteldetails.Address = obj.address;
                        hoteldetails.PinCode = obj.pinCode;
                        hoteldetails.StateId = obj.stateId;
                        hoteldetails.DistId = obj.distId;
                        hoteldetails.CityId = obj.cityId;
                        hoteldetails.StationCode = obj.stationCode;
                        hoteldetails.Lat = obj.lat;
                        hoteldetails.Long = obj._long;
                        hoteldetails.DiviceIp = obj.diviceIp;


                        db.Hotels.Add(hoteldetails);
                        await db.SaveChangesAsync();

                        result.code = 200;
                        result.status = "success";
                        result.message = "Registration Details Saved Successfully!";
                        return result;
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Registration Details Save Failed";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    result.code = 200;
                    result.status = "error";
                    result.message = ex.Message;
                    return result;

                }
            }

        }


        public async Task<HotelRegRes> SavePoliceReg(PoliceRegBody obj)
        {
            HotelRegRes result = new HotelRegRes();
            Police policedetails = new Police();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var policerefdetails = await db.Polices.Where(c => c.StationCode == obj.stationCode).FirstOrDefaultAsync();

                    if (policerefdetails == null)
                    {

                        policedetails.UserId = obj.userId;
                        policedetails.UserType= obj.userType;
                        policedetails.StateId = obj.stateId;
                        policedetails.DistId = obj.distId;
                        policedetails.CityId = obj.cityId;
                        policedetails.StationCode = obj.stationCode;
                        policedetails.Mobile = obj.mobile;
                        policedetails.Email = obj.email;
                        policedetails.Lat = obj.lat;
                        policedetails.Long = obj._long;
                        policedetails.DiviceIp = obj.deviceIp;


                        db.Polices.Add(policedetails);
                        await db.SaveChangesAsync();

                        result.code = 200;
                        result.status = "success";
                        result.message = "Registration Details Saved Successfully!";
                        return result;
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Registration Details Save Failed";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    result.code = 200;
                    result.status = "error";
                    result.message = ex.Message;
                    return result;

                }
            }

        }





        public async Task<List<StatesList>> getStateListAsync()
        {
            List<StatesList> statelist = new List<StatesList>();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.States.AsQueryable().Where(c => c.IsActive == true).Select(x => new StatesList
                    {
                        stateId = x.Id,
                        stateName = x.StateName

                    }).ToListAsync();
                    statelist = st;
                }
                return statelist;
            }
            catch (Exception)
            {
                return statelist;
            }
        }


        public async Task<List<DistrictList>> getDistrictListAsync(int stateID)
        {
            List<DistrictList> distlist = new List<DistrictList>();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.Districts.AsQueryable().Where(c => c.StateId == stateID && c.IsActive == true).Select(x => new DistrictList
                    {
                        distId = x.Id,
                        distName = x.DistName

                    }).ToListAsync();
                    distlist = st;
                }
                return distlist;
            }
            catch (Exception)
            {
                return distlist;
            }
        }




        public async Task<List<CityList>> getCityListAsync(int stateID, int distID)
        {
            List<CityList> citylist = new List<CityList>();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.Cities.AsQueryable().Where(c => c.StateId == stateID && c.DistId == distID && c.IsActive == true).Select(x => new CityList
                    {
                        cityId = x.Id,
                        cityName = x.CityName,

                    }).ToListAsync();
                    citylist = st;
                }
                return citylist;
            }
            catch (Exception)
            {
                return citylist;
            }
        }


        public async Task<List<PoliceStationList>> getPoliceStationListAsync(int stateID, int distID, int cityID)
        {
            List<PoliceStationList> pslist = new List<PoliceStationList>();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.PoliceStations.AsQueryable().Where(c => c.StateId == stateID && c.DistId == distID && c.CityId == cityID && c.IsActive == true).Select(x => new PoliceStationList
                    {
                        stationID = x.Id,
                       // stationCode = x.StationCode,
                        stationName = x.StationName,

                    }).ToListAsync();
                    pslist = st;
                }
                return pslist;
            }
            catch (Exception)
            {
                return pslist;
            }
        }


    }
}
