﻿using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<UserResponse> LoginAsync(LoginRequest loginRequest);
        Task<string> ConfirmEmail(string token, string userID);
        Task<string> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest);
        Task<string> ResetPassword(ResetPasswordRequest resetPasswordRequest);
    }
}
