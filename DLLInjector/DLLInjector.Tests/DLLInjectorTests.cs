using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

            _pid = _victim.Id;
        }

        [TearDown]
        public void TearDown() {
            try {
                _victim.StandardInput.WriteLine("quit");

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

        [Test]
        public void DLL_Injector_Should_Inject_DLL_Using_Create_Remote_Thread_Method() {
            var injector = new DLLInjector(InjectionMethod.CREATE_REMOTE_THREAD);
            injector.Inject(_pid, @"DLLToInject.dll");

            AssertDLLSuccessfullyInjected(timeoutSeconds: 30);
        }

        private void AssertDLLSuccessfullyInjected(int timeoutSeconds) {
            bool dllInjected = false;

            _victim.OutputDataReceived += (sender, e) => {
                if (e.Data != null && e.Data.Contains("DLL_INJECTED")) {
                    dllInjected = true;
                }
            };
            _victim.BeginOutputReadLine();

            var start = DateTime.Now;
            while (!dllInjected) {
                // sleep introduces memory barrier
                Thread.Sleep(100);

                if (DateTime.Now.Subtract(start).TotalSeconds > timeoutSeconds) {
                    Assert.Fail("After waiting {0} seconds, no input was received from DLLToInject.", timeoutSeconds);
                }
            }
        }
    }
}
