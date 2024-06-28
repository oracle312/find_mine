namespace Mine_Test
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.wallHack = new System.Windows.Forms.CheckBox();
            this.lbl_catchProc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_base = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.btn_catchProc = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_arAddr = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wallHack
            // 
            this.wallHack.AutoSize = true;
            this.wallHack.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallHack.Location = new System.Drawing.Point(6, 20);
            this.wallHack.Name = "wallHack";
            this.wallHack.Size = new System.Drawing.Size(70, 17);
            this.wallHack.TabIndex = 0;
            this.wallHack.Text = "오버레이";
            this.wallHack.UseVisualStyleBackColor = true;
            this.wallHack.CheckedChanged += new System.EventHandler(this.wallHack_CheckedChanged_1);
            // 
            // lbl_catchProc
            // 
            this.lbl_catchProc.AutoSize = true;
            this.lbl_catchProc.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_catchProc.ForeColor = System.Drawing.Color.Red;
            this.lbl_catchProc.Location = new System.Drawing.Point(9, 231);
            this.lbl_catchProc.Name = "lbl_catchProc";
            this.lbl_catchProc.Size = new System.Drawing.Size(189, 17);
            this.lbl_catchProc.TabIndex = 1;
            this.lbl_catchProc.Text = "타겟 프로세스를 열어주세요 :F";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.wallHack);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 152);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_arAddr);
            this.groupBox2.Controls.Add(this.lbl_base);
            this.groupBox2.Controls.Add(this.lbl_time);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(8, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Memory";
            // 
            // lbl_base
            // 
            this.lbl_base.AutoSize = true;
            this.lbl_base.Location = new System.Drawing.Point(6, 34);
            this.lbl_base.Name = "lbl_base";
            this.lbl_base.Size = new System.Drawing.Size(0, 15);
            this.lbl_base.TabIndex = 1;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(6, 19);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(0, 15);
            this.lbl_time.TabIndex = 0;
            // 
            // btn_catchProc
            // 
            this.btn_catchProc.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_catchProc.Location = new System.Drawing.Point(12, 199);
            this.btn_catchProc.Name = "btn_catchProc";
            this.btn_catchProc.Size = new System.Drawing.Size(202, 29);
            this.btn_catchProc.TabIndex = 3;
            this.btn_catchProc.Text = "OpenProcess";
            this.btn_catchProc.UseVisualStyleBackColor = true;
            this.btn_catchProc.Click += new System.EventHandler(this.btn_catchProc_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 170);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_arAddr
            // 
            this.lbl_arAddr.AutoSize = true;
            this.lbl_arAddr.Location = new System.Drawing.Point(6, 49);
            this.lbl_arAddr.Name = "lbl_arAddr";
            this.lbl_arAddr.Size = new System.Drawing.Size(0, 15);
            this.lbl_arAddr.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 257);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_catchProc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_catchProc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox wallHack;
        private System.Windows.Forms.Label lbl_catchProc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_catchProc;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_base;
        private System.Windows.Forms.Label lbl_arAddr;
    }
}

