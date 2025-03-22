namespace QRCodeGenerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            samAccountNameTextBox = new TextBox();
            go = new Button();
            informationsTextBos = new TextBox();
            samAccountNameLabel = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // samAccountNameTextBox
            // 
            samAccountNameTextBox.Location = new Point(22, 59);
            samAccountNameTextBox.Margin = new Padding(2, 2, 2, 2);
            samAccountNameTextBox.Name = "samAccountNameTextBox";
            samAccountNameTextBox.Size = new Size(292, 27);
            samAccountNameTextBox.TabIndex = 4;
            // 
            // go
            // 
            go.Location = new Point(22, 112);
            go.Margin = new Padding(2, 2, 2, 2);
            go.Name = "go";
            go.Size = new Size(291, 27);
            go.TabIndex = 1;
            go.Text = "Go";
            go.UseVisualStyleBackColor = true;
            go.Click += go_Click;
            // 
            // informationsTextBos
            // 
            informationsTextBos.Location = new Point(21, 162);
            informationsTextBos.Margin = new Padding(2, 2, 2, 2);
            informationsTextBos.Multiline = true;
            informationsTextBos.Name = "informationsTextBos";
            informationsTextBos.Size = new Size(292, 330);
            informationsTextBos.TabIndex = 3;
            // 
            // samAccountNameLabel
            // 
            samAccountNameLabel.AutoSize = true;
            samAccountNameLabel.Location = new Point(22, 26);
            samAccountNameLabel.Margin = new Padding(2, 0, 2, 0);
            samAccountNameLabel.Name = "samAccountNameLabel";
            samAccountNameLabel.Size = new Size(147, 20);
            samAccountNameLabel.TabIndex = 2;
            samAccountNameLabel.Text = "Kullanıcı adını giriniz";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(22, 508);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(291, 310);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 844);
            Controls.Add(pictureBox1);
            Controls.Add(informationsTextBos);
            Controls.Add(samAccountNameLabel);
            Controls.Add(go);
            Controls.Add(samAccountNameTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "QRCodeGenerator";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox samAccountNameTextBox;
        private Button go;
        private TextBox informationsTextBos;
        private Label samAccountNameLabel;
        private PictureBox pictureBox1;
    }
}
