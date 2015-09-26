using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjection.InjectionStrategies {
    static class InjectionStrategyFactory {
        public static IInjectionStrategy Create(InjectionMethod injectionMethod) {
            switch (injectionMethod) {
                case InjectionMethod.CREATE_REMOTE_THREAD:
                    return new CreateRemoteThreadInjectionStrategy();

                case InjectionMethod.NT_CREATE_THREAD_EX:
                    return new NtCreateThreadExInjectionStrategy();

                default:
                    throw new NotSupportedException(string.Format("Injection strategy: {0} is not supported", injectionMethod));
            }
        }
    }
}
