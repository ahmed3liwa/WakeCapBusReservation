using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WakecapBusReservation.API.ViewModels;
using WakecapBusReservation.Application.Extensions;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models.Idenitiy;

namespace WakecapBusReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Field
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        #endregion

        #region CTOR
        public AccountController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserViewModel>> Login(LoginUserViewModel loginViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null) return Unauthorized(new ErrorResponseViewModel("Invalid username or Password"));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);
            if (!result.Succeeded) return Unauthorized(new ErrorResponseViewModel("Invalid username or Password"));
            return new UserViewModel
            {
                Emial = user.Email,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserViewModel>> Register(RegsiterUserViewModel regsiterViewModel)
        {
            if (await CheckEmialExistAsync(regsiterViewModel.Email))
                return BadRequest(new ErrorResponseViewModel("Emial is already in use"));
            var user = new AppUser
            {
                UserName = regsiterViewModel.UserName,
                Email = regsiterViewModel.Email,
            };
            var result = await _userManager.CreateAsync(user, regsiterViewModel.Password);
            if (!result.Succeeded) return BadRequest(new ErrorResponseViewModel("Bad Request. failed while creating user"));
            return new UserViewModel
            {
                UserName = user.UserName,
                Emial = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
        #endregion

        #region Helpers 
        private async Task<bool> CheckEmialExistAsync([FromQuery] string Email)
        {
            return await _userManager.FindByEmailAsync(Email) != null;
        }
        #endregion
    }
}
