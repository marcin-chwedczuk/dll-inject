using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLLInjection.Gui {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Text += (Environment.Is64BitProcess ? " (amd64)" : " (x86)");
        }

        private void exitBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void browserBtn_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                dllPathTxt.Text = openFileDialog.FileName;   
            }
        }

        private void injectBtn_Click(object sender, EventArgs e) {
            string dll = dllPathTxt.Text;
            string pidText = pidTxt.Text;
            int pid;

            if (string.IsNullOrEmpty(dll) || !int.TryParse(pidText, out pid)) {
                MessageBox.Show("Missing parameters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(dll)) {
                MessageBox.Show("Cannot find specified dll!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var injectionMethod = InjectionMethod.CREATE_REMOTE_THREAD;
            if (ntCreateThreadExCb.Checked) {
                injectionMethod = InjectionMethod.NT_CREATE_THREAD_EX; 
            }

            try {
                var injector = new DLLInjector(injectionMethod);
                injector.Inject(pid, dll);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
