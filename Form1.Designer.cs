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
            corexCheckBox = new CheckBox();
            samAccountNameLabel = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // samAccountNameTextBox
            // 
            samAccountNameTextBox.Location = new Point(27, 193);
            samAccountNameTextBox.Name = "samAccountNameTextBox";
            samAccountNameTextBox.Size = new Size(364, 31);
            samAccountNameTextBox.TabIndex = 4;
            // 
            // go
            // 
            go.Location = new Point(27, 288);
            go.Name = "go";
            go.Size = new Size(364, 34);
            go.TabIndex = 1;
            go.Text = "Go";
            go.UseVisualStyleBackColor = true;
            go.Click += go_Click;
            // 
            // informationsTextBos
            // 
            informationsTextBos.Location = new Point(27, 339);
            informationsTextBos.Multiline = true;
            informationsTextBos.Name = "informationsTextBos";
            informationsTextBos.Size = new Size(364, 411);
            informationsTextBos.TabIndex = 3;
            // 
            // corexCheckBox
            // 
            corexCheckBox.AutoSize = true;
            corexCheckBox.Location = new Point(27, 253);
            corexCheckBox.Name = "corexCheckBox";
            corexCheckBox.Size = new Size(201, 29);
            corexCheckBox.TabIndex = 5;
            corexCheckBox.Text = "Corex hesabı var mı?";
            corexCheckBox.UseVisualStyleBackColor = true;
            // 
            // samAccountNameLabel
            // 
            samAccountNameLabel.AutoSize = true;
            samAccountNameLabel.Location = new Point(27, 151);
            samAccountNameLabel.Name = "samAccountNameLabel";
            samAccountNameLabel.Size = new Size(170, 25);
            samAccountNameLabel.TabIndex = 2;
            samAccountNameLabel.Text = "Kullanıcı adını giriniz";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(27, 780);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(364, 387);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(27, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(364, 96);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.WaitOnLoad = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 1213);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(corexCheckBox);
            Controls.Add(informationsTextBos);
            Controls.Add(samAccountNameLabel);
            Controls.Add(go);
            Controls.Add(samAccountNameTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "QRCodeGenerator";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox samAccountNameTextBox;
        private Button go;
        private TextBox informationsTextBos;
        private CheckBox corexCheckBox;
        private Label samAccountNameLabel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
