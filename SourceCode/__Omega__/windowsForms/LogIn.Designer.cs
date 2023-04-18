namespace OmegaSportExplorerClub
{
    partial class LogIn
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ChBRememberMe = new MaterialSkin.Controls.MaterialCheckbox();
            pictureBox1 = new PictureBox();
            L_registration = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            button_log_in = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            Password_log_in = new MaterialSkin.Controls.MaterialTextBox2();
            Name_log_in = new MaterialSkin.Controls.MaterialTextBox2();
            materialFloatingActionButton2 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            StateNotification = new NotifyIcon(components);
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(ChBRememberMe);
            materialCard1.Controls.Add(pictureBox1);
            materialCard1.Controls.Add(L_registration);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(button_log_in);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(Password_log_in);
            materialCard1.Controls.Add(Name_log_in);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(33, 53);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(383, 521);
            materialCard1.TabIndex = 0;
            // 
            // ChBRememberMe
            // 
            ChBRememberMe.AutoSize = true;
            ChBRememberMe.Depth = 0;
            ChBRememberMe.Location = new Point(48, 386);
            ChBRememberMe.Margin = new Padding(0);
            ChBRememberMe.MouseLocation = new Point(-1, -1);
            ChBRememberMe.MouseState = MaterialSkin.MouseState.HOVER;
            ChBRememberMe.Name = "ChBRememberMe";
            ChBRememberMe.ReadOnly = false;
            ChBRememberMe.Ripple = true;
            ChBRememberMe.Size = new Size(137, 37);
            ChBRememberMe.TabIndex = 6;
            ChBRememberMe.Text = "Remember me";
            ChBRememberMe.UseVisualStyleBackColor = true;
            ChBRememberMe.CheckedChanged += ChBRememberMe_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(80, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(216, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // L_registration
            // 
            L_registration.AutoSize = true;
            L_registration.Cursor = Cursors.Hand;
            L_registration.Depth = 0;
            L_registration.FlatStyle = FlatStyle.Popup;
            L_registration.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            L_registration.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            L_registration.HighEmphasis = true;
            L_registration.Location = new Point(80, 466);
            L_registration.MouseState = MaterialSkin.MouseState.HOVER;
            L_registration.Name = "L_registration";
            L_registration.Size = new Size(215, 17);
            L_registration.TabIndex = 4;
            L_registration.Text = "Doesn't have an account? register";
            L_registration.UseAccent = true;
            L_registration.Click += L_registration_Click;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(56, 285);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(66, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Pssword:";
            // 
            // button_log_in
            // 
            button_log_in.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_log_in.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button_log_in.Depth = 0;
            button_log_in.HighEmphasis = true;
            button_log_in.Icon = null;
            button_log_in.Location = new Point(248, 385);
            button_log_in.Margin = new Padding(4, 6, 4, 6);
            button_log_in.MouseState = MaterialSkin.MouseState.HOVER;
            button_log_in.Name = "button_log_in";
            button_log_in.NoAccentTextColor = Color.Empty;
            button_log_in.Size = new Size(68, 36);
            button_log_in.TabIndex = 1;
            button_log_in.Text = "Log in";
            button_log_in.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button_log_in.UseAccentColor = false;
            button_log_in.UseVisualStyleBackColor = true;
            button_log_in.Click += button_log_in_Click_1;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(56, 186);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(76, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Username:";
            // 
            // Password_log_in
            // 
            Password_log_in.AnimateReadOnly = true;
            Password_log_in.BackgroundImageLayout = ImageLayout.None;
            Password_log_in.CharacterCasing = CharacterCasing.Normal;
            Password_log_in.Depth = 0;
            Password_log_in.ErrorMessage = "wrong password";
            Password_log_in.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Password_log_in.HelperText = "Enter your password..";
            Password_log_in.HideSelection = true;
            Password_log_in.Hint = "Enter your password..";
            Password_log_in.LeadingIcon = (Image)resources.GetObject("Password_log_in.LeadingIcon");
            Password_log_in.Location = new Point(48, 307);
            Password_log_in.MaxLength = 32767;
            Password_log_in.MouseState = MaterialSkin.MouseState.OUT;
            Password_log_in.Name = "Password_log_in";
            Password_log_in.PasswordChar = '●';
            Password_log_in.PrefixSuffixText = null;
            Password_log_in.ReadOnly = false;
            Password_log_in.RightToLeft = RightToLeft.No;
            Password_log_in.SelectedText = "";
            Password_log_in.SelectionLength = 0;
            Password_log_in.SelectionStart = 0;
            Password_log_in.ShortcutsEnabled = true;
            Password_log_in.Size = new Size(268, 48);
            Password_log_in.TabIndex = 1;
            Password_log_in.TabStop = false;
            Password_log_in.TextAlign = HorizontalAlignment.Left;
            Password_log_in.TrailingIcon = null;
            Password_log_in.UseSystemPasswordChar = true;
            // 
            // Name_log_in
            // 
            Name_log_in.AnimateReadOnly = true;
            Name_log_in.BackgroundImageLayout = ImageLayout.None;
            Name_log_in.CharacterCasing = CharacterCasing.Normal;
            Name_log_in.Depth = 0;
            Name_log_in.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Name_log_in.HelperText = "Enter your userename..";
            Name_log_in.HideSelection = true;
            Name_log_in.Hint = "Enter your userename..";
            Name_log_in.LeadingIcon = (Image)resources.GetObject("Name_log_in.LeadingIcon");
            Name_log_in.Location = new Point(48, 208);
            Name_log_in.MaxLength = 32767;
            Name_log_in.MouseState = MaterialSkin.MouseState.OUT;
            Name_log_in.Name = "Name_log_in";
            Name_log_in.PasswordChar = '\0';
            Name_log_in.PrefixSuffixText = null;
            Name_log_in.ReadOnly = false;
            Name_log_in.RightToLeft = RightToLeft.No;
            Name_log_in.SelectedText = "";
            Name_log_in.SelectionLength = 0;
            Name_log_in.SelectionStart = 0;
            Name_log_in.ShortcutsEnabled = true;
            Name_log_in.Size = new Size(268, 48);
            Name_log_in.TabIndex = 0;
            Name_log_in.TabStop = false;
            Name_log_in.TextAlign = HorizontalAlignment.Left;
            Name_log_in.TrailingIcon = null;
            Name_log_in.UseSystemPasswordChar = false;
            // 
            // materialFloatingActionButton2
            // 
            materialFloatingActionButton2.Depth = 0;
            materialFloatingActionButton2.DrawShadows = false;
            materialFloatingActionButton2.Enabled = false;
            materialFloatingActionButton2.FlatStyle = FlatStyle.Popup;
            materialFloatingActionButton2.Icon = Properties.Resources.no_wifi;
            materialFloatingActionButton2.Location = new Point(17, 27);
            materialFloatingActionButton2.Mini = true;
            materialFloatingActionButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton2.Name = "materialFloatingActionButton2";
            materialFloatingActionButton2.Size = new Size(40, 40);
            materialFloatingActionButton2.TabIndex = 7;
            materialFloatingActionButton2.Text = "c";
            materialFloatingActionButton2.UseVisualStyleBackColor = true;
            // 
            // StateNotification
            // 
            StateNotification.BalloonTipIcon = ToolTipIcon.Info;
            StateNotification.Text = "OESC-running";
            StateNotification.Visible = true;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 604);
            Controls.Add(materialFloatingActionButton2);
            Controls.Add(materialCard1);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogIn";
            Padding = new Padding(3, 24, 3, 3);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log_in";
            FormClosing += Log_in_FormClosing;
            Load += Log_in_Load;
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton button_log_in;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 Password_log_in;
        private MaterialSkin.Controls.MaterialTextBox2 Name_log_in;
        private MaterialSkin.Controls.MaterialLabel L_registration;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialCheckbox ChBRememberMe;
        private NotifyIcon StateNotification;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton2;
    }
}