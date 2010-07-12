namespace BeehiveManagementSystem
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.report = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.shifts = new System.Windows.Forms.NumericUpDown();
            this.workerBeeJob = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nextShift = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNectar = new System.Windows.Forms.TextBox();
            this.txtHoney = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shifts)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(16, 118);
            this.report.Multiline = true;
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(469, 157);
            this.report.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.shifts);
            this.groupBox1.Controls.Add(this.workerBeeJob);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Worker Bee job Assignments";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Assign this job to a bee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shifts
            // 
            this.shifts.Location = new System.Drawing.Point(278, 35);
            this.shifts.Name = "shifts";
            this.shifts.Size = new System.Drawing.Size(82, 21);
            this.shifts.TabIndex = 3;
            // 
            // workerBeeJob
            // 
            this.workerBeeJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workerBeeJob.FormattingEnabled = true;
            this.workerBeeJob.Items.AddRange(new object[] {
            "Nectar collector",
            "Honey manufacturing",
            "Egg care",
            "Baby bee tutoring",
            "Hive maintenance"});
            this.workerBeeJob.Location = new System.Drawing.Point(27, 35);
            this.workerBeeJob.Name = "workerBeeJob";
            this.workerBeeJob.Size = new System.Drawing.Size(198, 20);
            this.workerBeeJob.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Shifts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Worker bee job";
            // 
            // nextShift
            // 
            this.nextShift.Location = new System.Drawing.Point(413, 21);
            this.nextShift.Name = "nextShift";
            this.nextShift.Size = new System.Drawing.Size(71, 83);
            this.nextShift.TabIndex = 2;
            this.nextShift.Text = "Work the next shift";
            this.nextShift.UseVisualStyleBackColor = true;
            this.nextShift.Click += new System.EventHandler(this.nextShift_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHoney);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNectar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(496, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 102);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hive stat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nectar";
            // 
            // txtNectar
            // 
            this.txtNectar.Location = new System.Drawing.Point(70, 20);
            this.txtNectar.Name = "txtNectar";
            this.txtNectar.ReadOnly = true;
            this.txtNectar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNectar.Size = new System.Drawing.Size(81, 21);
            this.txtNectar.TabIndex = 1;
            this.txtNectar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHoney
            // 
            this.txtHoney.Location = new System.Drawing.Point(70, 47);
            this.txtHoney.Name = "txtHoney";
            this.txtHoney.ReadOnly = true;
            this.txtHoney.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHoney.Size = new System.Drawing.Size(81, 21);
            this.txtHoney.TabIndex = 3;
            this.txtHoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Honey";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nextShift);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.report);
            this.Name = "Form1";
            this.Text = "Beehive Management System";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shifts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox report;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown shifts;
        private System.Windows.Forms.ComboBox workerBeeJob;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextShift;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNectar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoney;
        private System.Windows.Forms.Label label4;
    }
}

