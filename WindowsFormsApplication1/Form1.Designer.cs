namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеЗолодильникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискХолодильникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файоToolStripMenuItem,
            this.добавлениеЗолодильникаToolStripMenuItem,
            this.поискХолодильникаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файоToolStripMenuItem
            // 
            this.файоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem1,
            this.новыйToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem1,
            this.отчетВExcelToolStripMenuItem});
            this.файоToolStripMenuItem.Name = "файоToolStripMenuItem";
            this.файоToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файоToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem1.Text = "Открыть";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem1
            // 
            this.сохранитьКакToolStripMenuItem1.Name = "сохранитьКакToolStripMenuItem1";
            this.сохранитьКакToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.сохранитьКакToolStripMenuItem1.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem1.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem1_Click);
            // 
            // добавлениеЗолодильникаToolStripMenuItem
            // 
            this.добавлениеЗолодильникаToolStripMenuItem.Name = "добавлениеЗолодильникаToolStripMenuItem";
            this.добавлениеЗолодильникаToolStripMenuItem.Size = new System.Drawing.Size(196, 20);
            this.добавлениеЗолодильникаToolStripMenuItem.Text = "Редактирование холодильников";
            this.добавлениеЗолодильникаToolStripMenuItem.Click += new System.EventHandler(this.добавлениеХолодильникаToolStripMenuItem_Click);
            // 
            // поискХолодильникаToolStripMenuItem
            // 
            this.поискХолодильникаToolStripMenuItem.Name = "поискХолодильникаToolStripMenuItem";
            this.поискХолодильникаToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.поискХолодильникаToolStripMenuItem.Text = "Поиск холодильника";
            this.поискХолодильникаToolStripMenuItem.Click += new System.EventHandler(this.поискХолодильникаToolStripMenuItem_Click);
            // 
            // отчетВExcelToolStripMenuItem
            // 
            this.отчетВExcelToolStripMenuItem.Name = "отчетВExcelToolStripMenuItem";
            this.отчетВExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отчетВExcelToolStripMenuItem.Text = "Отчет в Excel";
            this.отчетВExcelToolStripMenuItem.Click += new System.EventHandler(this.отчетВExcelToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1104, 469);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Fridges";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавлениеЗолодильникаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискХолодильникаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem отчетВExcelToolStripMenuItem;
    }
}

