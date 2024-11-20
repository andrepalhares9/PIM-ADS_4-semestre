using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnAcesso_Click(object sender, EventArgs e)
        {
            String User = "Admin";
            String Password = "Admin";
            if (txtUsuario.Text == User & txtSenha.Text == Password)
            {
                MessageBox.Show("Acesso liberado");
                Form1 frnMain = new Form1();
                frnMain.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Usuário/Senha incoreta");
            {

            }

        }
    }
}
