using System;

namespace E2E_APPLICATION.Services.Auth
{
    public class AuthContextProvider
    {
        private static AuthContext? _authContext;
        public static AuthContext Instance => _authContext ??= new AuthContext();
    }
}
