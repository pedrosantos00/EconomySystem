using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomySystem
{
    public class Bank 
    {
        public Bank(int bankPin)
        {
            this.IBAN = IbanGenerator();
            this.PIN = bankPin;
            this.Balance = 0;
        }

        public Bank(string iban, int bankPin)
        {
            this.IBAN = iban;
            this.PIN = bankPin;
            this.Balance = 0;
        }

        private string IBAN;
        private int PIN;
        private double Balance;

        private static string IbanGenerator()
        {
            
            Random random= new Random();
            string iban = "";
            for (int i = 0; i < 21; i++)
            {
                int randomnumber = random.Next(0, 9);
                iban += randomnumber;
            }
            return iban;
        }

        public void setBalance(double newBalance)
        {
            Balance = newBalance;
        }

        public void AddBalance(double newBalance)
        {
            Balance += newBalance;
        }

        public void WithrawalBalance(double newBalance)
        {
            Balance -= newBalance;
        }

        public string GetIBAN()
        {
            return IBAN;
        }

        public int GetPIN()
        {
            return PIN;
        }

        public static int SetPIN() 
        {
            while (true)
            {
                Console.Write("Insira um pin de 4 digitos -> ");
                int check1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Insira um pin de 4 digitos -> ");
                int check2 = Convert.ToInt32(Console.ReadLine());
                if (check1 != check2 || check2.ToString().Length < 4 || check2.ToString().Length > 4)
                {
                    Console.WriteLine("Por favor insira um Pin correto!");
                }
                else
                return check2;
                break;

            }

            return 0;
        }

        public static bool CheckPIN(Person user)
        {
            while (true)
            {
                Console.Write("Insira o pin do cartão -> ");
                int check1 = Convert.ToInt32(Console.ReadLine());
                if (check1 == user.ContaBancaria.GetPIN())
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static void AddBankAccount()
        {
            Person user = Person.GetPerson();
            user.ContaBancaria = new Bank(IbanGenerator(), SetPIN());
            Console.WriteLine("Conta no Banco criada com sucesso!");
            Person.ShowUserDetails(user);

        }



        public static void RemoveBankAccount()
        {
            Person user = Person.GetPerson();
            string nome = user.Nome;
            double idade = user.Idade;
            int nif = user.NIF;
            Person.People.Remove(user);
            Person.People.Add(new Person(nome, idade, nif));
            Console.WriteLine("Banco removido com sucesso!!");

        }

        public double GetBalance()
        {
            return Balance;
        }

    }
}
