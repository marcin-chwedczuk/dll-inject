using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjection {
    public class InjectionOptions {
        public bool WaitForThreadExit { get; set; }

        public static InjectionOptions Defaults {
            get {
                return new InjectionOptions();
            }
        }
    }
}
