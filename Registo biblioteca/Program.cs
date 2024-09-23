using System;
using System.Data.SqlClient;

namespace Registo_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Livraria;Integrated Security=True";
            menu(connectionString);
        }
        static void menu(string connectionString)
        {
            int opcao = 0;
            do
            {

                Console.WriteLine("\n\t1 - Utilizador");
                Console.WriteLine("\n\t2 - Livros");
                Console.WriteLine("\n\t3 - Emprestimos");
                Console.WriteLine("\n\t0 - SAIR");
                Console.Write("\n\t\tSeleciona uma opção: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Registo(connectionString);
                        break;
                    case 2:
                        Livros(connectionString);

                        break;
                    case 3:
                        Emprestimo(connectionString);
                        break;
                    case 0:
                        opcao0();
                        break;

                    default:
                        Console.WriteLine("Opção não válida!!!");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != 5);

            Console.ReadKey();




        }

        static void Registo(string connectionString)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tRegisto:");

            Console.Write("\n\n\nDigite o seu primeiro nome:");
            string Primeiro_nome = Console.ReadLine();


            Console.Write("\n\n\nApelido:");
            string Ultimo_Nome = Console.ReadLine();

            Console.Write("\n\n\nData de Nascimento:");
            string Data_De_Nascimento= Console.ReadLine();
            Console.Write("\n\n\n Coloque a sua password:");
            string Password = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Registo_Utilizadores (Primeiro_Nome, Ultimo_Nome, Data_De_Nascimento, Password) VALUES (@Primeiro_Nome, @Ultimo_Nome, @Data_De_Nascimento, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Primeiro_Nome", Primeiro_nome);
                    command.Parameters.AddWithValue("@Ultimo_Nome", Ultimo_Nome);
                    command.Parameters.AddWithValue("@Data_De_Nascimento", Data_De_Nascimento);
                    command.Parameters.AddWithValue("@Password", Password);

                    int rowsAffected = command.ExecuteNonQuery(); 

                    if (rowsAffected>0)
                        Console.WriteLine("Contato registado com sucesso!");
                    else
                        Console.WriteLine("Erro ao registar o contato.");

                    Console.Write("Qualquer tecla para continuar ... ");
                    Console.ReadKey();
                }

                Console.WriteLine("\n\n\nRegisto concluido com sucesso!!!!!");
                Console.Clear();

                Console.ReadKey();
            }
        }
        static void Livros(string connectionString)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tLivros:");
            Console.WriteLine("Escolha um livro dentro dos disponíveis");



        }
        static void Emprestimo(string connectionString)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tEmprestimo:");

            DateTime data1 = new DateTime(2024, 09, 17);
            DateTime dataAtual = DateTime.Now;

            Console.WriteLine("\n\n\nData de requisito: " + dataAtual.ToString("dd/MM/yyyy"));

            DateTime dataFutura = data1.AddDays(15);
            Console.WriteLine("\n\n\nData de entrerga do livro: " + dataFutura.ToString("dd/MM/yyyy"));

            Console.WriteLine($"\n\n\nLivro requistado com sucesso!!! Você deverá entregar o livro requisitado no dia {dataFutura}, se não deverá pagar uma coima de 10 euros");

            Console.ReadKey();
            Console.Clear();


        }
        static void Carochinha(string connectiontostring)
        {
            Console.Clear();
            Console.WriteLine("Livro selecionado, passe ao próximo passo (3) para requisitar o livro");
            Console.ReadKey();
            Console.Clear();
        }
            static void Os_Três_Ladrões(string connectiontostring)
            {
                Console.Clear();
                Console.WriteLine("Livro selecionado, passe ao próximo passo (3) para requisitar o livro");
                Console.ReadKey();
                Console.Clear();



                Console.ReadKey();
            }
            static void O_Diário_de_um_banana(string connectiontostring)
            {
                Console.Clear();
                Console.WriteLine("Livro selecionado, passe ao próximo passo (3) para requisitar o livro");
                Console.ReadKey();


            }

            static void opcao0()
            {
                Environment.Exit(0);
            }
          
        
    }
}
