namespace formLogin
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
            login_button = new Button();
            userInput_label = new Label();
            userInput_textBox = new TextBox();
            passwordInput_textBox = new TextBox();
            passwordInput_label = new Label();
            status_label = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // login_button
            // 
            login_button.Location = new Point(209, 226);
            login_button.Margin = new Padding(3, 2, 3, 2);
            login_button.Name = "login_button";
            login_button.Size = new Size(108, 40);
            login_button.TabIndex = 0;
            login_button.Text = "Logar";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += login_button_Click;
            // 
            // userInput_label
            // 
            userInput_label.AutoSize = true;
            userInput_label.Location = new Point(60, 142);
            userInput_label.Name = "userInput_label";
            userInput_label.Size = new Size(47, 15);
            userInput_label.TabIndex = 1;
            userInput_label.Text = "Usuário";
            // 
            // userInput_textBox
            // 
            userInput_textBox.Location = new Point(117, 140);
            userInput_textBox.Margin = new Padding(3, 2, 3, 2);
            userInput_textBox.Name = "userInput_textBox";
            userInput_textBox.Size = new Size(200, 23);
            userInput_textBox.TabIndex = 2;
            // 
            // passwordInput_textBox
            // 
            passwordInput_textBox.Location = new Point(117, 169);
            passwordInput_textBox.Margin = new Padding(3, 2, 3, 2);
            passwordInput_textBox.Name = "passwordInput_textBox";
            passwordInput_textBox.Size = new Size(200, 23);
            passwordInput_textBox.TabIndex = 4;
            // 
            // passwordInput_label
            // 
            passwordInput_label.AutoSize = true;
            passwordInput_label.Location = new Point(60, 171);
            passwordInput_label.Name = "passwordInput_label";
            passwordInput_label.Size = new Size(39, 15);
            passwordInput_label.TabIndex = 3;
            passwordInput_label.Text = "Senha";
            // 
            // status_label
            // 
            status_label.AutoSize = true;
            status_label.Location = new Point(269, 268);
            status_label.Name = "status_label";
            status_label.Size = new Size(0, 15);
            status_label.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(144, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 129);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(442, 338);
            Controls.Add(pictureBox1);
            Controls.Add(status_label);
            Controls.Add(passwordInput_textBox);
            Controls.Add(passwordInput_label);
            Controls.Add(userInput_textBox);
            Controls.Add(userInput_label);
            Controls.Add(login_button);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login_button;
        private Label userInput_label;
        private TextBox userInput_textBox;
        private TextBox passwordInput_textBox;
        private Label passwordInput_label;
        private Label status_label;
        private PictureBox pictureBox1;
    }
}
