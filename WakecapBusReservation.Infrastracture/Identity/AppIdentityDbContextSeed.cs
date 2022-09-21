using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Domain.Models.Idenitiy;

namespace WakecapBusReservation.Infrastracture.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserData(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                AppUser appUser = new AppUser
                {
                    UserName = "AhmedEliwa",
                    Email = "ahmedeliwa15@gmail.com",
                };
                var reult = await userManager.CreateAsync(appUser, "Eliwa@6676");
            }
        }
    }
}
