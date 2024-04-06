using System.Collections.Generic;
using System.Linq;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> _loans;

        public LoanRepository()
        {
            _loans = new List<ILoan>();
        }
        public IReadOnlyCollection<ILoan> Models => _loans.AsReadOnly();
        public void AddModel(ILoan model)
        {
            _loans.Add(model);
        }

        public bool RemoveModel(ILoan model)
        {
            return _loans.Remove(model);
        }

        public ILoan FirstModel(string name)
        {
            return _loans.FirstOrDefault(l => l.GetType().Name == name);
        }
    }
}
