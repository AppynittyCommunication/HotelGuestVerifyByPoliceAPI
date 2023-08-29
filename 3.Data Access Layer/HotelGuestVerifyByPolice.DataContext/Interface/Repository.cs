using HotelGuestVerifyByPolice.DataContext.Data;
using HotelGuestVerifyByPolice.DataContext.Entities;
using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                    var hotelrefdetails =await db.Hotels.Where(c=> c.HotelRegNo == obj.hotelRegNo).FirstOrDefaultAsync();

                    if(hotelrefdetails == null)
                    {

                        hoteldetails.HotelRegNo = obj.hotelRegNo;
                        hoteldetails.HotelName = obj.hotelName;
                        hoteldetails.Mobile = obj.mobile;
                        hoteldetails.Email = obj.email;
                        hoteldetails.Address = obj.address;
                        hoteldetails.PinCode = obj.pinCode;
                        hoteldetails.StateId = obj.stateId;
                        hoteldetails.DistId = obj.distId;
                        hoteldetails.CityId = obj.cityId;
                        hoteldetails.StationId = obj.stationId;
                        hoteldetails.Lat = obj.lat;
                        hoteldetails.Long = obj._long;
                        hoteldetails.DiviceIp = obj.diviceIp;


                        db.Hotels.Add(hoteldetails);
                        await db.SaveChangesAsync();

                        result.code = 200;
                        result.status = "success";
                        result.message = "Registration Details Save Successfully Done";
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
    }
}
