using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjection.Tests {
    [TestFixture]
    public class DLLInjectorTests {

        private Process _victim;
        private int _pid;

        [SetUp]
        public void SetUp() {
            _victim = Process.Start(new ProcessStartInfo {
                CreateNoWindow = false,
                FileName = typeof(Victim.Program).Assembly.Location,
                
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = false,
            });

            string pidLine = _victim.StandardOutput.ReadLine();
            _pid = int.Parse(pidLine.Split()[1]);
        }

        [TearDown]
        public void TearDown() {
            try {
                _victim.StandardInput.WriteLine("quit");
                _victim.StandardOutput.ReadToEnd();

                if (!_victim.WaitForExit((int)TimeSpan.FromSeconds(10).TotalMilliseconds)) {
                    _victim.Kill();
                }
            }
            catch {
                _victim.Kill();
            }
            finally {
                _victim.Dispose();
            }
        }

        [Test /*, Timeout(30*1000)*/]
        public void DLL_Injector_Should_Inject_DLL_Using_Create_Remote_Thread_Method() {
            var injector = new DLLInjector(InjectionMethod.CREATE_REMOTE_THREAD);
            injector.Inject(_pid, @"DLLToInject.dll");

            //_victim.StandardInput.WriteLine("foo");

            string line;
            while ((line = _victim.StandardOutput.ReadLine()) != null) {
                if (line.Contains("DLL_INJECTED"))
                    break;
            }
        }
    }
}
