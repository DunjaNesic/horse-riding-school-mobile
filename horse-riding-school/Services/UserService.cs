using horse_riding_school.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horse_riding_school.Services
{
    class UserService : IUserService
    {
        public async Task<User> Login(string email, string pass)
        {

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7002/")
            };

            var loginData = new
            {
                userName = email,
                password = pass
            };

            var json = System.Text.Json.JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/auth/login", content);


            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var user = System.Text.Json.JsonSerializer.Deserialize<User>(responseContent, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return user;
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Kredencijali nisu ispravni, pokusajte ponovo" , "Ok");
                return null;
            }
        }

    }
}
