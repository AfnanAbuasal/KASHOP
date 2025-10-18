﻿using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Areas.Identity
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest registerRequest)
        {
            var result = await _authenticationService.RegisterAsync(registerRequest);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            var result = await _authenticationService.LoginAsync(loginRequest);
            return Ok(result);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult<string>> ConfirmEmail([FromQuery] string token, [FromQuery] string userID)
        {
            var result = await _authenticationService.ConfirmEmail(token, userID);
            return Ok(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<string>> ForgotPassword([FromBody]ForgotPasswordRequest forgotPasswordRequest)
        {
            var result = await _authenticationService.ForgotPassword(forgotPasswordRequest);
            return Ok(result);
        }

        [HttpPatch("ResetPassword")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            var result = await _authenticationService.ResetPassword(resetPasswordRequest);
            return Ok(result);
        }
    }
}
