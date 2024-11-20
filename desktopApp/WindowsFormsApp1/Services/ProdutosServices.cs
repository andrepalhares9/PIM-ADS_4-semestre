using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public class ProdutosServices
    {
        private static readonly HttpClient client = new HttpClient();
        private const string baseUrl = "https://pim.nseno.com/products";

        public class Produto
        {
            public int id { get; set; }
            public string nome { get; set; }
            public int quantidade { get; set; }
            public string descricao { get; set; }
            public string linkImg { get; set; }
            public decimal preco { get; set; }
        }

        public class ApiResponse
        {
            public bool error { get; set; }
            public List<Produto> produtos { get; set; }
        }

        public async Task<List<Produto>> GetProdutos()
        {
            var response = await client.GetAsync($"{baseUrl}/getProducts");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse>(content);
            return result.produtos;
        }

        public async Task<bool> AddProduto(Produto produto)
        {
            var json = JsonConvert.SerializeObject(new
            {
                nome = produto.nome,
                qnt = produto.quantidade,
                descricao = produto.descricao,
                linkImg = produto.linkImg,
                preco = produto.preco
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/newProduct", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarProduto(Produto produto)
        {
            var json = JsonConvert.SerializeObject(new
            {
                nome = produto.nome,
                qnt = produto.quantidade,
                descricao = produto.descricao,
                linkImg = produto.linkImg,
                preco = produto.preco
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/editProduct/{produto.id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletarProduto(int id)
        {
            var response = await client.DeleteAsync($"{baseUrl}/deleteProduct/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
