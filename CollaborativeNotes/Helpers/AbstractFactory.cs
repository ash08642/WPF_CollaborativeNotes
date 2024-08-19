using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeNotes.Helpers
{
    public class AbstractFactory<T> : IAbstractFactory<T>
    {
        private Func<T> _factory;

        public AbstractFactory(Func<T> factory)
        {
            _factory = factory;
        }

        public T Create()
        {
            return _factory();
        }
    }
}
