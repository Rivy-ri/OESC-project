using MaterialSkin;
using MaterialSkin.Controls;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.Other;
using OmegaSportExplorerClub.src.User;


namespace OmegaSportExplorerClub
{
    public partial class Registration : MaterialForm
    {
        private static Registration instance = null;

        new MyRegex regex = new MyRegex("");
        public Registration()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Color.FromArgb(177, 195, 88), Color.FromArgb(64, 64, 64), Color.FromArgb(255, 255, 252), Color.FromArgb(177, 195, 88), TextShade.BLACK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn.GetInstance().Show();
        }

        private void finish_bt_Click(object sender, EventArgs e)
        {
            regex.Text = username_tb.Text;
            bool usernameValidation = regex.CheckUserName();
            regex.Text = password_tb.Text;
            bool passwordValidation = regex.CheckPassword();

            if (password_tb.Text == password_verifi_tb.Text)
            {
                if (SqlInjectionCheck.Check_text(password_tb.Text) == false && usernameValidation == true && passwordValidation == true)
                {


                    User user = new User(username_tb.Text, password_tb.Text, email_tb.Text, code_tb.Text);
                    var result = new UserRegistration(user).FinishRegistration();
                    if (result == true)
                    {
                        MessageBox.Show("registration was successful!");
                    }
                    else
                    {
                        MessageBox.Show("registration was not successful");

                    }
                }
                else
                {
                    MessageBox.Show("invalid user name or password", "registration info");
                }


            }
            else
            {
                MessageBox.Show("password doesn't match", "registration info");
                username_tb.SetErrorState(usernameValidation == true);
                password_tb.SetErrorState(passwordValidation == true);


            }
        }

        private void send_bt_Click(object sender, EventArgs e)
        {
            User user = new User(email_tb.Text);
            UserRegistration ur = new UserRegistration(user);
            ur.SendVerificationCode(PB_sending_progress, label_stage);
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void username_tb_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public static Registration GetInstance()
        {
            if (instance == null)
            {
                instance = new Registration();
            }
            return instance;

        }
    }
}
