using System;
using System.Collections.Generic;

namespace CadastroClientes
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.Clear(); // Limpa a tela
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== Cadastro de Clientes ===");
                Console.ResetColor();
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar cliente");
                Console.WriteLine("2 - Visualizar clientes");
                Console.WriteLine("3 - Editar cliente");
                Console.WriteLine("4 - Excluir cliente");
                Console.WriteLine("5 - Sair");

                Console.Write("Opção: ");
                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }

                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        VisualizarClientes();
                        break;
                    case 3:
                        EditarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
                        break;
                    case 5:
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void AdicionarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Cliente ===");
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o e-mail do cliente: ");
            string email = Console.ReadLine();

            Cliente cliente = new Cliente(nome, email);
            clientes.Add(cliente);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cliente adicionado com sucesso.");
            Console.ResetColor();
        }

        static void VisualizarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Clientes ===");
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"Nome: {cliente.Nome}");
                    Console.WriteLine($"E-mail: {cliente.Email}");
                    Console.WriteLine("----------------------");
                }
            }
        }

        static void EditarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Editar Cliente ===");
            Console.Write("Digite o nome do cliente que deseja editar: ");
            string nome = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (cliente != null)
            {
                Console.Write("Digite o novo nome do cliente: ");
                string novoNome = Console.ReadLine();

                Console.Write("Digite o novo e-mail do cliente: ");
                string novoEmail = Console.ReadLine();

                cliente.Nome = novoNome;
                cliente.Email = novoEmail;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cliente editado com sucesso.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        static void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Excluir Cliente ===");
            Console.Write("Digite o nome do cliente que deseja excluir: ");
            string nome = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cliente excluído com sucesso.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
    }

    class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
