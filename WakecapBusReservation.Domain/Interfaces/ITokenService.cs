using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models.Idenitiy;

namespace WakecapBusReservation.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
