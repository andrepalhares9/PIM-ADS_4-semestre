namespace formLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void login_button_Click(object sender, EventArgs e)
        {
            string user = userInput_textBox.Text.Trim();
            string password = passwordInput_textBox.Text.Trim();

            Login login = new Login();
            bool isAuthenticated = await login.AuthenticateAsync(user, password);

            if (isAuthenticated)
            {
                status_label.Text = "Login bem-sucedido!";
                // Aqui você pode redirecionar o usuário para outra tela ou continuar o processo de login
            }
            else
            {
                status_label.Text = "Usuário ou senha incorretos.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
