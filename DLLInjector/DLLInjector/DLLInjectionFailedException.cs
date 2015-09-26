using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjection {
    [Serializable]
    public class DLLInjectionFailedException : Exception {
        public DLLInjectionFailedException(string message) : base(message) { }
    }
}
