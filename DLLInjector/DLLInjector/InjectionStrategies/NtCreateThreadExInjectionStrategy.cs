using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjection.InjectionStrategies {
    class NtCreateThreadExInjectionStrategy : LoadLibraryInjectionStrategyBase {

        protected override unsafe IntPtr Inject(IntPtr processHandle, IntPtr loadLibraryAddress, IntPtr addressOfDllPath) {
            // from: https://github.com/mattifestation/PowerSploit

            IntPtr ntdllModule = WinAPI.GetModuleHandle(WinAPI.NTDLL_DLL);
            Utils.CheckForFailure(ntdllModule == IntPtr.Zero, "Cannot load NTDLL module");


            IntPtr ntCreateThreadExAddress = WinAPI.GetProcAddress(ntdllModule, WinAPI.NT_CREATE_THREAD_EX);
            Utils.CheckForFailure(ntCreateThreadExAddress == IntPtr.Zero, "Cannot find NtCreateThreadEx address in NTDLL module");


            var ntCreateThreadEx = (WinAPI.NtCreateThreadEx)
                Marshal.GetDelegateForFunctionPointer(ntCreateThreadExAddress, typeof(WinAPI.NtCreateThreadEx));
            Utils.CheckForFailure(ntCreateThreadEx == null, "Cannot create delegate from pointer to NtCreateThreadEx");


            int temp1 = 0, temp2 = 0;
            WinAPI.NtCreateThreadExBuffer nb = new WinAPI.NtCreateThreadExBuffer {
                Size = sizeof(WinAPI.NtCreateThreadExBuffer),
                Unknown1 = 0x10003,
                Unknown2 = 0x8,
                Unknown3 = new IntPtr(&temp2),
                Unknown4 = 0,
                Unknown5 = 0x10004,
                Unknown6 = 4,
                Unknown7 = new IntPtr(&temp1),
                Unknown8 = 0,
            };

            bool is64bit = Environment.Is64BitProcess;

            IntPtr hRemoteThread = IntPtr.Zero;
            ntCreateThreadEx(
                out hRemoteThread,
                0x1FFFFF,
                IntPtr.Zero,
                processHandle,
                loadLibraryAddress,
                addressOfDllPath,
                0,
                0,
                (is64bit ? 0xFFFF : 0u),
                (is64bit ? 0xFFFF : 0u),
                (is64bit ? IntPtr.Zero : new IntPtr(&nb))
                );

            Utils.CheckForFailure(hRemoteThread == IntPtr.Zero, "NtCreateThreadEx failed");


            return hRemoteThread;
        }
    }
}
