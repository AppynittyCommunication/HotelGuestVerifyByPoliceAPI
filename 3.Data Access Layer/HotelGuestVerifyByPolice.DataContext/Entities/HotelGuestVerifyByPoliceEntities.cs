using HotelGuestVerifyByPolice.DataContext.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities
{
    public class HotelGuestVerifyByPoliceEntities: ApplicationDbContext
    {

        public HotelGuestVerifyByPoliceEntities()
        {

        }
        public HotelGuestVerifyByPoliceEntities(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
