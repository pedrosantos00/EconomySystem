namespace EconomySystem
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            string selectedOption = Escolha();
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (selectedOption)
            {
                case "1":
                    Person.CreatePerson();
                    // Create an User
                    break;

                case "2":
                    // LIST Users
                    Person.ListUsers();
                    break;
                case "3":
                    // ADD BANK ACCOUNT TO EXISTING USER
                    Bank.AddBankAccount();
                    break;
                case "4":
                    // REMOVE BANK ACCOUNT TO EXISTING USER
                    Bank.RemoveBankAccount();
                    break;
                case "5":
                    // ATM MENU
                    ATM.Login();
                    break;
                case "6":
                    // CARS MENU
                    break;

                case "C":
                case "c":
                    // CLEAR CONSOLE
                    Console.Clear();
                    break;

                case "E":
                case "e":
                    // EXIT
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid operation");
                    break;
            }

            if (selectedOption != "e" && selectedOption != "E")
            {
                Menu();
            }

        }

        private static string Escolha()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("******* MENU *******");
            Console.WriteLine("1 - Criar um user");
            Console.WriteLine("2 - Listar Usuarios");
            Console.WriteLine();
            Console.WriteLine("******* BANCO *******");
            Console.WriteLine();
            Console.WriteLine("3 - Adicionar conta bancaria a user existente");
            Console.WriteLine("4 - Remover conta bancaria a user existente");
            Console.WriteLine();
            Console.WriteLine("******* ATM *******");
            Console.WriteLine();
            Console.WriteLine("5 - INSERIR CARTÃO");
            Console.WriteLine();
            Console.WriteLine();
            //  Console.WriteLine("******* CAR DEALERSHIP *******");
            Console.WriteLine();
            //Console.WriteLine("6 - Enter on Stand");
            Console.WriteLine();

            Console.WriteLine("C - Clear");
            Console.WriteLine("E - Exit");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.White;
            string selectedOption = Console.ReadLine();
            return selectedOption;
        }
    }
}