using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan_BusinessLogic.Core
{
    public class Controller : IController
    {
        private IRepository<IBank> _bankRepository;
        private IRepository<ILoan> _loanRepository;

        public Controller()
        {
            _loanRepository = new LoanRepository();
            _bankRepository = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName != nameof(CentralBank) && bankTypeName != nameof(BranchBank))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = bankTypeName == nameof(CentralBank) ? new CentralBank(name) : new BranchBank(name);
            _bankRepository.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bank.GetType().Name);
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName != nameof(StudentLoan) && loanTypeName != nameof(MortgageLoan))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan = loanTypeName == nameof(StudentLoan) ? new StudentLoan() : new MortgageLoan();
            _loanRepository.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loan.GetType().Name);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = _loanRepository.FirstModel(loanTypeName);
            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            IBank bank = _bankRepository.FirstModel(bankName);
            bank.AddLoan(loan);
            _loanRepository.RemoveModel(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loan.GetType().Name, bank.Name);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (clientTypeName != nameof(Adult) && clientTypeName != nameof(Student))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = _bankRepository.FirstModel(bankName);
            IClient client = clientTypeName == nameof(Student) ? new Student(clientName, id, income) : new Adult(clientName, id, income);

            if (client.GetType().Name == nameof(Student) && bank.GetType().Name == nameof(CentralBank))
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }

            bank.AddClient(client);
            return string.Format(OutputMessages.ClientAddedSuccessfully, client.GetType().Name, bank.Name);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = _bankRepository.FirstModel(bankName);
            double totalLoans = bank.Loans.Select(l => l.Amount).Sum();
            double totalClientsIncome = bank.Clients.Select(c => c.Income).Sum();

            return string.Format(OutputMessages.BankFundsCalculated, bank.Name, (totalLoans + totalClientsIncome).ToString("0.00"));
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IBank bank in _bankRepository.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
