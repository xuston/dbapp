namespace database_application
{
    partial class Authoritaition
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            logint = new TextBox();
            passwd = new TextBox();
            loglable = new Label();
            passlable = new Label();
            confirm = new Button();
            SuspendLayout();
            // 
            // logint
            // 
            logint.Location = new Point(183, 47);
            logint.Margin = new Padding(4);
            logint.Name = "logint";
            logint.Size = new Size(169, 29);
            logint.TabIndex = 0;
            // 
            // passwd
            // 
            passwd.Location = new Point(183, 121);
            passwd.Margin = new Padding(4);
            passwd.Name = "passwd";
            passwd.Size = new Size(169, 29);
            passwd.TabIndex = 1;
            // 
            // loglable
            // 
            loglable.AutoSize = true;
            loglable.Location = new Point(183, 22);
            loglable.Margin = new Padding(4, 0, 4, 0);
            loglable.Name = "loglable";
            loglable.Size = new Size(54, 21);
            loglable.TabIndex = 2;
            loglable.Text = "Логин";
            // 
            // passlable
            // 
            passlable.AutoSize = true;
            passlable.Location = new Point(183, 96);
            passlable.Margin = new Padding(4, 0, 4, 0);
            passlable.Name = "passlable";
            passlable.Size = new Size(63, 21);
            passlable.TabIndex = 3;
            passlable.Text = "Пароль";
            // 
            // confirm
            // 
            confirm.Location = new Point(183, 178);
            confirm.Margin = new Padding(4);
            confirm.Name = "confirm";
            confirm.Size = new Size(172, 32);
            confirm.TabIndex = 4;
            confirm.Text = "Подтвердить";
            confirm.UseVisualStyleBackColor = true;
            confirm.Click += confirm_Click;
            // 
            // Authoritaition
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 233);
            Controls.Add(confirm);
            Controls.Add(passlable);
            Controls.Add(loglable);
            Controls.Add(passwd);
            Controls.Add(logint);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            MaximumSize = new Size(547, 272);
            MinimumSize = new Size(547, 272);
            Name = "Authoritaition";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Authentification";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox logint;
        private TextBox passwd;
        private Label loglable;
        private Label passlable;
        private Button confirm;
    }
}
