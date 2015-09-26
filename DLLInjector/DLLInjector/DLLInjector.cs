using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DLLInjection.InjectionStrategies;
using System.IO;

namespace DLLInjection {
    public class DLLInjector {
        private IInjectionStrategy _injectionStrategy;

        public DLLInjector(InjectionMethod injectionMethod) {
            _injectionStrategy = InjectionStrategyFactory.Create(injectionMethod);
        }

        public void Inject(int pid, string pathToDll, InjectionOptions injectionOptions = null) {
            if (pid <= 0)
                throw new ArgumentException("Invalid process pid: " + pid, "pid");

            if (string.IsNullOrWhiteSpace(pathToDll) || !File.Exists(pathToDll))
                throw new ArgumentException(string.Format("Cannot access DLL: \"{0}\"", pathToDll));

            injectionOptions = injectionOptions ?? InjectionOptions.Defaults;


            IntPtr processHandle = WinAPI.OpenProcess(
                WinAPI.ProcessAccessFlags.CreateThread | 
                WinAPI.ProcessAccessFlags.QueryInformation |
                WinAPI.ProcessAccessFlags.VirtualMemoryOperation |
                WinAPI.ProcessAccessFlags.VirtualMemoryRead |
                WinAPI.ProcessAccessFlags.VirtualMemoryWrite,
                bInheritHandle: false,
                processId: pid);

            Utils.CheckForFailure(processHandle == IntPtr.Zero, "Cannot open process with PID: {0}", pid);


            IntPtr remoteThreadHandle = _injectionStrategy.Inject(processHandle, pathToDll);
            if (injectionOptions.WaitForThreadExit) {
                WinAPI.WaitForSingleObject(remoteThreadHandle, WinAPI.INFINITE);
            }


            WinAPI.CloseHandle(processHandle);
        }
   }
}
