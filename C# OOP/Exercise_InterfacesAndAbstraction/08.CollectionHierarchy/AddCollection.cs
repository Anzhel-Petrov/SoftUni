using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        protected List<string> _collection;

        public AddCollection()
        {
            _collection = new List<string>();
        }

        public void Add(string item)
        {
            _collection.Add(item);
        }
    }
}
