namespace RaceSimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAl = new System.Windows.Forms.Label();
            this.lbBob = new System.Windows.Forms.Label();
            this.lbJoe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRace = new System.Windows.Forms.Button();
            this.numDog = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numBucks = new System.Windows.Forms.NumericUpDown();
            this.btnBet = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.lbMinbet = new System.Windows.Forms.Label();
            this.rdAl = new System.Windows.Forms.RadioButton();
            this.rdBob = new System.Windows.Forms.RadioButton();
            this.rdJoe = new System.Windows.Forms.RadioButton();
            this.picDog1 = new System.Windows.Forms.PictureBox();
            this.picDog4 = new System.Windows.Forms.PictureBox();
            this.picDog3 = new System.Windows.Forms.PictureBox();
            this.picDog2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDog1 = new System.Windows.Forms.Label();
            this.lbDog2 = new System.Windows.Forms.Label();
            this.lbDog3 = new System.Windows.Forms.Label();
            this.lbDog4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(522, 145);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbDog4);
            this.groupBox1.Controls.Add(this.lbDog3);
            this.groupBox1.Controls.Add(this.lbDog2);
            this.groupBox1.Controls.Add(this.lbDog1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbAl);
            this.groupBox1.Controls.Add(this.lbBob);
            this.groupBox1.Controls.Add(this.lbJoe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRace);
            this.groupBox1.Controls.Add(this.numDog);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numBucks);
            this.groupBox1.Controls.Add(this.btnBet);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.lbMinbet);
            this.groupBox1.Controls.Add(this.rdAl);
            this.groupBox1.Controls.Add(this.rdBob);
            this.groupBox1.Controls.Add(this.rdJoe);
            this.groupBox1.Location = new System.Drawing.Point(9, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Betting Parlor";
            // 
            // lbAl
            // 
            this.lbAl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAl.Location = new System.Drawing.Point(324, 72);
            this.lbAl.Name = "lbAl";
            this.lbAl.Size = new System.Drawing.Size(188, 16);
            this.lbAl.TabIndex = 13;
            this.lbAl.Text = "Al\'s bet";
            // 
            // lbBob
            // 
            this.lbBob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBob.Location = new System.Drawing.Point(324, 53);
            this.lbBob.Name = "lbBob";
            this.lbBob.Size = new System.Drawing.Size(188, 16);
            this.lbBob.TabIndex = 12;
            this.lbBob.Text = "Bob\'s bet";
            // 
            // lbJoe
            // 
            this.lbJoe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbJoe.Location = new System.Drawing.Point(324, 34);
            this.lbJoe.Name = "lbJoe";
            this.lbJoe.Size = new System.Drawing.Size(188, 16);
            this.lbJoe.TabIndex = 11;
            this.lbJoe.Text = "Joe\'s bet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(322, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Bets";
            // 
            // btnRace
            // 
            this.btnRace.Location = new System.Drawing.Point(416, 89);
            this.btnRace.Name = "btnRace";
            this.btnRace.Size = new System.Drawing.Size(99, 43);
            this.btnRace.TabIndex = 9;
            this.btnRace.Text = "Race";
            this.btnRace.UseVisualStyleBackColor = true;
            this.btnRace.Click += new System.EventHandler(this.btnRace_Click);
            // 
            // numDog
            // 
            this.numDog.Location = new System.Drawing.Point(334, 109);
            this.numDog.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDog.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDog.Name = "numDog";
            this.numDog.Size = new System.Drawing.Size(55, 21);
            this.numDog.TabIndex = 8;
            this.numDog.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "bucks on dog number";
            // 
            // numBucks
            // 
            this.numBucks.Location = new System.Drawing.Point(120, 109);
            this.numBucks.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numBucks.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numBucks.Name = "numBucks";
            this.numBucks.Size = new System.Drawing.Size(73, 21);
            this.numBucks.TabIndex = 6;
            this.numBucks.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(39, 107);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(75, 23);
            this.btnBet.TabIndex = 5;
            this.btnBet.Text = "Bets";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(8, 112);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(25, 12);
            this.name.TabIndex = 4;
            this.name.Text = "Joe";
            // 
            // lbMinbet
            // 
            this.lbMinbet.AutoSize = true;
            this.lbMinbet.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbMinbet.Location = new System.Drawing.Point(4, 22);
            this.lbMinbet.Name = "lbMinbet";
            this.lbMinbet.Size = new System.Drawing.Size(90, 12);
            this.lbMinbet.TabIndex = 3;
            this.lbMinbet.Text = "Minimum bet";
            // 
            // rdAl
            // 
            this.rdAl.AutoSize = true;
            this.rdAl.Location = new System.Drawing.Point(6, 81);
            this.rdAl.Name = "rdAl";
            this.rdAl.Size = new System.Drawing.Size(113, 16);
            this.rdAl.TabIndex = 2;
            this.rdAl.TabStop = true;
            this.rdAl.Text = "Al has 45 bucks";
            this.rdAl.UseVisualStyleBackColor = true;
            this.rdAl.CheckedChanged += new System.EventHandler(this.rdAl_CheckedChanged);
            // 
            // rdBob
            // 
            this.rdBob.AutoSize = true;
            this.rdBob.Location = new System.Drawing.Point(6, 59);
            this.rdBob.Name = "rdBob";
            this.rdBob.Size = new System.Drawing.Size(124, 16);
            this.rdBob.TabIndex = 1;
            this.rdBob.TabStop = true;
            this.rdBob.Text = "Bob has 75 bucks";
            this.rdBob.UseVisualStyleBackColor = true;
            this.rdBob.CheckedChanged += new System.EventHandler(this.rdBob_CheckedChanged);
            // 
            // rdJoe
            // 
            this.rdJoe.AutoSize = true;
            this.rdJoe.Location = new System.Drawing.Point(6, 37);
            this.rdJoe.Name = "rdJoe";
            this.rdJoe.Size = new System.Drawing.Size(122, 16);
            this.rdJoe.TabIndex = 0;
            this.rdJoe.TabStop = true;
            this.rdJoe.Text = "Joe has 50 bucks";
            this.rdJoe.UseVisualStyleBackColor = true;
            this.rdJoe.CheckedChanged += new System.EventHandler(this.rdJoe_CheckedChanged);
            // 
            // picDog1
            // 
            this.picDog1.Image = global::RaceSimulator.Properties.Resources.acrobat;
            this.picDog1.InitialImage = ((System.Drawing.Image)(resources.GetObject("picDog1.InitialImage")));
            this.picDog1.Location = new System.Drawing.Point(20, 16);
            this.picDog1.Name = "picDog1";
            this.picDog1.Size = new System.Drawing.Size(56, 29);
            this.picDog1.TabIndex = 2;
            this.picDog1.TabStop = false;
            // 
            // picDog4
            // 
            this.picDog4.Image = global::RaceSimulator.Properties.Resources.acrobat;
            this.picDog4.Location = new System.Drawing.Point(20, 119);
            this.picDog4.Name = "picDog4";
            this.picDog4.Size = new System.Drawing.Size(56, 29);
            this.picDog4.TabIndex = 3;
            this.picDog4.TabStop = false;
            // 
            // picDog3
            // 
            this.picDog3.Image = global::RaceSimulator.Properties.Resources.acrobat;
            this.picDog3.Location = new System.Drawing.Point(20, 86);
            this.picDog3.Name = "picDog3";
            this.picDog3.Size = new System.Drawing.Size(56, 29);
            this.picDog3.TabIndex = 4;
            this.picDog3.TabStop = false;
            // 
            // picDog2
            // 
            this.picDog2.Image = global::RaceSimulator.Properties.Resources.acrobat;
            this.picDog2.Location = new System.Drawing.Point(20, 51);
            this.picDog2.Name = "picDog2";
            this.picDog2.Size = new System.Drawing.Size(56, 29);
            this.picDog2.TabIndex = 5;
            this.picDog2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(163, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Dogs";
            // 
            // lbDog1
            // 
            this.lbDog1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDog1.Location = new System.Drawing.Point(189, 34);
            this.lbDog1.Name = "lbDog1";
            this.lbDog1.Size = new System.Drawing.Size(118, 16);
            this.lbDog1.TabIndex = 15;
            this.lbDog1.Text = "rate is 1:2";
            // 
            // lbDog2
            // 
            this.lbDog2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDog2.Location = new System.Drawing.Point(189, 50);
            this.lbDog2.Name = "lbDog2";
            this.lbDog2.Size = new System.Drawing.Size(118, 16);
            this.lbDog2.TabIndex = 16;
            this.lbDog2.Text = "rate is 1:3";
            // 
            // lbDog3
            // 
            this.lbDog3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDog3.Location = new System.Drawing.Point(189, 66);
            this.lbDog3.Name = "lbDog3";
            this.lbDog3.Size = new System.Drawing.Size(118, 16);
            this.lbDog3.TabIndex = 17;
            this.lbDog3.Text = "rate is 1:4";
            // 
            // lbDog4
            // 
            this.lbDog4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDog4.Location = new System.Drawing.Point(189, 82);
            this.lbDog4.Name = "lbDog4";
            this.lbDog4.Size = new System.Drawing.Size(118, 16);
            this.lbDog4.TabIndex = 18;
            this.lbDog4.Text = "rate is 1:5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(134, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "# 1 dog";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(134, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "# 2 dog";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(134, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "# 3 dog";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(134, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "# 4 dog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 309);
            this.Controls.Add(this.picDog2);
            this.Controls.Add(this.picDog3);
            this.Controls.Add(this.picDog4);
            this.Controls.Add(this.picDog1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDog2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMinbet;
        private System.Windows.Forms.RadioButton rdAl;
        private System.Windows.Forms.RadioButton rdBob;
        private System.Windows.Forms.RadioButton rdJoe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRace;
        private System.Windows.Forms.NumericUpDown numDog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBucks;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label lbAl;
        private System.Windows.Forms.Label lbBob;
        private System.Windows.Forms.Label lbJoe;
        private System.Windows.Forms.PictureBox picDog1;
        private System.Windows.Forms.PictureBox picDog4;
        private System.Windows.Forms.PictureBox picDog3;
        private System.Windows.Forms.PictureBox picDog2;
        private System.Windows.Forms.Label lbDog4;
        private System.Windows.Forms.Label lbDog3;
        private System.Windows.Forms.Label lbDog2;
        private System.Windows.Forms.Label lbDog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

