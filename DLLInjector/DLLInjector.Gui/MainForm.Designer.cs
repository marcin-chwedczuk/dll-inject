namespace DLLInjection.Gui {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.dllPathTxt = new System.Windows.Forms.TextBox();
            this.browserBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createRemoteThreadCb = new System.Windows.Forms.RadioButton();
            this.ntCreateThreadExCb = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pidTxt = new System.Windows.Forms.TextBox();
            this.injectBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DLL TO INJECT:";
            // 
            // dllPathTxt
            // 
            this.dllPathTxt.Location = new System.Drawing.Point(106, 21);
            this.dllPathTxt.Name = "dllPathTxt";
            this.dllPathTxt.Size = new System.Drawing.Size(444, 20);
            this.dllPathTxt.TabIndex = 1;
            // 
            // browserBtn
            // 
            this.browserBtn.Location = new System.Drawing.Point(556, 19);
            this.browserBtn.Name = "browserBtn";
            this.browserBtn.Size = new System.Drawing.Size(75, 23);
            this.browserBtn.TabIndex = 2;
            this.browserBtn.Text = "BROWSE";
            this.browserBtn.UseVisualStyleBackColor = true;
            this.browserBtn.Click += new System.EventHandler(this.browserBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "DLL Files (*.dll)|*.dll|All files (*.*)|*.*";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Select DLL to inject...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntCreateThreadExCb);
            this.groupBox1.Controls.Add(this.createRemoteThreadCb);
            this.groupBox1.Location = new System.Drawing.Point(15, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INJECTION METHOD";
            // 
            // createRemoteThreadCb
            // 
            this.createRemoteThreadCb.AutoSize = true;
            this.createRemoteThreadCb.Checked = true;
            this.createRemoteThreadCb.Location = new System.Drawing.Point(18, 28);
            this.createRemoteThreadCb.Name = "createRemoteThreadCb";
            this.createRemoteThreadCb.Size = new System.Drawing.Size(171, 17);
            this.createRemoteThreadCb.TabIndex = 0;
            this.createRemoteThreadCb.TabStop = true;
            this.createRemoteThreadCb.Text = "CREATE_REMOTE_THREAD";
            this.createRemoteThreadCb.UseVisualStyleBackColor = true;
            // 
            // ntCreateThreadExCb
            // 
            this.ntCreateThreadExCb.AutoSize = true;
            this.ntCreateThreadExCb.Location = new System.Drawing.Point(18, 51);
            this.ntCreateThreadExCb.Name = "ntCreateThreadExCb";
            this.ntCreateThreadExCb.Size = new System.Drawing.Size(160, 17);
            this.ntCreateThreadExCb.TabIndex = 1;
            this.ntCreateThreadExCb.Text = "NT_CREATE_THREAD_EX";
            this.ntCreateThreadExCb.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "VICTIM PID:";
            // 
            // pidTxt
            // 
            this.pidTxt.Location = new System.Drawing.Point(106, 62);
            this.pidTxt.Name = "pidTxt";
            this.pidTxt.Size = new System.Drawing.Size(444, 20);
            this.pidTxt.TabIndex = 5;
            // 
            // injectBtn
            // 
            this.injectBtn.Location = new System.Drawing.Point(556, 220);
            this.injectBtn.Name = "injectBtn";
            this.injectBtn.Size = new System.Drawing.Size(75, 23);
            this.injectBtn.TabIndex = 6;
            this.injectBtn.Text = "INJECT";
            this.injectBtn.UseVisualStyleBackColor = true;
            this.injectBtn.Click += new System.EventHandler(this.injectBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(475, 220);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "EXIT";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 254);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.injectBtn);
            this.Controls.Add(this.pidTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browserBtn);
            this.Controls.Add(this.dllPathTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DLL Injector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dllPathTxt;
        private System.Windows.Forms.Button browserBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ntCreateThreadExCb;
        private System.Windows.Forms.RadioButton createRemoteThreadCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pidTxt;
        private System.Windows.Forms.Button injectBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

