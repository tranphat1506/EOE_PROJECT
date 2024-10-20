using E2E_APPLICATION.Models.ApiResponsePayload;
using E2E_APPLICATION.Models.Database;
using E2E_APPLICATION.Services.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static E2E_APPLICATION.Models.ApiRequestPayload.AuthRequest;

namespace E2E_APPLICATION.Models.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private readonly AuthContext _authContext;

        public HomeViewModel()
        {
            _authContext = AuthContextProvider.Instance;
        }

        public bool IsAuthenticated => _authContext.IsAuthenticated;
        public LoginResponse? User => _authContext.User;

        // Login method that calls the API
        public async Task Login(string email, string password)
        {
            // Simulate API call
            var apiResponse = await CallLoginApi(new() { Email=email, Password=password});

            if (apiResponse?.HttpCode == 200)
            {
                // If API returns success, log the user in via AuthContext
                _authContext.Login(apiResponse.Payload!);

                // Notify UI about the changes
                OnPropertyChanged(nameof(IsAuthenticated));
                OnPropertyChanged(nameof(User));
            }
            else
            {
                // Handle failed login (e.g., show error message)
                // Optionally throw an error or return failure state
                throw new Exception("Login failed: " + apiResponse?.Message ?? "API_NULL");
            }
        }

        // Logout method
        public void Logout()
        {
            _authContext.Logout();
            OnPropertyChanged(nameof(IsAuthenticated));
            OnPropertyChanged(nameof(User));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task<ApiResponse<LoginResponse>?> CallLoginApi(LoginRequest loginRequest)
        {
            // Disable SSL validation for HttpClient
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;

            using var httpClient = new HttpClient(handler);
            // Đặt URL API của bạn
            var url = "https://localhost:7183/api/Auth/login";

            // Tạo nội dung yêu cầu với dữ liệu người dùng
            var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST tới API
            var response = await httpClient.PostAsync(url, content);

            // Parse JSON response
            var responseContent = await response.Content.ReadAsStringAsync();
            // Kiểm tra kết quả phản hồi từ API
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoginResponse>>(responseContent);
            return apiResponse;
        }
    }

}
