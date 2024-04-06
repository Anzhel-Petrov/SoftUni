using System.Collections.Generic;
using System.Linq;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _banks;

        public BankRepository()
        {
            _banks = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => _banks.AsReadOnly();
        public void AddModel(IBank model)
        {
            _banks.Add(model);
        }

        public bool RemoveModel(IBank model)
        {
            return _banks.Remove(model);
        }

        public IBank FirstModel(string name)
        {
            return _banks.FirstOrDefault(b => b.Name == name);
        }
    }
}
