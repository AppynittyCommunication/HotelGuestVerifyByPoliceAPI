using HotelGuestVerifyByPolice.DataContext.Data;
using HotelGuestVerifyByPolice.DataContext.Entities;
using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels;
using HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
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

                        Random random = new Random();
                        string r = random.Next(000001,999999).ToString();

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
                        stateName = x.StateName,

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

        public async Task<List<DepartmentTypeList>> getDepartmentTypeListAsync()
        {
            List<DepartmentTypeList> depttypelist = new List<DepartmentTypeList>();
            try
            {
                using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
                {
                    var st = await db.DepartmentTypes.AsQueryable().Where(c => c.IsActive == true).Select(x => new DepartmentTypeList
                    {
                        departmentTypeID = x.Id,
                        departmentTypeName = x.DeptTypeName,

                    }).ToListAsync();
                    depttypelist = st;
                }
                return depttypelist;
            }
            catch (Exception)
            {
                return depttypelist;
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
                        distName = x.DistName,

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
                            if(hotelrefdetails.Otp == obj.hPassword)
                            {
                                if(hotelrefdetails.Otpuse == null)
                                {
                                    hotelrefdetails.Otpuse = 1;
                                }
                                else
                                {
                                    int a = (int)hotelrefdetails.Otpuse;
                                    hotelrefdetails.Otpuse = a + 1 ;
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
                                result.message = "Login Failed.. You Entered Wrong OTP!";
                                result.otp = false;
                                result.data = "";
                                return result;
                            }
                       }
                        else
                        {
                            if(hotelrefdetails.Password == obj.hPassword)
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
                        result.message = "The Username "+obj.hUsername+" Is Not Available.. Please Enter Correct Username";
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
                        if(hotelrefdetails.Otpuse != null)
                        {
                            if(hotelrefdetails.Password == null || hotelrefdetails.Password == "")
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
                            result.code=200;
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
                    return result;

                }
            }
            
        }

        public async Task<CommonAPIResponse> ResetHotelPass(ResetHotelPassBody obj)
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
                    return result;

                }
            }
        }


        public async Task<CommonAPIResponse> passwordRecoveryResponse(PasswordRecoveryBody obj)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            //Hotel hoteldetails = new Hotel();

            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    if(obj.otpstatus == false)
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
                    return result;

                }
            }
        }



        public async Task<CommonAPIResponse> checkHotelRegExistAsync(string hotelRegNumber)
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
                    return result;

                }
            }
        }

        public async Task<CommonAPIResponse> checkDepartUsernameExistAsync(string userid)
        {
            CommonAPIResponse result = new CommonAPIResponse();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Polices.Where(c => c.UserId == userid).FirstOrDefaultAsync();

                    if (hotelrefdetails != null)
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
                    return result;

                }
            }
        }
        public async Task<CheckHotelUsernameRes> checkHotelUsernameExistAsync(string username, string mobileno)
        {
            CheckHotelUsernameRes result = new CheckHotelUsernameRes();
            using (HotelGuestVerifyByPoliceEntities db = new HotelGuestVerifyByPoliceEntities())
            {
                try
                {
                    var hotelrefdetails = await db.Hotels.Where(c => c.UserId == username).FirstOrDefaultAsync();

                    if (hotelrefdetails != null)
                    {
                        if(hotelrefdetails.Mobile == mobileno)
                        {
                            Random random = new Random();
                            string otp = random.Next(000001, 999999).ToString();

                            string msg = "Your OTP is " + otp + ". Do not Share it with anyone by any means. This is confidential and to be used by you only. ICTSBM";

                            if (hotelrefdetails.Mobile != null)
                            {
                                //sendSMS(msg, hotelrefdetails.Mobile);

                                Task<string> myTask = sendSMSasync(msg, mobileno);


                                string status = myTask.Result.Replace("<br>", "");

                                if (status == "DELIVRD")
                                {
                                    result.code = 200;
                                    result.otp = otp;
                                    result.status = "success";
                                    result.message = "OTP sent successfully to your Registered Mobile Number.";
                                    return result;
                                }
                                else if (status == "NCPR")
                                {
                                    result.code = 200;
                                    result.otp = "";
                                    result.status = "error";
                                    result.message = "Please Deactivate Do Not Disturb(DND) of your Registered Mobile Number.";
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
            catch (Exception ex) {
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
            }

        }
       
        public async Task<VerifyMobileNo> SendOTPToMobile(string mobileno)
        {
            VerifyMobileNo result = new ();
            try
            {
               
                Random random = new ();
                string otp = random.Next(000001, 999999).ToString();

                string msg = "Your OTP is " + otp + ". Do not Share it with anyone by any means. This is confidential and to be used by you only. ICTSBM";

                //smsStatus smsapiRes = new ();

                //sendSMS(msg, mobileno);
                //string smsresult = await sendSMSasync(msg, mobileno);

                Task<string> myTask = sendSMSasync(msg, mobileno);
              

                string status = myTask.Result.Replace("<br>","");

                if(status == "DELIVRD")
                {
                    result.code = 200;
                    result.otp = otp;
                    result.status = "success";
                    result.message = "OTP sent successfully to your Registered Mobile Number.";
                    return result;
                }
                else if(status == "NCPR")
                {
                    result.code = 200;
                    result.otp = "";
                    result.status = "error";
                    result.message = "Please Deactivate Do Not Disturb(DND) of your Registered Mobile Number.";
                    return result;
                }
                else
                {
                    result.code = 200;
                    result.otp = "";
                    result.status = "error";
                    result.message = "SMS Status is"+ status;
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

                await Task.Delay(TimeSpan.FromSeconds(5));
                string smsresuri = "https://www.smsjust.com/sms/user/response.php?Scheduleid=" + smsresponse.Trim();
                HttpResponseMessage responseMessage_Status = await client.GetAsync(smsresuri);

                if (responseMessage_Status.IsSuccessStatusCode)
                {
                    sms_status = await responseMessage_Status.Content.ReadAsStringAsync();

                    string[] myStr = sms_status.Split(' ');

                    string mono = myStr[0];
                    string status = myStr[1];
                    return status;

                }

            }
            return sms_status;
        }
    }
}
