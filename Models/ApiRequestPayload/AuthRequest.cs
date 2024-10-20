using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E_APPLICATION.Models.ApiRequestPayload
{
    public class AuthRequest
    {
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        // Model cho yêu cầu đăng ký
        public class SignUpRequest
        {
            public string Email { get; set; }

            public string Password { get; set; }

            public string DisplayName { get; set; }

            public DateTime Birth { get; set; }

            public bool Sex { get; set; }
        }

        // Model cho yêu cầu quên mật khẩu
        public class ForgotPasswordRequest
        {
            public string Email { get; set; }
        }
    }
}
