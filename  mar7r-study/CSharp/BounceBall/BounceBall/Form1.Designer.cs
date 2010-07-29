namespace BounceBall
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnBasket = new System.Windows.Forms.Button();
            this.btnSoccer = new System.Windows.Forms.Button();
            this.btnBaseball = new System.Windows.Forms.Button();
            this.btnGolf = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 400);
            this.panel1.TabIndex = 4;
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(537, 419);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(75, 23);
            this.btnDo.TabIndex = 5;
            this.btnDo.Text = "Start";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnBasket
            // 
            this.btnBasket.Location = new System.Drawing.Point(12, 418);
            this.btnBasket.Name = "btnBasket";
            this.btnBasket.Size = new System.Drawing.Size(109, 23);
            this.btnBasket.TabIndex = 6;
            this.btnBasket.Text = "Add Basketball";
            this.btnBasket.UseVisualStyleBackColor = true;
            this.btnBasket.Click += new System.EventHandler(this.btnBasket_Click);
            // 
            // btnSoccer
            // 
            this.btnSoccer.Location = new System.Drawing.Point(12, 447);
            this.btnSoccer.Name = "btnSoccer";
            this.btnSoccer.Size = new System.Drawing.Size(109, 23);
            this.btnSoccer.TabIndex = 7;
            this.btnSoccer.Text = "Add soccer";
            this.btnSoccer.UseVisualStyleBackColor = true;
            this.btnSoccer.Click += new System.EventHandler(this.btnSoccer_Click);
            // 
            // btnBaseball
            // 
            this.btnBaseball.Location = new System.Drawing.Point(12, 476);
            this.btnBaseball.Name = "btnBaseball";
            this.btnBaseball.Size = new System.Drawing.Size(109, 23);
            this.btnBaseball.TabIndex = 8;
            this.btnBaseball.Text = "Add Baseball";
            this.btnBaseball.UseVisualStyleBackColor = true;
            this.btnBaseball.Click += new System.EventHandler(this.btnBaseball_Click);
            // 
            // btnGolf
            // 
            this.btnGolf.Location = new System.Drawing.Point(12, 505);
            this.btnGolf.Name = "btnGolf";
            this.btnGolf.Size = new System.Drawing.Size(109, 23);
            this.btnGolf.TabIndex = 9;
            this.btnGolf.Text = "Add Golf";
            this.btnGolf.UseVisualStyleBackColor = true;
            this.btnGolf.Click += new System.EventHandler(this.btnGolf_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(375, 421);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Velocity";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 542);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnGolf);
            this.Controls.Add(this.btnBaseball);
            this.Controls.Add(this.btnSoccer);
            this.Controls.Add(this.btnBasket);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "BounceBall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnBasket;
        private System.Windows.Forms.Button btnSoccer;
        private System.Windows.Forms.Button btnBaseball;
        private System.Windows.Forms.Button btnGolf;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}

