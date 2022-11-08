using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EconomySystem
{
    public class Person 
    {
        public static List<Person> People = new List<Person>();

        public string Nome { get; set; }
        public int Idade { get; set; }
        public Bank ContaBancaria { get; set; }
        public int NIF { get; set; }
        // public Car Garagem {get ; set;}

        public Person(string nome, int idade, int nif, int pin)
        {
            this.Nome = nome;
            this.Idade = GetAge(idade);
            this.NIF = nif;
            this.ContaBancaria = new Bank(pin);
        }

        public Person(string nome, double idade, int nif)
        {
            this.Nome = nome;
            this.Idade = Convert.ToInt32(idade);
            this.NIF = nif;
        }

        public Person(string nome, int idade, int nif)
        {
            this.Nome = nome;
            this.Idade = GetAge(idade);
            this.NIF = nif;
        }

        int GetAge(int input)
        {
            DateTime anoAtual = DateTime.Now;
            int idade = anoAtual.Year- input;
            return idade;
        }

        public static void CreatePerson()
        {
            Console.Write("Insira o seu Nome: ");
            string? nome = Console.ReadLine();
            Console.Write("Ano Nascimento: ");
            int anoNascimento = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insira o seu Numero de identificação fiscal: ");
            int numeroFiscal = Convert.ToInt32(Console.ReadLine());
            Console.Write("Deseja criar conta bancária? s/n: ");
            switch (Console.ReadLine())
            {
                case "s":
                case "S":
                    People.Add(new Person(nome, anoNascimento, numeroFiscal, Bank.SetPIN()));
                    Console.WriteLine("Conta Criada com Sucesso!");
                    Thread.Sleep(1000);
                    Console.Clear();

                    break;
                case "n":
                case "N":
                    Console.WriteLine("Conta Criada com Sucesso!");
                    People.Add(new Person(nome, anoNascimento, numeroFiscal));
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Erro, tente novamente");
                    break;
            }
        }
        public static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("******* Lista Usuarios *******");
            Console.WriteLine();


            foreach (Person person in People)
            {
                Console.WriteLine($"" +
                    $"| NOME: {person.Nome} \n" +
                    $"| IDADE: {person.Idade} \n" +
                    $"| NIF: {person.NIF} \n");
                if (person.ContaBancaria != null)
                    Console.WriteLine($"| NIB:{person.ContaBancaria.GetIBAN().Insert(4, " ").Insert(9, " ").Insert(21, " ")} \n\n");
                else
                    continue;
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        public static Person GetPerson()
        {
            Person user;
            int checkNIF;
            while (true)
            {
                try
                {
                    Console.Write("NIF: ");
                    checkNIF = int.Parse(Console.ReadLine());
                    user = Person.People.FirstOrDefault(a => a.NIF == checkNIF);
                    if (user != null) { break; }
                    else Console.Write("NIF nao encontrado!! \nPrima 0 para sair ou enter para continuar : ");
                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        Console.Clear();
                        Program.Menu();
                    }
                }
                catch { Console.WriteLine("NIF nao encontrado!! \n Prima 0 para sair ou enter para continuar : "); }
            }

            return user;
        }

        public static Person CheckPersonWithPin()
        {
            Person user = Person.GetPerson();

            if (Bank.CheckPIN(user) == true)
                return user;
            else
                return null;
        }


        public static void ShowUserDetails(Person user)
        {
            Console.WriteLine($"" +
    $"| NOME: {user.Nome} \n" +
    $"| IDADE: {user.Idade} \n" +
    $"| NIF: {user.NIF} \n" +
    $"| NIB:{user.ContaBancaria.GetIBAN().Insert(4, " ").Insert(9, " ").Insert(21, " ")} \n\n");
        }
    }

}
