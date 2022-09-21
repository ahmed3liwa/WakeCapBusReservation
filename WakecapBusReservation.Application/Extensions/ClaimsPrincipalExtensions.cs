using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WakecapBusReservation.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string ReteriveEmailFromPrincipal(this ClaimsPrincipal User)
        {
            return User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
