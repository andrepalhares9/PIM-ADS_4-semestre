using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace formLogin
{
    public class Login
    {
        private static readonly HttpClient client = new HttpClient();
        private string apiUrl = "http://localhost:3001/users/login"; // Troque pelo URL da sua API

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var loginData = new
            {
                userInput = username,
                passwordInput = password
            };

            // Serializa o objeto para JSON
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            try
            {
                // Faz a requisição POST para a API
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // Se o status code for 200, significa que o login foi bem-sucedido
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<LoginResponse>(responseData);

                    return result.Status == "ok"; // Se o status retornado for "ok", o login foi bem-sucedido
                }

                return false;
            }
            catch (Exception ex)
            {
                // Trata erros
                Console.WriteLine("Erro ao tentar logar: " + ex.Message);
                return false;
            }
        }
    }

    public class LoginResponse
    {
        public string Status { get; set; }
        public string Id { get; set; }
    }
}
