using BankLoan.Models.Contracts;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        private int _interestRate;
        private double _amount;
        public Loan(int interestRate, double amount)
        {
            InterestRate = interestRate;
            Amount = amount;
        }

        public int InterestRate
        {
            get => _interestRate;
            private set
            {
                _interestRate = value;
            }
        }

        public double Amount
        {
            get => _amount;
            private set
            {
                _amount = value;
            }
        }

    }
}
