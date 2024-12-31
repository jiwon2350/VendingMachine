namespace VendingMachine
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_PlayerHP = new System.Windows.Forms.TextBox();
            this.textBox_MonsterHP = new System.Windows.Forms.TextBox();
            this.button_fight = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_PlayerHP
            // 
            this.textBox_PlayerHP.Location = new System.Drawing.Point(43, 95);
            this.textBox_PlayerHP.Multiline = true;
            this.textBox_PlayerHP.Name = "textBox_PlayerHP";
            this.textBox_PlayerHP.Size = new System.Drawing.Size(273, 197);
            this.textBox_PlayerHP.TabIndex = 0;
            // 
            // textBox_MonsterHP
            // 
            this.textBox_MonsterHP.Location = new System.Drawing.Point(338, 95);
            this.textBox_MonsterHP.Multiline = true;
            this.textBox_MonsterHP.Name = "textBox_MonsterHP";
            this.textBox_MonsterHP.Size = new System.Drawing.Size(269, 197);
            this.textBox_MonsterHP.TabIndex = 1;
            // 
            // button_fight
            // 
            this.button_fight.Location = new System.Drawing.Point(629, 244);
            this.button_fight.Name = "button_fight";
            this.button_fight.Size = new System.Drawing.Size(106, 48);
            this.button_fight.TabIndex = 2;
            this.button_fight.Text = "Fight!!";
            this.button_fight.UseVisualStyleBackColor = true;
            this.button_fight.Click += new System.EventHandler(this.button_fight_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(338, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Monster";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Player";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_fight);
            this.Controls.Add(this.textBox_MonsterHP);
            this.Controls.Add(this.textBox_PlayerHP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_PlayerHP;
        private System.Windows.Forms.TextBox textBox_MonsterHP;
        private System.Windows.Forms.Button button_fight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

