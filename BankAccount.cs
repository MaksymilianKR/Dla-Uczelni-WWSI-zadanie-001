using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Task.ConsoleApp
{
    public class BankAccount
    {
        private string _accountNumber;
        private string _ownerName;
        private decimal _balance;
        private string _currency;
        private bool _isActive;
        private string _accountType;
        private string _cardColor;

        public BankAccount(string accountNumber, string ownerName, decimal initialBalance, string currency, string accountType, string cardColor)
        {
            _accountNumber = accountNumber;
            _ownerName = ownerName;
            _balance = initialBalance >= 0 ? initialBalance : 0m;
            _currency = currency;
            _isActive = true;
            _accountType = accountType;
            _cardColor = cardColor;
        }

        public void Deposit(decimal amount)
        {
            if (!_isActive || amount <= 0) return;
            _balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            // Sprawdzamy, czy konto jest aktywne
            if (!_isActive)
            {
                Console.WriteLine($"Nie można wypłacić pieniędzy — konto {_accountNumber} jest zamknięte.");
                return false;
            }

            // Sprawdzamy, czy kwota jest dodatnia
            if (amount <= 0)
            {
                Console.WriteLine("Kwota wypłaty musi być dodatnia.");
                return false;
            }

            // Blokujemy wypłatę większą niż saldo
            if (amount > _balance)
            {
                Console.WriteLine("Brak wystarczających środków na koncie.");
                return false; // saldo nie zmienia się
            }

            // Wypłata jest poprawna – odejmujemy od salda
            _balance -= amount;
            Console.WriteLine($"Wypłacono {amount} {_currency} z konta {_accountNumber}.");
            return true;
        }
        

        public void TransferTo(BankAccount target, decimal amount)
        {
            if (Withdraw(amount))
            {
                target.Deposit(amount);
            }
        }

        public void Close()
        {
            _isActive = false;
        }

        public string AccountNumber { get { return _accountNumber; } }
        public string OwnerName { get { return _ownerName; } }
        public decimal Balance { get { return _balance; } }
        public string Currency { get { return _currency; } }
        public bool IsActive { get { return _isActive; } }
        public string AccountType { get { return _accountType; } }
        public string CardColor { get { return _cardColor; } }

        public override string ToString()
        {
            string status = _isActive ? "Aktywne" : "Zamknięte";
            return $"[{_accountNumber}] {_ownerName} | Saldo: {_balance} {_currency} | Typ: {_accountType} | Karta: {_cardColor} | {status}";
        }
    }
}
