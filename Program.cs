namespace Lab1_Task.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Konto nr 1", "Alfred Pak", 1400m, "PLN", "Personal", "Czarna");
            BankAccount account2 = new BankAccount("Konto nr 2", "Harry Potter", 5000m, "PLN", "Personal", "Złota");
            BankAccount account3 = new BankAccount("Konto nr 3", "Firma GREEN", 30000m, "PLN", "Business", "Zielona");

            Console.WriteLine("^________Początkowy stan kont________^");
            Console.WriteLine(account1);
            Console.WriteLine(account2);
            Console.WriteLine(account3);
            Console.WriteLine();

            Console.WriteLine("Wpłata 340 PLN na konto Alfreda Paka...");
            account1.Deposit(340m);
            Console.WriteLine(account1);
            Console.WriteLine();

            Console.WriteLine("Wypłata 100 PLN z konta Harry'ego Pottera...");
            bool success = account2.Withdraw(100m);
            Console.WriteLine($"Czy wypłata się powiodła? {success}");
            Console.WriteLine(account2);
            Console.WriteLine();

            Console.WriteLine("Próba wypłaty 210 PLN z konta Harry'ego Pottera...");
            bool failed = account2.Withdraw(210m);
            Console.WriteLine($"Czy wypłata się powiodła? - {failed}");
            Console.WriteLine(account2);
            Console.WriteLine();

            Console.WriteLine("Przelew 1760 PLN z konta Firmy GREEN do Harry'ego Pottera...");
            account3.TransferTo(account2, 1760m);
            Console.WriteLine(account3);
            Console.WriteLine(account2);
            Console.WriteLine();

            Console.WriteLine("Zamykamy konto Alfreda Paka...");
            account1.Close();
            Console.WriteLine(account1);
            Console.WriteLine("Próba wpłaty 50 PLN na zamknięte konto...");
            account1.Deposit(50m); 
            Console.WriteLine(account1);

            Console.WriteLine("\n_________ Koniec demonstracji, dziękuję! _________");
        }
    }
}
