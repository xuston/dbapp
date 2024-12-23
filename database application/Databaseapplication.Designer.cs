namespace database_application
{
    partial class Databaseapplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            aplly = new Button();
            workspace = new DataGridView();
            tablechoose = new ComboBox();
            Columnchooser = new ComboBox();
            searchbox = new TextBox();
            search = new Button();
            Fulltsearch = new CheckBox();
            infoftsearch = new Label();
            addinf = new Button();
            delif = new Button();
            chnginf = new Button();
            button1 = new Button();
            button2 = new Button();
            otch = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)workspace).BeginInit();
            SuspendLayout();
            // 
            // aplly
            // 
            aplly.Location = new Point(13, 548);
            aplly.Margin = new Padding(4);
            aplly.Name = "aplly";
            aplly.Size = new Size(193, 56);
            aplly.TabIndex = 0;
            aplly.Text = "Применить";
            aplly.UseVisualStyleBackColor = true;
            aplly.Click += aplly_Click;
            // 
            // workspace
            // 
            workspace.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            workspace.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            workspace.Location = new Point(214, 66);
            workspace.Margin = new Padding(4);
            workspace.Name = "workspace";
            workspace.Size = new Size(1277, 538);
            workspace.TabIndex = 1;
            workspace.CellContentClick += workspace_CellContentClick;
            // 
            // tablechoose
            // 
            tablechoose.AutoCompleteCustomSource.AddRange(new string[] { "Рекламное агенство", "Контрагент", "Клиент", "Закупка", "Продукт", "Партия", "Производитель" });
            tablechoose.FormattingEnabled = true;
            tablechoose.ImeMode = ImeMode.On;
            tablechoose.Items.AddRange(new object[] { "Рекламное агенство", "Контрагент", "Клиент", "Закупка", "Продукт", "Партия", "Производитель" });
            tablechoose.Location = new Point(214, 30);
            tablechoose.Name = "tablechoose";
            tablechoose.RightToLeft = RightToLeft.No;
            tablechoose.Size = new Size(236, 29);
            tablechoose.TabIndex = 2;
            tablechoose.Text = "<Выберите таблицу>";
            tablechoose.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            tablechoose.Click += tablechoose_Click;
            // 
            // Columnchooser
            // 
            Columnchooser.FormattingEnabled = true;
            Columnchooser.ImeMode = ImeMode.On;
            Columnchooser.Items.AddRange(new object[] { "Рекламное агенство", "Контрагент", "Клиент", "Закупка", "Продукт", "Партия", "Производитель" });
            Columnchooser.Location = new Point(794, 30);
            Columnchooser.Name = "Columnchooser";
            Columnchooser.RightToLeft = RightToLeft.No;
            Columnchooser.Size = new Size(262, 29);
            Columnchooser.TabIndex = 3;
            Columnchooser.Text = "<Выберите столбец для поиска>";
            Columnchooser.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // searchbox
            // 
            searchbox.Location = new Point(480, 30);
            searchbox.Name = "searchbox";
            searchbox.Size = new Size(227, 29);
            searchbox.TabIndex = 4;
            // 
            // search
            // 
            search.BackColor = SystemColors.ControlLightLight;
            search.Location = new Point(713, 30);
            search.Name = "search";
            search.Size = new Size(75, 29);
            search.TabIndex = 5;
            search.Text = "Поиск";
            search.UseVisualStyleBackColor = false;
            search.Click += search_Click;
            // 
            // Fulltsearch
            // 
            Fulltsearch.AutoSize = true;
            Fulltsearch.Location = new Point(480, 4);
            Fulltsearch.Name = "Fulltsearch";
            Fulltsearch.Size = new Size(187, 25);
            Fulltsearch.TabIndex = 6;
            Fulltsearch.Text = "Полнотекстный поиск";
            Fulltsearch.UseVisualStyleBackColor = true;
            Fulltsearch.Click += Fulltsearch_Click;
            // 
            // infoftsearch
            // 
            infoftsearch.AutoSize = true;
            infoftsearch.BackColor = Color.Transparent;
            infoftsearch.ForeColor = Color.Red;
            infoftsearch.Location = new Point(774, 4);
            infoftsearch.Name = "infoftsearch";
            infoftsearch.Size = new Size(299, 21);
            infoftsearch.TabIndex = 7;
            infoftsearch.Text = "В этом режиме поиск по ID невозможен";
            // 
            // addinf
            // 
            addinf.Location = new Point(13, 90);
            addinf.Name = "addinf";
            addinf.Size = new Size(193, 56);
            addinf.TabIndex = 8;
            addinf.Text = "Добавить запись";
            addinf.UseVisualStyleBackColor = true;
            addinf.Click += addinf_Click;
            // 
            // delif
            // 
            delif.Location = new Point(14, 214);
            delif.Name = "delif";
            delif.Size = new Size(193, 56);
            delif.TabIndex = 9;
            delif.Text = "Удалить запись";
            delif.UseVisualStyleBackColor = true;
            delif.Click += delif_Click;
            // 
            // chnginf
            // 
            chnginf.Location = new Point(14, 152);
            chnginf.Name = "chnginf";
            chnginf.Size = new Size(193, 56);
            chnginf.TabIndex = 10;
            chnginf.Text = "Изменить запись";
            chnginf.UseVisualStyleBackColor = true;
            chnginf.Click += chnginf_Click;
            // 
            // button1
            // 
            button1.Location = new Point(14, 281);
            button1.Name = "button1";
            button1.Size = new Size(83, 78);
            button1.TabIndex = 11;
            button1.Text = "Экспорт данных в word";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(103, 281);
            button2.Name = "button2";
            button2.Size = new Size(103, 78);
            button2.TabIndex = 12;
            button2.Text = "Экспорт данных в Эксель";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // otch
            // 
            otch.Location = new Point(262, 612);
            otch.Margin = new Padding(4);
            otch.Name = "otch";
            otch.Size = new Size(157, 76);
            otch.TabIndex = 13;
            otch.Text = "Запрос \"Клиент\" и \"Контрагент\"";
            otch.UseVisualStyleBackColor = true;
            otch.Click += otch_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(427, 612);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(157, 76);
            button3.TabIndex = 14;
            button3.Text = "Запрос \"Клиент\" и \"Закупка\"";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(592, 612);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(157, 76);
            button4.TabIndex = 15;
            button4.Text = "Запрос \"Производитель\" и \"Партия\"";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(757, 612);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(157, 76);
            button5.TabIndex = 16;
            button5.Text = "Запрос \"Агенство\" и \"Контрагент\"";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(922, 612);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(157, 76);
            button6.TabIndex = 17;
            button6.Text = "Запрос \"Продукт\" и \"Партия\"";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(1087, 612);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(157, 76);
            button7.TabIndex = 18;
            button7.Text = "Запрос \"Клиент\" и \"Агентство\"";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Databaseapplication
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1504, 701);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(otch);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(chnginf);
            Controls.Add(delif);
            Controls.Add(addinf);
            Controls.Add(infoftsearch);
            Controls.Add(Fulltsearch);
            Controls.Add(search);
            Controls.Add(searchbox);
            Controls.Add(Columnchooser);
            Controls.Add(tablechoose);
            Controls.Add(workspace);
            Controls.Add(aplly);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            MaximumSize = new Size(1520, 740);
            MinimumSize = new Size(1520, 740);
            Name = "Databaseapplication";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Databaseapplication";
            Load += Databaseapplication_Load;
            ((System.ComponentModel.ISupportInitialize)workspace).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button aplly;
        public DataGridView workspace;
        private ComboBox tablechoose;
        private ComboBox Columnchooser;
        private TextBox searchbox;
        private Button search;
        private CheckBox Fulltsearch;
        private Label infoftsearch;
        private Button addinf;
        private Button delif;
        private Button chnginf;
        private Button button1;
        private Button button2;
        public Button otch;
        public Button button3;
        public Button button4;
        public Button button5;
        public Button button6;
        public Button button7;
    }
}