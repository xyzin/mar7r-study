namespace PorkerCards
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
            this.listDeck1 = new System.Windows.Forms.ListBox();
            this.listDeck2 = new System.Windows.Forms.ListBox();
            this.moveToDeck2 = new System.Windows.Forms.Button();
            this.moveToDeck1 = new System.Windows.Forms.Button();
            this.btnShuffleDeck2 = new System.Windows.Forms.Button();
            this.btnResetDeck2 = new System.Windows.Forms.Button();
            this.btnShuffleDeck1 = new System.Windows.Forms.Button();
            this.lbDeck1 = new System.Windows.Forms.Label();
            this.lbDeck2 = new System.Windows.Forms.Label();
            this.btnResetDeck1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listDeck1
            // 
            this.listDeck1.FormattingEnabled = true;
            this.listDeck1.ItemHeight = 12;
            this.listDeck1.Location = new System.Drawing.Point(12, 31);
            this.listDeck1.Name = "listDeck1";
            this.listDeck1.Size = new System.Drawing.Size(120, 184);
            this.listDeck1.TabIndex = 1;
            // 
            // listDeck2
            // 
            this.listDeck2.FormattingEnabled = true;
            this.listDeck2.ItemHeight = 12;
            this.listDeck2.Location = new System.Drawing.Point(174, 31);
            this.listDeck2.Name = "listDeck2";
            this.listDeck2.Size = new System.Drawing.Size(120, 184);
            this.listDeck2.TabIndex = 2;
            // 
            // moveToDeck2
            // 
            this.moveToDeck2.Location = new System.Drawing.Point(138, 70);
            this.moveToDeck2.Name = "moveToDeck2";
            this.moveToDeck2.Size = new System.Drawing.Size(30, 23);
            this.moveToDeck2.TabIndex = 3;
            this.moveToDeck2.Text = ">>";
            this.moveToDeck2.UseVisualStyleBackColor = true;
            this.moveToDeck2.Click += new System.EventHandler(this.moveToDeck2_Click);
            // 
            // moveToDeck1
            // 
            this.moveToDeck1.Location = new System.Drawing.Point(138, 99);
            this.moveToDeck1.Name = "moveToDeck1";
            this.moveToDeck1.Size = new System.Drawing.Size(30, 23);
            this.moveToDeck1.TabIndex = 4;
            this.moveToDeck1.Text = "<<";
            this.moveToDeck1.UseVisualStyleBackColor = true;
            this.moveToDeck1.Click += new System.EventHandler(this.moveToDeck1_Click);
            // 
            // btnShuffleDeck2
            // 
            this.btnShuffleDeck2.Location = new System.Drawing.Point(174, 250);
            this.btnShuffleDeck2.Name = "btnShuffleDeck2";
            this.btnShuffleDeck2.Size = new System.Drawing.Size(120, 23);
            this.btnShuffleDeck2.TabIndex = 5;
            this.btnShuffleDeck2.Text = "Shuffle Deck #2";
            this.btnShuffleDeck2.UseVisualStyleBackColor = true;
            this.btnShuffleDeck2.Click += new System.EventHandler(this.btnShuffleDeck2_Click);
            // 
            // btnResetDeck2
            // 
            this.btnResetDeck2.Location = new System.Drawing.Point(174, 221);
            this.btnResetDeck2.Name = "btnResetDeck2";
            this.btnResetDeck2.Size = new System.Drawing.Size(120, 23);
            this.btnResetDeck2.TabIndex = 6;
            this.btnResetDeck2.Text = "Reset Deck #2";
            this.btnResetDeck2.UseVisualStyleBackColor = true;
            this.btnResetDeck2.Click += new System.EventHandler(this.btnResetDeck2_Click);
            // 
            // btnShuffleDeck1
            // 
            this.btnShuffleDeck1.Location = new System.Drawing.Point(12, 250);
            this.btnShuffleDeck1.Name = "btnShuffleDeck1";
            this.btnShuffleDeck1.Size = new System.Drawing.Size(120, 23);
            this.btnShuffleDeck1.TabIndex = 7;
            this.btnShuffleDeck1.Text = "Shuffle Deck #1";
            this.btnShuffleDeck1.UseVisualStyleBackColor = true;
            this.btnShuffleDeck1.Click += new System.EventHandler(this.btnShuffleDeck1_Click);
            // 
            // lbDeck1
            // 
            this.lbDeck1.Location = new System.Drawing.Point(12, 16);
            this.lbDeck1.Name = "lbDeck1";
            this.lbDeck1.Size = new System.Drawing.Size(120, 12);
            this.lbDeck1.TabIndex = 8;
            this.lbDeck1.Text = "label1";
            // 
            // lbDeck2
            // 
            this.lbDeck2.Location = new System.Drawing.Point(174, 16);
            this.lbDeck2.Name = "lbDeck2";
            this.lbDeck2.Size = new System.Drawing.Size(120, 12);
            this.lbDeck2.TabIndex = 9;
            this.lbDeck2.Text = "label2";
            // 
            // btnResetDeck1
            // 
            this.btnResetDeck1.Location = new System.Drawing.Point(12, 221);
            this.btnResetDeck1.Name = "btnResetDeck1";
            this.btnResetDeck1.Size = new System.Drawing.Size(120, 23);
            this.btnResetDeck1.TabIndex = 0;
            this.btnResetDeck1.Text = "Reset Deck #1";
            this.btnResetDeck1.UseVisualStyleBackColor = true;
            this.btnResetDeck1.Click += new System.EventHandler(this.btnResetDeck1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 297);
            this.Controls.Add(this.lbDeck2);
            this.Controls.Add(this.lbDeck1);
            this.Controls.Add(this.btnShuffleDeck1);
            this.Controls.Add(this.btnResetDeck2);
            this.Controls.Add(this.btnShuffleDeck2);
            this.Controls.Add(this.moveToDeck1);
            this.Controls.Add(this.moveToDeck2);
            this.Controls.Add(this.listDeck2);
            this.Controls.Add(this.listDeck1);
            this.Controls.Add(this.btnResetDeck1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listDeck1;
        private System.Windows.Forms.ListBox listDeck2;
        private System.Windows.Forms.Button moveToDeck2;
        private System.Windows.Forms.Button moveToDeck1;
        private System.Windows.Forms.Button btnShuffleDeck2;
        private System.Windows.Forms.Button btnResetDeck2;
        private System.Windows.Forms.Button btnShuffleDeck1;
        private System.Windows.Forms.Label lbDeck1;
        private System.Windows.Forms.Label lbDeck2;
        private System.Windows.Forms.Button btnResetDeck1;
    }
}

