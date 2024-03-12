namespace OOAPwithPattern
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.drawTriangle = new System.Windows.Forms.Button();
            this.drawCircle = new System.Windows.Forms.Button();
            this.drawRectangle = new System.Windows.Forms.Button();
            this.drawBoard = new System.Windows.Forms.PictureBox();
            this.eraseButton = new System.Windows.Forms.Button();
            this.fillButton = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.colorPanel);
            this.panel1.Controls.Add(this.fillButton);
            this.panel1.Controls.Add(this.eraseButton);
            this.panel1.Controls.Add(this.drawTriangle);
            this.panel1.Controls.Add(this.drawCircle);
            this.panel1.Controls.Add(this.drawRectangle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 91);
            this.panel1.TabIndex = 0;
            // 
            // drawTriangle
            // 
            this.drawTriangle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.drawTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawTriangle.Image = global::OOAPwithPattern.Properties.Resources.triangle_icon;
            this.drawTriangle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.drawTriangle.Location = new System.Drawing.Point(508, 23);
            this.drawTriangle.Name = "drawTriangle";
            this.drawTriangle.Size = new System.Drawing.Size(97, 47);
            this.drawTriangle.TabIndex = 2;
            this.drawTriangle.Text = "Треугольник";
            this.drawTriangle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.drawTriangle.UseVisualStyleBackColor = false;
            this.drawTriangle.Click += new System.EventHandler(this.drawTriangle_Click);
            // 
            // drawCircle
            // 
            this.drawCircle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.drawCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawCircle.Image = global::OOAPwithPattern.Properties.Resources.circle_icon;
            this.drawCircle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.drawCircle.Location = new System.Drawing.Point(611, 23);
            this.drawCircle.Name = "drawCircle";
            this.drawCircle.Size = new System.Drawing.Size(97, 47);
            this.drawCircle.TabIndex = 1;
            this.drawCircle.Text = "Круг";
            this.drawCircle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.drawCircle.UseVisualStyleBackColor = false;
            this.drawCircle.Click += new System.EventHandler(this.drawCircle_Click);
            // 
            // drawRectangle
            // 
            this.drawRectangle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.drawRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.drawRectangle.Image = global::OOAPwithPattern.Properties.Resources.rectangle_icon;
            this.drawRectangle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.drawRectangle.Location = new System.Drawing.Point(714, 23);
            this.drawRectangle.Name = "drawRectangle";
            this.drawRectangle.Size = new System.Drawing.Size(97, 47);
            this.drawRectangle.TabIndex = 0;
            this.drawRectangle.Text = "Прямоугольник";
            this.drawRectangle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.drawRectangle.UseVisualStyleBackColor = false;
            this.drawRectangle.Click += new System.EventHandler(this.drawRectangle_Click);
            // 
            // drawBoard
            // 
            this.drawBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawBoard.Location = new System.Drawing.Point(0, 91);
            this.drawBoard.Name = "drawBoard";
            this.drawBoard.Size = new System.Drawing.Size(908, 513);
            this.drawBoard.TabIndex = 1;
            this.drawBoard.TabStop = false;
            this.drawBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawBoard_MouseClick);
            this.drawBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawBoard_MouseDown);
            this.drawBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawBoard_MouseUp);
            // 
            // eraseButton
            // 
            this.eraseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.eraseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eraseButton.Image = global::OOAPwithPattern.Properties.Resources.erase_icon;
            this.eraseButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.eraseButton.Location = new System.Drawing.Point(405, 23);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(97, 47);
            this.eraseButton.TabIndex = 3;
            this.eraseButton.Text = "Удалить";
            this.eraseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.eraseButton.UseVisualStyleBackColor = false;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // fillButton
            // 
            this.fillButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fillButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillButton.Image = global::OOAPwithPattern.Properties.Resources.fill_icon;
            this.fillButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.fillButton.Location = new System.Drawing.Point(302, 23);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(97, 47);
            this.fillButton.TabIndex = 4;
            this.fillButton.Text = "Заливка";
            this.fillButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fillButton.UseVisualStyleBackColor = false;
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.colorPanel.Location = new System.Drawing.Point(43, 24);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(70, 45);
            this.colorPanel.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 604);
            this.Controls.Add(this.drawBoard);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button drawRectangle;
        private System.Windows.Forms.PictureBox drawBoard;
        private System.Windows.Forms.Button drawTriangle;
        private System.Windows.Forms.Button drawCircle;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.Panel colorPanel;
    }
}

