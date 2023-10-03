using HotelGuestVerifyByPolice.DataContext.Data;
using HotelGuestVerifyByPolice.DataContext.Entities;
using HotelGuestVerifyByPolice.DataContext.Entities.SPEntities;
using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelGuestVerifyByPolice.DataContext.Interface
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly HttpClient _httpClient;
        public Repository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<State>> GetTestAsync()
        {
            return await _dbcontext.States.ToListAsync();
        }

        public async Task<CommonAPIResponse> SaveHotelReg(HotelRegBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.HotelRegNo == obj.hotelRegNo).FirstOrDefaultAsync();

                    if (hotelrefdetails == null)
                    {
                        hoteldetails.CreateDate = DateTime.Now;
                        hoteldetails.HotelRegNo = obj.hotelRegNo;
                        hoteldetails.HotelName = obj.hotelName;
                        hoteldetails.FirstName = obj.firstName;
                        hoteldetails.LastName = obj.lastName;
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
                        hoteldetails.IsActive = false;
                        hoteldetails.IsMobileVerify = obj.isMobileVerify;
                        hoteldetails.Password = obj.password;

                        Random random = new Random();
                        string r = random.Next(000001, 999999).ToString();

                        var existOTP = await db.Hotels.Where(c => c.Otp == r).FirstOrDefaultAsync();
                        if (existOTP != null)
                        {
                            r = random.Next().ToString();
                        }
                        hoteldetails.Otp = r;

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
                        result.message = "Registration Failed";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;

                    Log.Error(ex.Message);
                    return result;

                }
            }

        }



        public async Task<CommonAPIResponse> SaveAuthUserAsync(SaveAuthUserBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();


            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var checkauth = await db.AuthenticationPins.Where(c => c.AuthPin == obj.authPin).FirstOrDefaultAsync();

                    if (checkauth != null)
                    {
                        checkauth.UserId = obj.userID;
                        checkauth.UseFor = obj.useFor;
                        checkauth.IsUse = obj.isUse;
                        checkauth.UseDate = DateTime.Now;

                        //db.AuthenticationPins.Add(checkauth);
                        await db.SaveChangesAsync();

                        result.code = 200;
                        result.status = "success";
                        result.message = "Authentication Data Saved Successfully!";
                        return result;
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Failed";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }

        }



        public async Task<CommonAPIResponse> SavePoliceReg(PoliceRegBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            Police policedetails = new Police();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var policerefdetails = await db.Polices.Where(c => c.StationCode == obj.stationCode && obj.stationCode != null).FirstOrDefaultAsync();

                    if (policerefdetails == null)
                    {
                        policedetails.CreateDate = DateTime.Now;
                        policedetails.UserId = obj.userId;
                        policedetails.PoliceName = obj.policeName;
                        policedetails.UserType = obj.userType;
                        policedetails.StateId = obj.stateId;
                        policedetails.DistId = obj.distId;
                        policedetails.CityId = obj.cityId;
                        policedetails.StationCode = obj.stationCode;
                        policedetails.Mobile = obj.mobile;
                        policedetails.Email = obj.email;
                        policedetails.Lat = obj.lat;
                        policedetails.Long = obj._long;
                        policedetails.DiviceIp = obj.deviceIp;
                        policedetails.IsActive = false;
                        policedetails.Password = obj.password;
                        policedetails.IsMobileVerify = obj.isMobileVerify;
                        Random random = new Random();
                        string r = random.Next(000001, 999999).ToString();
                        var existOTP = await db.Polices.Where(c => c.Otp == r).FirstOrDefaultAsync();
                        if (existOTP != null)
                        {
                            r = random.Next().ToString();
                        }
                        policedetails.Otp = r;


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
                        result.message = "Registration Failed";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }

        }


        public async Task<CountryList> GetCountryListAsync()
        {
            CountryList countrylist = new CountryList();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.Countries.AsQueryable().Where(c => c.IsActive == true).Select(x => new { x.CountryCode, x.CountryName, }).ToListAsync();

                    countrylist.code = 200;
                    countrylist.status = "success";
                    countrylist.message = "Countries List";
                    countrylist.data = st;
                }
                return countrylist;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                    countrylist.code = w32ex.ErrorCode;
                }

                Log.Error(ex.Message);
                countrylist.status = "error";
                countrylist.message = ex.Message;
                return countrylist;

            }
        }

        public async Task<StatesList> GetCountryWiseStateListAsync(string countryCode)
        {
            StatesList statelist = new();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.States.AsQueryable().Where(c => c.IsActive == true && c.CountryCode == countryCode).Select(x => new { x.StateId, x.StateName, }).ToListAsync();

                    statelist.code = 200;
                    statelist.status = "success";
                    statelist.message = "Get State List As Per Country";
                    statelist.data = st;
                }
                return statelist;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                    statelist.code = w32ex.ErrorCode;
                }

                Log.Error(ex.Message);
                statelist.status = "error";
                statelist.message = ex.Message;
                return statelist;

            }
        }
        public async Task<StatesList> GetStateListAsync()
        {
            StatesList statelist = new ();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.States.AsQueryable().Where(c => c.IsActive == true).Select(x => new{ stateId = x.StateId,stateName = x.StateName,}).ToListAsync();

                    statelist.code = 200;
                    statelist.status = "success";
                    statelist.message = "Get State List Successfully";
                    statelist.data = st;
                    return statelist;
                }
                return statelist;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                    statelist.code = w32ex.ErrorCode;
                }

                Log.Error(ex.Message);
                statelist.status = "error";
                statelist.message = ex.Message;
                return statelist;

            }
        }

      
        public async Task<DepartmentTypeList> GetDepartmentTypeListAsync()
        {
            DepartmentTypeList depttypelist = new ();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.DepartmentTypes.AsQueryable().Where(c => c.IsActive == true).Select(x => new { x.DeptTypeId, x.DeptTypeName}).ToListAsync();
                    
                    depttypelist.code = 200;
                    depttypelist.status = "success";
                    depttypelist.message = "Department List";
                    depttypelist.data = st;
                }
                return depttypelist;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                    depttypelist.code = w32ex.ErrorCode;
                }

                Log.Error(ex.Message);
                depttypelist.status = "error";
                depttypelist.message = ex.Message;
                return depttypelist;
            }
        }


        public async Task<DistrictList> GetDistrictListAsync(int stateID)
        {
            DistrictList distlist = new DistrictList();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.Districts.AsQueryable().Where(c => c.StateId == stateID && c.IsActive == true).Select(x => new { x.DistId, x.DistName, }).ToListAsync();
                    {
                        distlist.code = 200;
                        distlist.status = "success";
                        distlist.message = "District List";
                        distlist.data = st;
                        return distlist;
                    }
                    return distlist;
                }
                return distlist;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                    distlist.code = w32ex.ErrorCode;
                }

                Log.Error(ex.Message);
                distlist.status = "error";
                distlist.message = ex.Message;
                return distlist;
            }
        }




        public async Task<CityList> GetCityListAsync(int stateID, int distID)
        {
           CityList citylist = new CityList();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.Cities.AsQueryable().Where(c => c.StateId == stateID && c.DistId == distID && c.IsActive == true).Select(x => new { x.CityId, x.CityName, }).ToListAsync();
                    {
                       citylist.code = 200;
                        citylist.status = "success";
                        citylist.message = "City List";
                        citylist.data = st;
                        return citylist;

                    }
                    return citylist;
                }
                return citylist;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }

                Log.Error(ex.Message);
                return citylist;
            }
        }


        public async Task<PoliceStationList> GetPoliceStationListAsync(int stateID, int distID, int cityID)
        {
            PoliceStationList pslist = new PoliceStationList();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.PoliceStations.AsQueryable().Where(c => c.StateId == stateID && c.DistId == distID && c.CityId == cityID && c.IsActive == true).Select(x => new { x.StationCode, x.StationName }).ToListAsync();
                    {
                        pslist.code = 200;
                        pslist.status = "success";
                        pslist.message = "OK";
                        pslist.data = st;
                        return pslist;
                    }
                    
                }
                return pslist;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }

                Log.Error(ex.Message);
                return pslist;
            }
        }

        public async Task<HotelLoginRes> CheckHotelLogin(HotelLoginBody obj)
        {
            HotelLoginRes result = new HotelLoginRes();
            //Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.UserId == obj.hUsername).FirstOrDefaultAsync();

                    if (hotelrefdetails != null)
                    {
                        var hotelDetailsRes = await db.Hotels.Where(x => x.UserId == obj.hUsername).Select(x => new { x.HotelRegNo, x.HotelName }).ToListAsync();

                        if (hotelrefdetails.Password == null || hotelrefdetails.Password == "")
                        {
                            if (hotelrefdetails.Otp == obj.hPassword)
                            {
                                if (hotelrefdetails.Otpuse == null)
                                {
                                    hotelrefdetails.Otpuse = 1;
                                }
                                else
                                {
                                    int a = (int)hotelrefdetails.Otpuse;
                                    hotelrefdetails.Otpuse = a + 1;
                                }
                                hotelrefdetails.OtpuseDateTime = DateTime.Now;

                                await db.SaveChangesAsync();

                                result.code = 200;
                                result.status = "success";
                                result.message = "Hotel Login Successfully Done!";
                                result.otp = true;
                                result.data = hotelDetailsRes;
                                return result;
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Login Failed..You Entered Wrong OTP!";
                                result.otp = false;
                                result.data = "";
                                return result;
                            }
                        }
                        else
                        {
                            if (hotelrefdetails.Password == obj.hPassword)
                            {
                                result.code = 200;
                                result.status = "success";
                                result.message = "Hotel Login Successfully Done!";
                                result.otp = false;
                                result.data = hotelDetailsRes;
                                return result;
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Login Failed.. You Entered Wrong Password!";
                                return result;
                            }
                        }

                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "The Username " + obj.hUsername + " Is Not Available.. Please Enter Correct Username";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;

                    Log.Error(ex.Message);
                    return result;

                }
            }
        }


        public async Task<DepartmentLoginRes> CheckDeptLogin(DepartmentLoginBody obj)
        {
            DepartmentLoginRes result = new();
            //Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var deptrefdetails = await db.Polices.Where(c => c.UserId == obj.dUsername).FirstOrDefaultAsync();

                    if (deptrefdetails != null)
                    {
                        var deptDetailsRes = await db.Polices.Where(x => x.UserId == obj.dUsername).Select(x => new { x.PoliceId, x.UserId,x.UserType }).ToListAsync();

                        if (deptrefdetails.Password == null || deptrefdetails.Password == "")
                        {
                            if (deptrefdetails.Otp == obj.dPassword)
                            {
                                if (deptrefdetails.Otpuse == null)
                                {
                                    deptrefdetails.Otpuse = 1;
                                }
                                else
                                {
                                    int a = (int)deptrefdetails.Otpuse;
                                    deptrefdetails.Otpuse = a + 1;
                                }
                                deptrefdetails.OtpuseDateTime = DateTime.Now;

                                await db.SaveChangesAsync();

                                result.code = 200;
                                result.status = "success";
                                result.message = "Department Login Successfully Done!";
                                result.otp = true;
                                result.data = deptDetailsRes;
                                return result;
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Login Failed..You Entered Wrong OTP!";
                                result.otp = false;
                                result.data = "";
                                return result;
                            }
                        }
                        else
                        {
                            if (deptrefdetails.Password == obj.dPassword)
                            {
                                result.code = 200;
                                result.status = "success";
                                result.message = "Department Login Successfully Done!";
                                result.otp = false;
                                result.data = deptDetailsRes;
                                return result;
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Login Failed.. You Entered Wrong Password!";
                                return result;
                            }
                        }

                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "The Username " + obj.dUsername + " Is Not Available.. Please Enter Correct Username";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }




        public async Task<CommonAPIResponse> ChangeHotelPassUsingOTP(SetHotelPassBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();


            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.UserId == obj.hUsername).FirstOrDefaultAsync();

                    if (hotelrefdetails != null)
                    {
                        if (hotelrefdetails.Otpuse != null)
                        {
                            if (hotelrefdetails.Password == null || hotelrefdetails.Password == "")
                            {
                                if (hotelrefdetails.Otp == obj.otp)
                                {
                                    hotelrefdetails.Password = obj.pass;
                                    await db.SaveChangesAsync();

                                    result.code = 200;
                                    result.status = "success";
                                    result.message = "New Password Are Successfully Set.Please Login Again";
                                    return result;
                                }
                                else
                                {
                                    result.code = 200;
                                    result.status = "error";
                                    result.message = "You Used Wrong OTP..Please Entered Correct OTP";
                                    return result;
                                }
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Password Already Set Using OTP";
                                return result;
                            }

                        }
                        else
                        {
                            result.code = 200;
                            result.status = "error";
                            result.message = "Please Used OTP For First Time Login Then Set The New Password";
                            return result;
                        }
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "The Username " + obj.hUsername + " Is Not Available.. Please Enter Correct Username";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }

        }

        public async Task<CommonAPIResponse> ChangeDeptPassUsingOTP(SetDeptPassBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();


            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var deptrefdetails = await db.Polices.Where(c => c.UserId == obj.dUsername).FirstOrDefaultAsync();

                    if (deptrefdetails != null)
                    {
                        if (deptrefdetails.Otpuse != null)
                        {
                            if (deptrefdetails.Password == null || deptrefdetails.Password == "")
                            {
                                if (deptrefdetails.Otp == obj.otp)
                                {
                                    deptrefdetails.Password = obj.pass;
                                    await db.SaveChangesAsync();

                                    result.code = 200;
                                    result.status = "success";
                                    result.message = "New Password Are Successfully Set.Please Login Again";
                                    return result;
                                }
                                else
                                {
                                    result.code = 200;
                                    result.status = "error";
                                    result.message = "You Used Wrong OTP..Please Entered Correct OTP";
                                    return result;
                                }
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Password Already Set Using OTP";
                                return result;
                            }

                        }
                        else
                        {
                            result.code = 200;
                            result.status = "error";
                            result.message = "Please Used OTP For First Time Login Then Set The New Password";
                            return result;
                        }
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "The Username " + obj.dUsername + " Is Not Available.. Please Enter Correct Username";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }

        }



        public async Task<CommonAPIResponse> ResetHotelPassAsync(ResetHotelPassBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            //Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.UserId == obj.hUsername && c.Password == obj.oldPass).FirstOrDefaultAsync();

                    if (hotelrefdetails != null)
                    {
                        hotelrefdetails.Password = obj.newPass;

                        await db.SaveChangesAsync();

                        result.code = 200;
                        result.status = "success";
                        result.message = "Your Password Has Changed Successfully";

                        return result;

                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "The Username " + obj.hUsername + " Is Not Available.. Please Enter Correct Username";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }


        public async Task<CommonAPIResponse> ForgetHotelPassStep2Async(PasswordRecoveryBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            //Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    if (obj.otpstatus == false)
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Please Send The OTP Verification Status.";
                        return result;
                    }
                    else
                    {
                        var hotelrefdetails = await db.Hotels.Where(c => c.UserId == obj.hUserId && c.UserId != null).FirstOrDefaultAsync();

                        if (hotelrefdetails != null)
                        {
                            if (hotelrefdetails.Password != obj.hPassword)
                            {
                                hotelrefdetails.Password = obj.hPassword;
                                await db.SaveChangesAsync();
                                result.code = 200;
                                result.status = "success";
                                result.message = "Your New Password Is " + obj.hPassword;
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Please Enter Different Password.";
                            }

                            return result;

                        }
                        else
                        {
                            result.code = 200;
                            result.status = "error";
                            result.message = "The Username " + obj.hUserId + " Is Not Available.. Please Enter Correct Username";
                            return result;
                        }
                        //return result;
                    }

                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }


                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }



        public async Task<CommonAPIResponse> ForgetDeptPassStep2Async(DeptPasswordRecoveryBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            //Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    if (obj.otpstatus == false)
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Please Send The OTP Verification Status.";
                        return result;
                    }
                    else
                    {
                        var deptrefdetails = await db.Polices.Where(c => c.UserId == obj.dUserId && c.UserId != null).FirstOrDefaultAsync();

                        if (deptrefdetails != null)
                        {
                            if (deptrefdetails.Password != obj.dPassword)
                            {
                                deptrefdetails.Password = obj.dPassword;
                                await db.SaveChangesAsync();
                                result.code = 200;
                                result.status = "success";
                                result.message = "Your New Password Is " + obj.dPassword;
                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Please Enter Different Password.";
                            }

                            return result;

                        }
                        else
                        {
                            result.code = 200;
                            result.status = "error";
                            result.message = "The Username " + obj.dUserId + " Is Not Available.. Please Enter Correct Username";
                            return result;
                        }
                        //return result;
                    }

                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }


                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }


        public async Task<CommonAPIResponse> CheckAuthPinAsync(string authPin)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var checkauthPin = await db.AuthenticationPins.Where(c => c.AuthPin == authPin).FirstOrDefaultAsync();

                    if (checkauthPin != null)
                    {
                        if (checkauthPin.IsUse == true)
                        {
                            result.code = 200;
                            result.status = "error";
                            result.message = authPin + " Is Already Used";
                            return result;
                        }
                        else
                        {
                            result.code = 200;
                            result.status = "success";
                            result.message = authPin + " Is Available";
                            return result;
                        }
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = authPin + " Not Available";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    result.code = 200;
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }


        public async Task<CommonAPIResponse> CheckHotelRegExistAsync(string hotelRegNumber)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.HotelRegNo == hotelRegNumber).FirstOrDefaultAsync();

                    if (hotelrefdetails != null)
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = hotelRegNumber + " Is Already Exist";
                        return result;

                    }
                    else
                    {
                        result.code = 200;
                        result.status = "success";
                        result.message = hotelRegNumber + " Is Available";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    result.code = 200;
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }





        public async Task<CommonAPIResponse> CheckUsernameExistAsync(string userid)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.UserId == userid).FirstOrDefaultAsync();
                    var detrefdetails = await db.Polices.Where(c => c.UserId == userid).FirstOrDefaultAsync();

                    if (hotelrefdetails != null || detrefdetails != null)
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = userid + " Is Already Exist";
                        return result;

                    }
                    else
                    {
                        result.code = 200;
                        result.status = "success";
                        result.message = userid + " Is Available";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    result.code = 200;
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }


        public async Task<CheckHotelUsernameRes> ForgetHotePassStep1Async(string username, string mobileno)
        {
            CheckHotelUsernameRes result = new CheckHotelUsernameRes();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.UserId == username).FirstOrDefaultAsync();

                    if (hotelrefdetails != null)
                    {
                        if (hotelrefdetails.Mobile == mobileno)
                        {
                            Random random = new Random();
                            //string otp = random.Next(000001, 999999).ToString();
                            int randomotp = random.Next(100000, 1000000);
                            string otp = randomotp.ToString("D6");
                            string msg = "Your OTP is " + otp + ". Do not Share it with anyone by any means. This is confidential and to be used by you only. ICTSBM";

                            if (hotelrefdetails.Mobile != null)
                            {
                                //sendSMS(msg, hotelrefdetails.Mobile);

                                Task<string> myTask = sendSMSasync(msg, mobileno);

                                string input = myTask.Result;
                                // Define a regular expression pattern
                                string pattern = @"\d+\s+(.*?)<br>";
                                string status = "";
                                // Match the pattern in the input string
                                Match match = Regex.Match(input, pattern);

                                // Check if the match was successful
                                if (match.Success)
                                {
                                    // Extract the captured group
                                    status = match.Groups[1].Value;

                                    // Output the result
                                    //Console.WriteLine(status);
                                }
                                else
                                {
                                    status = match.Groups[1].Value;
                                }

                                //string[] myStr = myTask.Result.Split(" ");

                                //string mono = "";
                                //string status1 = "";
                                //if (myStr.Length == 2)
                                //{
                                //    mono = myStr[0];
                                //    status1 = myStr[1];
                                //}





                                if (status == "DELIVRD")
                                {
                                    result.code = 200;
                                    result.otp = otp;
                                    result.status = "success";
                                    result.userid = username;
                                    result.message = "OTP sent successfully to your Registered Mobile Number." + status;
                                    return result;
                                }
                                else if (status == "NCPR")
                                {
                                    result.code = 200;
                                    result.otp = "";
                                    result.status = "error";
                                    result.userid = username;
                                    result.message = "Please Deactivate Do Not Disturb(DND) of your Registered Mobile Number." + status;
                                    return result;
                                }
                                else
                                {
                                    result.code = 200;
                                    result.otp = "";
                                    result.status = "error";
                                    result.userid = username;
                                    result.message = "SMS Status is" + status;
                                    return result;
                                }
                            }
                            else
                            {
                                result.code = 200;
                                result.otp = "";
                                result.userid = username;
                                result.status = "error";
                                result.message = "Mobile Number Not Avilable to the User.";
                                return result;
                            }
                        }
                        else
                        {
                            result.code = 200;
                            result.otp = "";
                            result.userid = username;
                            result.status = "error";
                            result.message = "Please Enter Registered Mobile Number.";
                            return result;
                        }


                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.userid = username;
                        result.message = username + " Is Not Exist";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    result.code = 200;
                    result.status = "error";
                    result.userid = username;
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }



        public async Task<CheckDeptUsernameRes> ForgetDeptPassStep1Async(string username, string mobileno)
        {
            CheckDeptUsernameRes result = new();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var deptrefdetails = await db.Polices.Where(c => c.UserId == username).FirstOrDefaultAsync();

                    if (deptrefdetails != null)
                    {
                        if (deptrefdetails.Mobile == mobileno)
                        {
                            Random random = new Random();
                            //string otp = random.Next(000001, 999999).ToString();
                            int randomotp = random.Next(100000, 1000000);
                            string otp = randomotp.ToString("D6");

                            string msg = "Your OTP is " + otp + ". Do not Share it with anyone by any means. This is confidential and to be used by you only. ICTSBM";

                            if (deptrefdetails.Mobile != null)
                            {
                                //sendSMS(msg, hotelrefdetails.Mobile);

                                Task<string> myTask = sendSMSasync(msg, mobileno);

                                string input = myTask.Result;
                                // Define a regular expression pattern
                                string pattern = @"\d+\s+(.*?)<br>";
                                string status = "";
                                // Match the pattern in the input string
                                Match match = Regex.Match(input, pattern);

                                // Check if the match was successful
                                if (match.Success)
                                {
                                    // Extract the captured group
                                    status = match.Groups[1].Value;

                                    // Output the result
                                    //Console.WriteLine(status);
                                }

                                //string[] myStr = myTask.Result.Split(" ");

                                //string mono = "";
                                //string status1 = "";
                                //if (myStr.Length == 2)
                                //{
                                //    mono = myStr[0];
                                //    status1 = myStr[1];
                                //}

                                if (status == "DELIVRD")
                                {
                                    result.code = 200;
                                    result.otp = otp;
                                    result.userid = username;
                                    result.status = "success";
                                    result.message = "OTP sent successfully to your Registered Mobile Number.";
                                    return result;
                                }
                                else if (status == "NCPR")
                                {
                                    result.code = 200;
                                    result.otp = "";
                                    result.userid = username;
                                    result.status = "error";
                                    result.message = "Please Deactivate Do Not Disturb(DND) of your Registered Mobile Number.";
                                    return result;
                                }
                                else
                                {
                                    result.code = 200;
                                    result.otp = "";
                                    result.userid = username;
                                    result.status = "error";
                                    result.message = "SMS Status is" + status;
                                    return result;
                                }
                            }
                            else
                            {
                                result.code = 200;
                                result.otp = "";
                                result.userid = username;
                                result.status = "error";
                                result.message = "Mobile Number Not Avilable to the User.";
                                return result;
                            }
                        }
                        else
                        {
                            result.code = 200;
                            result.otp = "";
                            result.userid = username;
                            result.status = "error";
                            result.message = "Please Enter Registered Mobile Number.";
                            return result;
                        }


                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = username + " Is Not Exist";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    result.code = 200;
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }



        public void sendSMS(string sms, string MobilNumber)
        {
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.smsjust.com/sms/user/urlsms.php?username=artiyocc&pass=123456&senderid=ICTSBM&dest_mobileno=" + MobilNumber + "&message=" + sms + "%20&response=Y");

                //Get response from Ozeki NG SMS Gateway Server and read the answer
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }
                if (w32ex != null)
                {
                    int code = w32ex.ErrorCode;
                    // do stuff
                }
                Log.Error(ex.Message);
            }

        }

        public async Task<VerifyMobileNo> VerifyMobileNoAsync(string mobileno)
        {
            VerifyMobileNo result = new();
            try
            {

                Random random = new();
                //string otp = random.Next(000001, 999999).ToString();
                int randomotp = random.Next(100000, 1000000);
                string otp = randomotp.ToString("D6");

                string msg = "Your OTP is " + otp + ". Do not Share it with anyone by any means. This is confidential and to be used by you only. ICTSBM";

                //smsStatus smsapiRes = new ();

                //sendSMS(msg, mobileno);
                //string smsresult = await sendSMSasync(msg, mobileno);

                Task<string> myTask = sendSMSasync(msg, mobileno);
                string input = myTask.Result;
                // Define a regular expression pattern
                string pattern = @"\d+\s+(.*?)<br>";
                string status = "";
                // Match the pattern in the input string
                Match match = Regex.Match(input, pattern);

                // Check if the match was successful
                if (match.Success)
                {
                    // Extract the captured group
                    status = match.Groups[1].Value;

                    // Output the result
                    //Console.WriteLine(status);
                }

                //string[] myStr = myTask.Result.Split(" ");

                //string mono = "";
                //string status1 = "";
                //if (myStr.Length == 2)
                //{
                //    mono = myStr[0];
                //    status1 = myStr[1];
                //}

                if (status == "DELIVRD")
                {
                    result.code = 200;
                    result.otp = otp;
                    result.status = "success";
                    result.message = "OTP sent successfully to your Registered Mobile Number." + status;
                    return result;
                }
                else if (status == "NCPR")
                {
                    result.code = 200;
                    result.otp = "";
                    result.status = "error";
                    result.message = "Please Deactivate Do Not Disturb(DND) of your Registered Mobile Number." + status;
                    return result;
                }
                else
                {
                    result.code = 200;
                    result.otp = "";
                    result.status = "error";
                    result.message = "SMS Status is" + status;
                    return result;
                }
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }
                if (w32ex != null)
                {
                    result.code = w32ex.ErrorCode;
                    // do stuff
                }
                result.otp = "";
                result.status = "error";
                result.message = "OTP sent Failed.";
                Log.Error(ex.Message);
                return result;
            }
        }

        async Task<string> sendSMSasync(string sms, string MobilNumber)
        {
            string smsresponse = "";
            string sms_status = "";
            string smsuri = "https://www.smsjust.com/sms/user/urlsms.php?username=artiyocc&pass=123456&senderid=ICTSBM&dest_mobileno=" + MobilNumber + "&message=" + sms + "%20&response=Y";
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(smsuri);

            if (responseMessage.IsSuccessStatusCode)
            {
                smsresponse = await responseMessage.Content.ReadAsStringAsync();

                await Task.Delay(TimeSpan.FromSeconds(10));
                string smsresuri = "https://www.smsjust.com/sms/user/response.php?Scheduleid=" + smsresponse.Trim();
                HttpResponseMessage responseMessage_Status = await client.GetAsync(smsresuri);

                if (responseMessage_Status.IsSuccessStatusCode)
                {
                    sms_status = await responseMessage_Status.Content.ReadAsStringAsync();

                    //string[] myStr = sms_status.Split(" ");

                    //string mono = myStr[0];
                    //string status = myStr[1];
                    return sms_status;

                }

            }
            return sms_status;
        }




        public async Task<CommonAPIResponse> SaveHotelGuestReg(HotelGuestRegistration obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            HotelGuest hgdetails = new();


            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var guestreg = await db.Hotels.Where(c => c.HotelRegNo == obj.HotelRegNo).FirstOrDefaultAsync();

                    if (guestreg != null)
                    {
                        hgdetails.Date = DateTime.Now;
                        hgdetails.HotelRegNo = obj.HotelRegNo;
                        hgdetails.GuestName = obj.GuestName;
                        hgdetails.NumberOfGuest = obj.NumberOfGuest;
                        hgdetails.GuestType = obj.GuestType;
                        hgdetails.Age = obj.Age;
                        hgdetails.Gender = obj.Gender;
                        hgdetails.Mobile = obj.Mobile;
                        hgdetails.Email = obj.Email;
                        hgdetails.CheckInDate = DateTime.Now;
                        //hgdetails.CheckOutDate = Convert.ToDateTime(obj.CheckOutDate);
                        hgdetails.VisitPurpose = obj.VisitPurpose;
                        hgdetails.RoomType = obj.RoomType;
                        hgdetails.RoomNo = obj.RoomNo;
                        hgdetails.Country = obj.Country;
                        hgdetails.State = obj.State;
                        hgdetails.City = obj.City;
                        // hgdetails.Address = obj.Address;
                        hgdetails.ComingFrom = obj.ComingFrom;
                        hgdetails.GuestIdType = obj.GuestIdType;
                        hgdetails.PaymentMode = obj.PaymentMode;

                        List<AddOnGuest>? add = obj.AddOnGuest;

                        if ((string.IsNullOrEmpty(obj.GuestPhoto)) == false)
                        {
                            // house.BinaryQrCodeImage = Convert.FromBase64String(obj.QRCodeImage.Substring(obj.QRCodeImage.LastIndexOf(',') + 1));
                            Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                            obj.GuestPhoto = regex.Replace(obj.GuestPhoto, string.Empty);
                            obj.GuestPhoto = obj.GuestPhoto.Replace("data:image/jpeg;base64,", string.Empty);
                            hgdetails.GuestPhoto = Convert.FromBase64String(obj.GuestPhoto);
                        }
                        if ((string.IsNullOrEmpty(obj.GuestIDProof)) == false)
                        {
                            // house.BinaryQrCodeImage = Convert.FromBase64String(obj.QRCodeImage.Substring(obj.QRCodeImage.LastIndexOf(',') + 1));
                            Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                            obj.GuestIDProof = regex.Replace(obj.GuestIDProof, string.Empty);
                            obj.GuestIDProof = obj.GuestIDProof.Replace("data:image/jpeg;base64,", string.Empty);
                            hgdetails.GuestIdproof = Convert.FromBase64String(obj.GuestIDProof);
                        }

                        Random random = new();
                        string roomb = random.Next(0000000001, 999999999).ToString();

                        hgdetails.RoomBookingId = roomb;

                        db.HotelGuests.Add(hgdetails);
                        await db.SaveChangesAsync();

                        if (add != null)
                        {
                            var checkBookingID = await db.HotelGuests.Where(c => c.RoomBookingId == roomb).FirstOrDefaultAsync();
                            if (checkBookingID != null)
                            {
                                var regno = checkBookingID.RoomBookingId.ToString();
                                DateTime date = Convert.ToDateTime(checkBookingID.Date);

                                foreach (var c in add)
                                {
                                    AddHotelGuest addOnGuest = new();

                                    addOnGuest.RoomBookingId = regno;
                                    addOnGuest.Date = date;
                                    addOnGuest.HotelRegNo = obj.HotelRegNo;
                                    addOnGuest.GuestName = c.GuestName;
                                    addOnGuest.Age = c.Age;
                                    addOnGuest.Gender = c.Gender;
                                    addOnGuest.Mobile = c.Mobile;
                                    addOnGuest.Email = c.Email;
                                    addOnGuest.Country = c.Country;
                                    addOnGuest.State = c.State;
                                    addOnGuest.City = c.City;
                                    // addOnGuest.Address = c.Address;
                                    addOnGuest.ComingFrom = c.ComingFrom;
                                    addOnGuest.GuestType = c.GuestType;
                                    addOnGuest.RelationWithGuest = c.RelationWithGuest;
                                    addOnGuest.GuestIdType = c.GuestIdType;

                                    if ((string.IsNullOrEmpty(c.GuestPhoto)) == false)
                                    {
                                        // house.BinaryQrCodeImage = Convert.FromBase64String(obj.QRCodeImage.Substring(obj.QRCodeImage.LastIndexOf(',') + 1));
                                        Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                                        c.GuestPhoto = regex.Replace(c.GuestPhoto, string.Empty);
                                        c.GuestPhoto = c.GuestPhoto.Replace("data:image/jpeg;base64,", string.Empty);
                                        addOnGuest.GuestPhoto = Convert.FromBase64String(c.GuestPhoto);
                                    }
                                    if ((string.IsNullOrEmpty(c.GuestIDProof)) == false)
                                    {
                                        // house.BinaryQrCodeImage = Convert.FromBase64String(obj.QRCodeImage.Substring(obj.QRCodeImage.LastIndexOf(',') + 1));
                                        Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                                        c.GuestIDProof = regex.Replace(c.GuestIDProof, string.Empty);
                                        c.GuestIDProof = c.GuestIDProof.Replace("data:image/jpeg;base64,", string.Empty);
                                        addOnGuest.GuestIdproof = Convert.FromBase64String(c.GuestIDProof);
                                    }



                                    db.AddHotelGuests.Add(addOnGuest);
                                    await db.SaveChangesAsync();


                                }

                                result.code = 200;
                                result.status = "success";
                                result.message = "Registration Details Saved Successfully!";
                                return result;

                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "Booking ID Not Generated!";
                                return result;
                            }

                        }
                        else
                        {
                            result.code = 200;
                            result.status = "success";
                            result.message = "Registration Details Saved Successfully!";
                            return result;
                        }


                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Hotel Not Registred!";
                        return result;
                    }
                    //return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }

        }




        // CheckOutGuestAsync

        public async Task<HotelCheckInListResult> CheckGuestInOutStatusAsync(string hotelRegNo)
        {
            HotelCheckInListResult result = new();
            List<GuestInOutStatusResponse> guestres = new();
            List<GuestDetailsList> guestDetailsList = new();
            List<MonthlyCheckInOutCount> monthlyCheckInOutCounts = new();
            HotelGuest obj = new();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var checkhregno = await db.Hotels.Where(x => x.HotelRegNo == hotelRegNo).FirstOrDefaultAsync();
                    if (checkhregno != null)
                    {
                        DateTime date = DateTime.Now;
                        var totalGuest = await db.HotelGuests.Where(guest => guest.CheckOutDate == null && guest.HotelRegNo == hotelRegNo).Select(guest => guest.Id).ToListAsync();
                        var todayCIN = await db.HotelGuests.Where(guest => guest.CheckOutDate == null && DateTime.Compare(guest.CheckInDate.Value.Date, date) <= 0 && guest.HotelRegNo == hotelRegNo).Select(guest => guest.Id).ToListAsync();
                        var todayCOUT = await db.HotelGuests.Where(guest => DateTime.Compare(guest.CheckOutDate.Value.Date, date) == 0 && guest.HotelRegNo == hotelRegNo).Select(guest => guest.Id).ToListAsync();

                        List<SqlParameter> parms = new List<SqlParameter>
                            {
                            // Create parameter(s)
                            new SqlParameter { ParameterName = "@HotelRegNo", Value = hotelRegNo },

                            };
                        var checkInListdata = await db.Hotel_CheckInList_Results.FromSqlRaw<Hotel_CheckInList_Result>("EXEC Hotel_CheckInList @HotelRegNo", parms.ToArray()).ToListAsync();
                        foreach (var i in checkInListdata)
                        {
                            var res = (i.Total_Adult == 1 && i.Total_Child == 0) ? i.Total_Adult.ToString() + " Adult " :
                                 (i.Total_Adult == 1 && i.Total_Child == 1) ? i.Total_Adult.ToString() + " Adult & " + i.Total_Child.ToString() + " Child" :
                                 (i.Total_Adult > 1 && i.Total_Child > 1) ? i.Total_Adult.ToString() + " Adults & " + i.Total_Child.ToString() + " Childs" :
                                 (i.Total_Adult > 1 && i.Total_Child == 1) ? i.Total_Adult.ToString() + " Adults & " + i.Total_Child.ToString() + " Child" :
                                 (i.Total_Adult > 1 && i.Total_Child == 0) ? i.Total_Adult.ToString() + " Adults " :
                                 (i.Total_Adult == 1 && i.Total_Child > 1) ? i.Total_Adult.ToString() + " Adult & " + i.Total_Child.ToString() + " Childs" :
                                 "No Guest Found!";
                            guestDetailsList.Add(new GuestDetailsList
                            {
                                guestName = i.GuestName,
                                guestPhoto = Convert.ToBase64String(i.GuestPhoto),
                                mobile = i.Mobile,
                                country = i.Country,
                                state = i.State,
                                checkInDate = i.CheckInDate.ToString("dd MMM ddd yyyy HH:mm tt"),
                                reservation = res,
                                //  totalAdult = i.Total_Adult,
                                // totalChild = i.Total_Child,
                            });

                        }
                        var count = await db.Hotel_MonthlyCheckInOutCount_Results.FromSqlRaw<Hotel_MonthlyCheckInOutCount_Result>("EXEC Hotel_MonthlyCheckInOutCount @HotelRegNo", parms.ToArray()).ToListAsync();
                        foreach (var i in count)
                        {
                            monthlyCheckInOutCounts.Add(new MonthlyCheckInOutCount
                            {
                                month = i.Month,
                                monthName = i.MonthName,
                                checkInCount = i.CheckInCount,
                                checkOutCount = i.CheckOutCount,
                            });
                        }

                        guestres.Add(new GuestInOutStatusResponse
                        {
                            totalGuest = totalGuest.Count(),
                            todaysCheckIn = todayCIN.Count(),
                            todaysCheckOut = todayCOUT.Count(),
                            guestDetails = guestDetailsList,
                            monthlyCheckInOutCounts = monthlyCheckInOutCounts,
                        });

                        result.code = 200;
                        result.status = "success";
                        result.message = "Success Response";
                        result.data = guestres;


                        return result;
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Hotel Registration Number Not Found!";
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }



        public async Task<RelationsList> GetRelationAsync()
        {
            RelationsList result = new();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var rel = await db.Relations.AsQueryable().Select(x => new {x.Id, x.Name}).ToListAsync();
                    result.code = 200;
                    result.status= "success";
                    result.message = "Relation List";
                    result.data = rel;

                    return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;
                }

            }
        }

        public async Task<VisitPurposeList> GetVisitPurposeAsync()
        {
            VisitPurposeList result = new();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var vp = await db.VisitPurposes.AsQueryable().Select(x => new {x.Id,x.Purpose,}).ToListAsync();
                    result.code = 200;
                    result.status = "success";
                    result.message = "Visit Purpose List";
                    result.data = vp;

                    return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;
                }

            }
        }

        public async Task<SelectIDTypeList> GetSelectIDTypeAsync()
        {
            SelectIDTypeList result = new();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var vp = await db.IdProofTypes.AsQueryable().Select(x => new { id = x.Id, idProofType = x.IdType,}).ToListAsync();
                    result.code = 200;
                    result.status = "success";
                    result.message = "ID Proof Type List";
                    result.data = vp;

                    return result;
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;
                }

            }
        }





        public async Task<DeptDashboardRes> DepartmentDashboardAsync(string userID)
        {
            DeptDashboardRes result = new();
            List<HotelLocOnDashboard> hotelLocOnDashboard = new();
            List<HotelListDetailsForDashboard> hotelListDetailsForDashboard = new();
            List<HotelGuestDetails_DeptDash1> hotelGuestDetails_DeptDashes = new();
            List<HotelGuestDetails_DeptDash2> hotelGuestDetails_DeptDash2 = new();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var stateid = await db.Polices.Where(x => x.UserId == userID).Select(x => x.StateId).FirstOrDefaultAsync();
                    var distid = await db.Polices.Where(x => x.UserId == userID).Select(x => x.DistId).FirstOrDefaultAsync();
                    var cityid = await db.Polices.Where(x => x.UserId == userID).Select(x => x.CityId).FirstOrDefaultAsync();
                    var stationid = await db.Polices.Where(x => x.UserId == userID).Select(x => x.StationCode).FirstOrDefaultAsync();

                    var checkuser = await db.Polices.Where(x => x.UserId == userID).FirstOrDefaultAsync();
                    var usertype = await db.Polices.Where(x => x.UserId == userID).Select(x => x.UserType).FirstOrDefaultAsync();

                    List<SqlParameter> parms = new List<SqlParameter>
                            {
                            // Create parameter(s)
                            new SqlParameter { ParameterName = "@DepartUsername", Value = userID },
                            };

                    var checkloc = await db.HotelLocForDepartDash_Results.FromSqlRaw<HotelLocForDepartDash_Result>("EXEC HotelLocForDepartDash @DepartUsername", parms.ToArray()).ToListAsync();
                    foreach (var i in checkloc)
                    {
                        hotelLocOnDashboard.Add(new HotelLocOnDashboard
                        {
                            hotelName = i.HotelName,
                            Mobile = i.Mobile,
                            Address = i.Address,
                            lat = i.Lat,
                            _long = i.Long,
                        });
                        result.hotelLocOnDashboard = hotelLocOnDashboard;
                    }

                    var details = await db.HotelListDetailsForDepart_Results.FromSqlRaw<HotelListDetailsForDepart_Result>("EXEC HotelListDetailsForDepart @DepartUsername", parms.ToArray()).ToListAsync();
                    foreach (var i in details)
                    {
                        hotelListDetailsForDashboard.Add(new HotelListDetailsForDashboard
                        {
                            stationName = i.StationName,
                            hotelCount = i.Hotel_Count,
                            totalCheckIn = i.Total_CheckIn,
                            todaysCheckIn = i.Today_CheckIn,
                            todaysCheckOut = i.Today_CheckOut,

                        });
                        result.hotelListDetailsForDashboards = hotelListDetailsForDashboard;
                    }
                    //Hotel Guest Dashboard Details
                    var hotelGuestDetails = await db.HotelGuestDetails_DeptDash_Results.FromSqlRaw<HotelGuestDetails_DeptDash_Result>("EXEC HotelGuestDetails_DeptDash @DepartUsername", parms.ToArray()).ToListAsync();
                    foreach (var i in hotelGuestDetails)
                    {
                        var res = (i.Total_Adult == 1 && i.Total_Child == 0) ? i.Total_Adult.ToString() + " Adult " :
                                  (i.Total_Adult == 1 && i.Total_Child == 1) ? i.Total_Adult.ToString() + " Adult & " + i.Total_Child.ToString() + " Child" :
                                  (i.Total_Adult > 1 && i.Total_Child > 1) ? i.Total_Adult.ToString() + " Adults & " + i.Total_Child.ToString() + " Childs" :
                                  (i.Total_Adult > 1 && i.Total_Child == 1) ? i.Total_Adult.ToString() + " Adults & " + i.Total_Child.ToString() + " Child" :
                                  (i.Total_Adult > 1 && i.Total_Child == 0) ? i.Total_Adult.ToString() + " Adults " :
                                  (i.Total_Adult == 1 && i.Total_Child > 1) ? i.Total_Adult.ToString() + " Adult & " + i.Total_Child.ToString() + " Childs" :
                                  "No Guest Found!";

                        hotelGuestDetails_DeptDashes.Add(new HotelGuestDetails_DeptDash1
                        {
                            roomBookingID = i.RoomBookingID,
                            guestName = i.GuestName,
                            guestPhoto = i.GuestPhoto,
                            age = i.Age,
                            city = i.City,
                            visitPurpose = i.VisitPurpose,
                            comingFrom = i.ComingFrom,
                            reservation = res,
                            hotelName = i.HotelName,
                            checkInDate = i.CheckInDate,
                        });
                        result.hotelGuestDetails_DeptDashes = hotelGuestDetails_DeptDashes;


                    }

                    var hotelGuestDetails1 = await db.HotelGuestDetails_DeptDash_Results1.FromSqlRaw<HotelGuestDetails_DeptDash_Result1>("EXEC HotelGuestDetails_DeptDash1 @DepartUsername", parms.ToArray()).ToListAsync();
                    foreach (var i in hotelGuestDetails1)
                    {
                        var res = (i.Total_Adult == 1 && i.Total_Child == 0) ? i.Total_Adult.ToString() + " Adult " :
                           (i.Total_Adult == 1 && i.Total_Child == 1) ? i.Total_Adult.ToString() + " Adult & " + i.Total_Child.ToString() + " Child" :
                           (i.Total_Adult > 1 && i.Total_Child > 1) ? i.Total_Adult.ToString() + " Adults & " + i.Total_Child.ToString() + " Childs" :
                           (i.Total_Adult > 1 && i.Total_Child == 1) ? i.Total_Adult.ToString() + " Adults & " + i.Total_Child.ToString() + " Child" :
                           (i.Total_Adult > 1 && i.Total_Child == 0) ? i.Total_Adult.ToString() + " Adults " :
                           (i.Total_Adult == 1 && i.Total_Child > 1) ? i.Total_Adult.ToString() + " Adult & " + i.Total_Child.ToString() + " Childs" :
                           "No Guest Found!";

                        hotelGuestDetails_DeptDash2.Add(new HotelGuestDetails_DeptDash2
                        {
                            hotelName = i.HotelName,
                            guestName = i.GuestName,
                            age = i.Age,
                            visitPurpose = i.VisitPurpose,
                            comingFrom = i.ComingFrom,
                            reservation = res,
                            mobile = i.Mobile,
                            city = i.City,
                            checkInDate = i.CheckInDate,
                        });
                        result.hotelGuestDetails_DeptDash2 = hotelGuestDetails_DeptDash2;
                    }

                    if (checkuser != null)
                    {
                        if (usertype != null)
                        {
                            if (usertype == "1")
                            {
                                var loc = await db.States.Where(x => x.StateId == stateid).Select(x => x.StateName).FirstOrDefaultAsync();

                                result.code = 200;
                                result.status = "success";
                                result.message = "Success Response";
                                result.stationName = loc + " State";
                                return result;
                            }
                            else if (usertype == "2")
                            {
                                var loc = await db.Districts.Where(x => x.DistId == distid).Select(x => x.DistName).FirstOrDefaultAsync();

                                result.code = 200;
                                result.status = "success";
                                result.message = "Success Response";
                                result.stationName = loc + " District ";
                                return result;

                            }
                            else if (usertype == "3")
                            {

                                var loc = await db.Cities.Where(x => x.CityId == cityid).Select(x => x.CityName).FirstOrDefaultAsync();

                                result.code = 200;
                                result.status = "success";
                                result.message = "Success Response";
                                result.stationName = loc + " City";
                                return result;

                            }
                            else if (usertype == "4")
                            {

                                var loc = await db.PoliceStations.Where(x => x.Id == Convert.ToInt32(stationid)).Select(x => x.StationName).FirstOrDefaultAsync();

                                result.code = 200;
                                result.status = "success";
                                result.message = "Success Response";
                                result.stationName = loc;
                                return result;

                            }
                            else
                            {
                                result.code = 200;
                                result.status = "error";
                                result.message = "User Type ID Not Found";
                                result.stationName = null;
                                return result;
                            }


                        }
                        else
                        {
                            result.code = 200;
                            result.status = "error";
                            result.message = "User Type Not Found!";
                            result.stationName = null;
                            return result;
                        }

                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "UserID Not Found!";
                        return result;
                    }


                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;

                }
            }
        }




        public async Task<ShowHotelGuestDetailsRes> ShowHotelGuestDetailsAsync(string roomBookingID)
        {
            ShowHotelGuestDetailsRes result = new ShowHotelGuestDetailsRes();

            List<GuestDetails> hotelGuestDetails = new List<GuestDetails>();
            List<AddOnGuestDetails> addguestDetails = new List<AddOnGuestDetails>();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                    {
                         new SqlParameter { ParameterName = "@RoomBookingID", Value = roomBookingID },
                    };

                    var data = await db.ShowHotelGuestDetails_Results.FromSqlRaw<ShowHotelGuestDetails_Result>("EXEC ShowHotelGuestDetails @RoomBookingID", parms.ToArray()).ToListAsync();
                    {
                        foreach (var i in data)
                        {
                            if (i.RelationWithGuest == "SELF")
                            {
                                hotelGuestDetails.Add(new GuestDetails
                                {
                                    roomBookingId = i.RoomBookingId,
                                    guestName = i.GuestName,
                                    email = i.Email,
                                    mobile = i.Mobile,
                                    gender = i.Gender,
                                    age = i.Age,
                                    country = i.Country,
                                    city = i.City,
                                    address = i.Address,
                                    guestPhoto = i.GuestPhoto,
                                });
                                result.hotelGuestDetails = hotelGuestDetails;
                            }
                            else
                            {
                                addguestDetails.Add(new AddOnGuestDetails
                                {
                                    relationWithGuest = i.RelationWithGuest,
                                    guestName = i.GuestName,
                                });
                                result.addOnGuestDetails1 = addguestDetails;
                            }
                        }
                    }
                    result.code = 200;
                    result.status = "success";
                    result.message = "Success Response";
                    result.hotelGuestDetails = hotelGuestDetails;
                    result.addOnGuestDetails1 = addguestDetails;
                    return result;

                }

                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;
                }
            }

        }

        public async Task<CommonAPIResponse> CheckOutGuestAsync(string roomBookingID)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var outguest = await db.HotelGuests.Where(c => c.RoomBookingId == roomBookingID && c.CheckOutDate == null).FirstOrDefaultAsync();

                    if (outguest != null)
                    {
                        outguest.CheckOutDate = DateTime.Now;
                        await db.SaveChangesAsync();

                        result.code = 200;
                        result.status = "success";
                        result.message = "Cheking Out Successful";
                        return result;
                    }
                    else
                    {
                        result.code = 200;
                        result.status = "error";
                        result.message = "Check Out Failed";
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = ex.InnerException as Win32Exception;
                    }
                    if (w32ex != null)
                    {
                        result.code = w32ex.ErrorCode;
                        // do stuff
                    }
                    result.status = "error";
                    result.message = ex.Message;
                    Log.Error(ex.Message);
                    return result;
                }
            }
        }
    }
}
