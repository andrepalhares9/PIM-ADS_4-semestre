using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ProdutosServices produtosServices;
        private ProdutosServices.Produto produtoSelecionado;

        public Form1()
        {
            InitializeComponent();
            produtosServices = new ProdutosServices();
            ConfigurarGrid();
            CarregarProdutos();
        }

        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "ID",
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nome",
                HeaderText = "Nome",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "quantidade",
                HeaderText = "Quantidade",
                Width = 80
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "preco",
                HeaderText = "Preço",
                Width = 80
            });
        }

        private async void CarregarProdutos()
        {
            try
            {
                var produtos = await produtosServices.GetProdutos();
                dataGridView1.DataSource = produtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e) // Adicionar
        {
            try
            {
                var produto = new ProdutosServices.Produto
                {
                    nome = textBox1.Text,
                    quantidade = int.Parse(textBox2.Text),
                    preco = decimal.Parse(textBox3.Text),
                    descricao = "",
                    linkImg = ""
                };

                if (await produtosServices.AddProduto(produto))
                {
                    MessageBox.Show("Produto adicionado com sucesso!");
                    LimparCampos();
                    CarregarProdutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}");
            }
        }

        private async void button2_Click(object sender, EventArgs e) // Editar
        {
            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto para editar!");
                return;
            }

            try
            {
                produtoSelecionado.nome = textBox1.Text;
                produtoSelecionado.quantidade = int.Parse(textBox2.Text);
                produtoSelecionado.preco = decimal.Parse(textBox3.Text);

                if (await produtosServices.EditarProduto(produtoSelecionado))
                {
                    MessageBox.Show("Produto atualizado com sucesso!");
                    LimparCampos();
                    CarregarProdutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        private async void button3_Click(object sender, EventArgs e) // Excluir
        {
            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto para excluir!");
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este produto?", "Confirmação", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (await produtosServices.DeletarProduto(produtoSelecionado.id))
                    {
                        MessageBox.Show("Produto excluído com sucesso!");
                        LimparCampos();
                        CarregarProdutos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir produto: {ex.Message}");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                produtoSelecionado = dataGridView1.CurrentRow.DataBoundItem as ProdutosServices.Produto;
                if (produtoSelecionado != null)
                {
                    textBox1.Text = produtoSelecionado.nome;
                    textBox2.Text = produtoSelecionado.quantidade.ToString();
                    textBox3.Text = produtoSelecionado.preco.ToString();
                }
            }
        }

        private void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            produtoSelecionado = null;
        }
    }
}
