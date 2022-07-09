using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaQuestao7
{
    public class Produto 
    {
        private static int _id = 0;
        public int Id { get; } 
        public string Descricao { get; set; }
        public Produto(string descricao)
        {
            Id = _id + 1;
            Descricao = descricao;
        }
        public override string ToString()
        {
            return $"{Id} - {Descricao}";
        }
    }
    public class Armazem 
    {
        private static int _id = 0;
        public int Id { get; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public string Descricao { get; set; }
        public Armazem(string descricao)
        {           
            Descricao = descricao;
        }
        public override string ToString()
        {
            return $"{Id} - {Descricao}";
        }
    }
    enum Operacoes 
    {
        Sair = 0,
        CriarArmazem = 1,
        AlterarArmazem = 2,
        RemoverArmazem = 3,
        AdicionarProdutoArmazem = 4,
        RemoverProdutoArmazem = 5
    }
    class Program
    {
        static List<Produto> EncontrarProduto(List<Produto> produtos, string textoBusca) 
        {
            List<Produto> produtosEncontrados = new List<Produto>();

            for (int i = 0; i < produtos.Count(); i++)
            {
                if (produtos[i].ToString().Contains(textoBusca))
                {
                    produtosEncontrados.Add(produtos[i]);
                }
            }
            return produtosEncontrados;
        }
        static void AdicionarProdutoAoArmazem(Armazem armazem, Produto produto) 
        {
            armazem.Produtos.Add(produto);
        }
        static void AdicionarArmazem(List<Armazem> armazens, Armazem armazem) 
        {
            armazens.Add(armazem);
        }
        static List<Armazem> EncontrarArmazens(List<Armazem> armazens, string textoBusca) 
        {
            List<Armazem> armazensEncontrados = new List<Armazem>();

            for(int i=0; i<armazens.Count(); i++) 
            {
                if (armazens[i].ToString().Contains(textoBusca)) 
                {
                    armazensEncontrados.Add(armazens[i]);
                }
            }
            return armazensEncontrados;
        }
        static void Main(string[] args)
        {
            List<Armazem> armazens = new List<Armazem>();
            //mostrar menu de opções
            Operacoes operacaoInicial = (Operacoes)Convert.ToInt32(Console.ReadLine());
            while (operacaoInicial != Operacoes.Sair) 
            {
                //executa as operações.
                if(operacaoInicial == Operacoes.CriarArmazem) 
                {
                    Console.WriteLine("Insira o nome do armazém");
                    string descricaoArmazem = Console.ReadLine();
                    var armazem = new Armazem(descricaoArmazem);
                    AdicionarArmazem(armazens,armazem);
                    Console.WriteLine("Armazém criado.");
                }
                if(operacaoInicial == Operacoes.AlterarArmazem) 
                {
                    string descricaoArmazem = Console.ReadLine();
                    List<Armazem> armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);

                    while (armazensEncontrados.Count()>1) 
                    {
                        Console.WriteLine("Informe um novo parâmetro para encontrar apenas um armazém");
                        descricaoArmazem = Console.ReadLine();
                        armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);
                    }
                    Armazem armazem = armazensEncontrados[0];
                    Console.WriteLine("Armazém encontrado");
                    Console.WriteLine("Informe a nova descrição do Armazém");
                    descricaoArmazem = Console.ReadLine();
                    armazem.Descricao = descricaoArmazem;
                    Console.WriteLine("Armazém atualizado.");
                }
                if(operacaoInicial == Operacoes.RemoverArmazem) 
                {
                    string descricaoArmazem = Console.ReadLine();
                    List<Armazem> armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);

                    while (armazensEncontrados.Count() > 1)
                    {
                        Console.WriteLine("Informe um novo parâmetro para encontrar apenas um armazém");
                        descricaoArmazem = Console.ReadLine();
                        armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);
                    }
                    Armazem armazem = armazensEncontrados[0];
                    armazens.Remove(armazem);
                }
                if(operacaoInicial == Operacoes.AdicionarProdutoArmazem) 
                {
                    string descricaoArmazem = Console.ReadLine();
                    List<Armazem> armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);

                    while (armazensEncontrados.Count() > 1)
                    {
                        Console.WriteLine("Informe um novo parâmetro para encontrar apenas um armazém");
                        descricaoArmazem = Console.ReadLine();
                        armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);
                    }
                    Armazem armazem = armazensEncontrados[0];
                    Console.WriteLine("Informe a descrição do produto");
                    string descricaoProduto = Console.ReadLine();
                    Produto produto = new Produto(descricaoProduto);
                    AdicionarProdutoAoArmazem(armazem, produto);
                    Console.WriteLine("Produto adicionado.");
                }
                if(operacaoInicial == Operacoes.RemoverProdutoArmazem) 
                {
                    string descricaoArmazem = Console.ReadLine();
                    List<Armazem> armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);

                    while (armazensEncontrados.Count() > 1)
                    {
                        Console.WriteLine("Informe um novo parâmetro para encontrar apenas um armazém");
                        descricaoArmazem = Console.ReadLine();
                        armazensEncontrados = EncontrarArmazens(armazens, descricaoArmazem);
                    }
                    Armazem armazem = armazensEncontrados[0];
                    Console.WriteLine("Informe a descrição do produto");
                    string descricaoProduto = Console.ReadLine();
                    List<Produto> produtos = EncontrarProduto(armazem.Produtos, descricaoProduto);
                    while (produtos.Count() > 1) 
                    {
                        Console.WriteLine("Informe a descrição do produto para encontrar um único registro.");
                        descricaoProduto = Console.ReadLine();
                        produtos = EncontrarProduto(armazem.Produtos, descricaoProduto);
                    }
                    Console.WriteLine("Produto encontrado.");
                    Produto produto = produtos[0];
                    armazem.Produtos.Remove(produto);
                }
                
                //
                operacaoInicial = (Operacoes)Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
