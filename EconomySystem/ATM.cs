using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EconomySystem
{
    public class ATM
    {
        public static Person user;
        public static void Login()
        {
            user = Person.CheckPersonWithPin();
            if (user != null)
            {
                Menu();
            }
            else
                Console.WriteLine("Autenticação errada, por favor tente mais tarde!");
                Program.Menu();
        }

        public static void Menu()
        {
            string selectedOption = Escolha();
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (selectedOption)
            {
                case "1":
                    // Show Balance
                    ShowBalance();
                    Menu();
                    break;

                case "2":
                    //Deposit Money
                    DepositMoney();
                    Menu();
                    break;
                case "3":
                    // Transfer Money
                    TransferMoney();
                    Menu();
                    break;
                case "4":
                    //Withrawal Money
                    WithrawalMoney();
                    Menu();
                    break;

                case "C":
                case "c":
                    Console.Clear();
                    Menu();
                    break;

                case "E":
                case "e":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid operation");
                    Menu();
                    break;


            }
            if (selectedOption != "E" && selectedOption != "e")
            {
                Program.Menu();
            }
        }

        private static string Escolha()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine();
            Console.WriteLine("******* ATM MENU *******");
            Console.WriteLine();

            Console.WriteLine("1 - Mostrar Saldo");
            Console.WriteLine("2 - Deposito");
            Console.WriteLine("3 - Transferencia nacional");
            Console.WriteLine("4 - Levantamento");
            Console.WriteLine();

            Console.WriteLine("C - Limpar Consola");
            Console.WriteLine("E - Retirar Cartão");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            string selectedOption = Console.ReadLine();
            return selectedOption;
        }

        private static void TransferMoney()
        {
            Console.Write("Insira Abaixo o NIF da pessoa que deseja depositar:  ");
            Person user2 = Person.GetPerson();
            Console.WriteLine();
            Console.Write($"Quanto deseja depositar na conta de {user2.Nome} -> ");
            double depValue = double.Parse(Console.ReadLine());
            if (user.ContaBancaria.GetBalance() >= depValue)
            {
                user2.ContaBancaria.AddBalance(depValue);
                user.ContaBancaria.WithrawalBalance(depValue);
                Console.WriteLine("Transferencia feita com sucesso!");
                ShowBalance();
            }
            else
            {
                Console.WriteLine("Nao tem saldo possivel para fazer a transferencia!");
                ShowBalance();
            }
        }

        private static void DepositMoney()
        {
            Console.Write("Insira o valor para depositar: ");
            double deposit = double.Parse(Console.ReadLine());
            user.ContaBancaria.AddBalance(deposit);
            Console.WriteLine($"Depositado com sucesso!");
            ShowBalance();
        }

        private static void WithrawalMoney()
        {
            Console.Write("Insira o valor para levantar: ");
            double deposit = double.Parse(Console.ReadLine());
            user.ContaBancaria.WithrawalBalance(deposit);
            Console.WriteLine($"Levantamento com sucesso!");
            ShowBalance();
        }

        private static void ShowBalance()
        {
            Console.WriteLine();
            Console.WriteLine($"Nome da Conta : {user.Nome} \nSaldo Atual: {user.ContaBancaria.GetBalance().ToString("C")} ");
            Thread.Sleep(1000);
        }
    }
}

