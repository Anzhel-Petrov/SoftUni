using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string _name;
        private int _capacity;
        private List<ILoan> _loans;
        private List<IClient> _clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _loans = new List<ILoan>();
            _clients = new List<IClient>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                _name = value;
            }
        }

        public int Capacity
        {
            get => _capacity;
            private set
            {
                _capacity = value;
            }
        }

        public IReadOnlyCollection<ILoan> Loans => _loans.AsReadOnly();
        public IReadOnlyCollection<IClient> Clients => _clients.AsReadOnly();
        public double SumRates()
        {
            return _loans.Select(i => i.InterestRate).Sum();
        }

        public void AddClient(IClient Client)
        {
            if (_clients.Count < Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            _clients.Add(Client);
        }

        public void RemoveClient(IClient Client)
        {
            _clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            _loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            sb.Append($"Clients: ");

            if (_clients.Any())
            {
                sb.Append(string.Join(", ", _clients.Select(c => c.Name)));
            }
            else
            {
                sb.Append("none");
            }

            sb.AppendLine($"Loans: {_loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().Trim();
        }
    }
}
