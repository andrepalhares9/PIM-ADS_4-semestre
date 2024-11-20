using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class FormLogin : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = "https://pim.nseno.com/users/login"; // Ajuste a URL conforme sua API

        public FormLogin()
        {
            InitializeComponent();
            txtSenha.PasswordChar = '*'; // Oculta a senha digitada
        }

        private async void btnAcesso_Click(object sender, EventArgs e)
        {
            try
            {
                var loginData = new
                {
                    userInput = txtUsuario.Text,
                    passwordInput = txtSenha.Text
                };

                var content = new StringContent(
                    JsonConvert.SerializeObject(loginData),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(apiUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LoginResponse>(responseString);

                if (response.IsSuccessStatusCode && result.status == "ok")
                {
                    MessageBox.Show("Acesso liberado");
                    Form1 frnMain = new Form1();
                    frnMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário/Senha incorreta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar fazer login: {ex.Message}");
            }
        }
    }

    public class LoginResponse
    {
        public string status { get; set; }
        public string id { get; set; }
    }
}
