using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XboxGamesApi.DTOs;
using XboxGamesApi.Errors;

namespace XboxGamesApi.Controllers
{
    [Authorize]
    public class AccountController : ApiBaseController //ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(
                                    UserManager<AppUser> userManager,
                                    SignInManager<AppUser> signInManager,
                                    ITokenService tokenService,
                                    IMapper mapper
                                 ) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDTO loginDTO) 
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) return Unauthorized(new APIResponse(401));

            var resultado = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!resultado.Succeeded) return Unauthorized(new APIResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Nome = user.Nome
            };
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> register(RegisterDTO registerDTO) 
        {
            if (CheckEmailExistsAsync(registerDTO.Email).Result.Value) 
            {
                return new BadRequestObjectResult(new APIValidationError {Errors = new[] {"O endereço de e-mail já está em uso"}});
            }
            var user = new AppUser
            {
                Nome = registerDTO.Nome,
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };
            var resultado = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!resultado.Succeeded) return BadRequest(new APIResponse(400));
            return new UserDto
            {
                Nome = registerDTO.Nome,
                Token = _tokenService.CreateToken(user),
                Email = registerDTO.Email
            };
        }




        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromBody] string email) 
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }




    }
}
