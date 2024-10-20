using E2E_APPLICATION.Models.ApiResponsePayload;
using E2E_APPLICATION.Models.Database;
using System;
using System.ComponentModel;
namespace E2E_APPLICATION.Services.Auth
{

    public class AuthContext : INotifyPropertyChanged
    {
        private bool _isAuthenticated;
        private LoginResponse? _user;

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            private set
            {
                _isAuthenticated = value;
                OnPropertyChanged(nameof(IsAuthenticated));
            }
        }

        public LoginResponse? User
        {
            get => _user;
            private set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Phương thức đăng nhập
        public void Login(LoginResponse user)
        {
            User = user;
            IsAuthenticated = true;
        }

        // Phương thức đăng xuất
        public void Logout()
        {
            User = null;
            IsAuthenticated = false;
        }
    }

}
