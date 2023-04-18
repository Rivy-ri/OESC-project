namespace OmegaSportExplorerClub
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            password_tb = new MaterialSkin.Controls.MaterialTextBox();
            username_tb = new MaterialSkin.Controls.MaterialTextBox();
            PB_sending_progress = new MaterialSkin.Controls.MaterialProgressBar();
            label_stage = new MaterialSkin.Controls.MaterialLabel();
            pictureBox1 = new PictureBox();
            code_tb = new MaterialSkin.Controls.MaterialTextBox2();
            send_bt = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            password_verifi_tb = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            email_tb = new MaterialSkin.Controls.MaterialTextBox();
            return_bt = new MaterialSkin.Controls.MaterialButton();
            finish_bt = new MaterialSkin.Controls.MaterialButton();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(password_tb);
            materialCard1.Controls.Add(username_tb);
            materialCard1.Controls.Add(PB_sending_progress);
            materialCard1.Controls.Add(label_stage);
            materialCard1.Controls.Add(pictureBox1);
            materialCard1.Controls.Add(code_tb);
            materialCard1.Controls.Add(send_bt);
            materialCard1.Controls.Add(materialLabel7);
            materialCard1.Controls.Add(materialLabel6);
            materialCard1.Controls.Add(materialLabel4);
            materialCard1.Controls.Add(password_verifi_tb);
            materialCard1.Controls.Add(materialLabel3);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(email_tb);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(17, 51);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(574, 611);
            materialCard1.TabIndex = 0;
            // 
            // password_tb
            // 
            password_tb.AnimateReadOnly = false;
            password_tb.BorderStyle = BorderStyle.None;
            password_tb.Depth = 0;
            password_tb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            password_tb.Hint = "At least 6 characters and at least 1 number";
            password_tb.LeadingIcon = null;
            password_tb.Location = new Point(214, 201);
            password_tb.MaxLength = 20;
            password_tb.MouseState = MaterialSkin.MouseState.OUT;
            password_tb.Multiline = false;
            password_tb.Name = "password_tb";
            password_tb.Password = true;
            password_tb.Size = new Size(271, 50);
            password_tb.TabIndex = 27;
            password_tb.Text = "";
            password_tb.TrailingIcon = null;
            // 
            // username_tb
            // 
            username_tb.AnimateReadOnly = false;
            username_tb.BorderStyle = BorderStyle.None;
            username_tb.Depth = 0;
            username_tb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            username_tb.Hint = "Minimum 3 characters only letters";
            username_tb.LeadingIcon = null;
            username_tb.Location = new Point(214, 123);
            username_tb.MaxLength = 20;
            username_tb.MouseState = MaterialSkin.MouseState.OUT;
            username_tb.Multiline = false;
            username_tb.Name = "username_tb";
            username_tb.Size = new Size(271, 50);
            username_tb.TabIndex = 25;
            username_tb.Text = "";
            username_tb.TrailingIcon = null;
            // 
            // PB_sending_progress
            // 
            PB_sending_progress.Depth = 0;
            PB_sending_progress.Location = new Point(157, 448);
            PB_sending_progress.MouseState = MaterialSkin.MouseState.HOVER;
            PB_sending_progress.Name = "PB_sending_progress";
            PB_sending_progress.Size = new Size(316, 5);
            PB_sending_progress.Style = ProgressBarStyle.Marquee;
            PB_sending_progress.TabIndex = 21;
            // 
            // label_stage
            // 
            label_stage.AutoSize = true;
            label_stage.Depth = 0;
            label_stage.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            label_stage.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            label_stage.Location = new Point(157, 428);
            label_stage.MouseState = MaterialSkin.MouseState.HOVER;
            label_stage.Name = "label_stage";
            label_stage.Size = new Size(88, 17);
            label_stage.TabIndex = 20;
            label_stage.Text = "sending stage";
            label_stage.TextAlign = ContentAlignment.MiddleLeft;
            label_stage.UseAccent = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(37, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // code_tb
            // 
            code_tb.AnimateReadOnly = false;
            code_tb.BackgroundImageLayout = ImageLayout.None;
            code_tb.CharacterCasing = CharacterCasing.Normal;
            code_tb.Depth = 0;
            code_tb.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            code_tb.HideSelection = true;
            code_tb.Hint = "000000";
            code_tb.LeadingIcon = null;
            code_tb.Location = new Point(214, 489);
            code_tb.MaxLength = 32767;
            code_tb.MouseState = MaterialSkin.MouseState.OUT;
            code_tb.Name = "code_tb";
            code_tb.PasswordChar = '\0';
            code_tb.PrefixSuffixText = null;
            code_tb.ReadOnly = false;
            code_tb.RightToLeft = RightToLeft.No;
            code_tb.SelectedText = "";
            code_tb.SelectionLength = 0;
            code_tb.SelectionStart = 0;
            code_tb.ShortcutsEnabled = true;
            code_tb.Size = new Size(259, 48);
            code_tb.TabIndex = 16;
            code_tb.TabStop = false;
            code_tb.TextAlign = HorizontalAlignment.Left;
            code_tb.TrailingIcon = null;
            code_tb.UseSystemPasswordChar = false;
            // 
            // send_bt
            // 
            send_bt.AnimateShowHideButton = true;
            send_bt.Depth = 0;
            send_bt.FlatStyle = FlatStyle.Flat;
            send_bt.Icon = (Image)resources.GetObject("send_bt.Icon");
            send_bt.Location = new Point(443, 367);
            send_bt.MouseState = MaterialSkin.MouseState.HOVER;
            send_bt.Name = "send_bt";
            send_bt.Size = new Size(56, 56);
            send_bt.TabIndex = 17;
            send_bt.Text = "materialFloatingActionButton2";
            send_bt.UseVisualStyleBackColor = true;
            send_bt.Click += send_bt_Click;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(84, 502);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(124, 19);
            materialLabel7.TabIndex = 18;
            materialLabel7.Text = "Verification code:";
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(123, 378);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(85, 19);
            materialLabel6.TabIndex = 14;
            materialLabel6.Text = "Your e-mail:";
            // 
            // materialLabel4
            // 
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            materialLabel4.HighEmphasis = true;
            materialLabel4.Location = new Point(198, 40);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(287, 47);
            materialLabel4.TabIndex = 8;
            materialLabel4.Text = "Registration form";
            // 
            // password_verifi_tb
            // 
            password_verifi_tb.AnimateReadOnly = false;
            password_verifi_tb.BorderStyle = BorderStyle.None;
            password_verifi_tb.Depth = 0;
            password_verifi_tb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            password_verifi_tb.Hint = "Verifi your password";
            password_verifi_tb.LeadingIcon = null;
            password_verifi_tb.Location = new Point(214, 280);
            password_verifi_tb.MaxLength = 20;
            password_verifi_tb.MouseState = MaterialSkin.MouseState.OUT;
            password_verifi_tb.Multiline = false;
            password_verifi_tb.Name = "password_verifi_tb";
            password_verifi_tb.Password = true;
            password_verifi_tb.Size = new Size(271, 50);
            password_verifi_tb.TabIndex = 6;
            password_verifi_tb.Text = "";
            password_verifi_tb.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(46, 294);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(162, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Repeat your password:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(105, 217);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(103, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Your pasword:";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(96, 143);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.RightToLeft = RightToLeft.Yes;
            materialLabel1.Size = new Size(112, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Your username:";
            // 
            // email_tb
            // 
            email_tb.AnimateReadOnly = false;
            email_tb.BorderStyle = BorderStyle.None;
            email_tb.Depth = 0;
            email_tb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            email_tb.Hint = "adress@example.com";
            email_tb.LeadingIcon = null;
            email_tb.Location = new Point(214, 367);
            email_tb.MaxLength = 100;
            email_tb.MouseState = MaterialSkin.MouseState.OUT;
            email_tb.Multiline = false;
            email_tb.Name = "email_tb";
            email_tb.Size = new Size(259, 50);
            email_tb.TabIndex = 26;
            email_tb.Text = "";
            email_tb.TrailingIcon = null;
            // 
            // return_bt
            // 
            return_bt.AutoSize = false;
            return_bt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            return_bt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            return_bt.Depth = 0;
            return_bt.HighEmphasis = true;
            return_bt.Icon = (Image)resources.GetObject("return_bt.Icon");
            return_bt.Location = new Point(35, 639);
            return_bt.Margin = new Padding(4, 6, 4, 6);
            return_bt.MouseState = MaterialSkin.MouseState.HOVER;
            return_bt.Name = "return_bt";
            return_bt.NoAccentTextColor = Color.Empty;
            return_bt.Size = new Size(217, 56);
            return_bt.TabIndex = 2;
            return_bt.Text = "Return";
            return_bt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            return_bt.UseAccentColor = false;
            return_bt.UseVisualStyleBackColor = true;
            return_bt.Click += materialButton2_Click;
            // 
            // finish_bt
            // 
            finish_bt.AutoSize = false;
            finish_bt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            finish_bt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            finish_bt.Depth = 0;
            finish_bt.HighEmphasis = true;
            finish_bt.Icon = (Image)resources.GetObject("finish_bt.Icon");
            finish_bt.Location = new Point(356, 639);
            finish_bt.Margin = new Padding(4, 6, 4, 6);
            finish_bt.MouseState = MaterialSkin.MouseState.HOVER;
            finish_bt.Name = "finish_bt";
            finish_bt.NoAccentTextColor = Color.Empty;
            finish_bt.Size = new Size(217, 56);
            finish_bt.TabIndex = 3;
            finish_bt.Text = "Finish registration";
            finish_bt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            finish_bt.UseAccentColor = false;
            finish_bt.UseVisualStyleBackColor = true;
            finish_bt.Click += finish_bt_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 713);
            Controls.Add(finish_bt);
            Controls.Add(return_bt);
            Controls.Add(materialCard1);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Registration";
            Padding = new Padding(3, 24, 3, 3);
            Sizable = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            FormClosed += Registration_FormClosed;
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox password_verifi_tb;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialButton return_bt;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox2 code_tb;
        private MaterialSkin.Controls.MaterialFloatingActionButton send_bt;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton finish_bt;
        private MaterialSkin.Controls.MaterialProgressBar PB_sending_progress;
        private MaterialSkin.Controls.MaterialLabel label_stage;
        private MaterialSkin.Controls.MaterialTextBox password_tb;
        private MaterialSkin.Controls.MaterialTextBox username_tb;
        private MaterialSkin.Controls.MaterialTextBox email_tb;
    }
}