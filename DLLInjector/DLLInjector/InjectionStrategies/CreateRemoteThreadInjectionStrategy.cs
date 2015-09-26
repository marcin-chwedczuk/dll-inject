using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjection.InjectionStrategies {
    class CreateRemoteThreadInjectionStrategy : LoadLibraryInjectionStrategyBase {

        protected override IntPtr Inject(IntPtr processHandle, IntPtr loadLibraryAddress, IntPtr addressOfDllPath) {
            IntPtr remoteThreadHandle =
                WinAPI.CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibraryAddress, addressOfDllPath, 0, IntPtr.Zero);

            Utils.CheckForFailure(remoteThreadHandle == IntPtr.Zero, "Cannot create remote thread using CreateRemoteThread method");

            return remoteThreadHandle;
        }

    }
}
