using OmegaSportExplorerClub;
using MaterialSkin;
using MaterialSkin.Controls;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.User;
using System.Data.SqlClient;


namespace OmegaSportExplorerClub
{
    public partial class LogIn : MaterialForm
    {
        private static LogIn instance = null;

        public LogIn()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Color.FromArgb(177, 195, 88), Color.FromArgb(64, 64, 64), Color.FromArgb(255, 255, 252), Color.FromArgb(177, 195, 88), TextShade.BLACK);
            button_log_in.BackColor = materialSkinManager.ColorScheme.AccentColor;
            button_log_in.AutoSize = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Task.Run(() =>
            {
                if (ConnectionSingleton.Connection() is SqlConnection && instance is not null)
                {

                    StateNotification.BalloonTipText = "Oesc has successfully connected to the database";
                    StateNotification.Icon = SystemIcons.Application;
                    StateNotification.ShowBalloonTip(5000);
                    ConnectionSingleton.ConnectionNotification(materialFloatingActionButton2);


                }
                else
                {
                    StateNotification.BalloonTipText = "Oesc failed to connect to the database";
                    StateNotification.Icon = SystemIcons.Error;
                    StateNotification.ShowBalloonTip(5000);
                    ConnectionSingleton.ConnectionNotification(materialFloatingActionButton2);


                }
            });





        }
        private void button_log_in_Click_1(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            User user = new User(Name_log_in.Text, Password_log_in.Text);
            UserLogIn logIn = new UserLogIn(user);

            var result = logIn.Verification();
            if (result == true)
            {
                if (ChBRememberMe.Checked == true)
                {
                    UserLogIn.RememberMe(ChBRememberMe, Name_log_in.Text, Password_log_in.Text);
                }
                this.Hide();
                Cursor.Current = Cursors.Default;
                MainMeny.GetInstance(user.UserName).Show();
            }



        }


        private void L_registration_Click(object sender, EventArgs e)
        {
            try { 
            if (ConnectionSingleton.Connection().State == System.Data.ConnectionState.Open)
            {
                this.Hide();
                Registration registration = new Registration();
                registration.Show();
            }
            else
            {
                    throw new NullReferenceException();
            }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Aplication is not connected to database, please wait");
            }


        }

        private void Log_in_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Log_in_Load(object sender, EventArgs e)
        {
            UserLogIn.RememberMeLoad(ChBRememberMe, Name_log_in, Password_log_in);
        }

        private void ChBRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            UserLogIn.RememberMe(ChBRememberMe, Name_log_in.Text, Password_log_in.Text);
        }
        public static LogIn GetInstance()
        {
            if (instance == null)
            {
                instance = new LogIn();
            }
            return instance;

        }
    }
}
