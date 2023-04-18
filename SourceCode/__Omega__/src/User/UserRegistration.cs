using MailKit.Net.Smtp;
using MailKit.Security;
using MaterialSkin.Controls;
using MimeKit;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.Other;
using OmegaSportExplorerClub.src.User.VerifyRegistrationCommands;
using System.Configuration;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.User
{
    /// <summary>
    /// Class is responsible for registering new users into the system. It contains methods to send a verification code to the user's email, generate a verification code, and finish the registration process by saving user details into the database.
    /// </summary>
    public class UserRegistration
    {
        /// <summary>
        /// property of type User that holds the user details.
        /// </summary>
        private User User;
        /// <summary>
        /// Create an user registration object
        /// </summary>
        /// <param name="user"> user that we want to transform in to regitration</param>
        public UserRegistration(User user)
        {
            User1 = user;
        }

        public User User1 { get => User; set => User = value; }

        /// <summary>
        /// Method will send verification code on new user email
        /// </summary>
        /// <param name="bar">progress of sending an verification code</param>
        /// <param name="label">text notification about satte of sending email</param>
        public void SendVerificationCode(MaterialProgressBar bar, MaterialLabel label)
        {
            bar.Value = 10;
            label.Text = "Sending started";
            if (new VerifyEmailInDatabase().verify(User.Email) == true || new MyRegex(User.Email).CheckEmail() == false)
            {
                bar.Value = 0;

                label.Text = "sending failed";
                MessageBox.Show($"Sending failed,{User.Email} already has account or it is not an email.");
                return;

            }
            else
            {
                bar.Value = 20;
                var message = GetMessage();

                try
                {
                    var client = new SmtpClient();
                    Thread sendHandle = new Thread(() =>
                    {
                    try {
                        client.Connect(ConfigurationManager.AppSettings["SmtpEmail"], Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]), true);
                        client.Authenticate(ConfigurationManager.AppSettings["RegistrationEmailSenderEmail"].ToString().Trim(), ConfigurationManager.AppSettings["RegistrationEmailSenderPassword"].ToString().Trim());
                        client.Send(message);
                        client.Disconnect(true);
                        }
                        catch (System.Net.Sockets.SocketException e)
                        {
                            MessageBox.Show(e.Message);
                        }

                    });

                    label.Text = "Sending an email";
                    bar.Value = 50;
                    sendHandle.Start();
                    bar.Value = 70;
                    if (sendHandle.ThreadState == ThreadState.Running)
                    {
                        sendHandle.Join();
                    }
                    label.Text = "sending has been finished from app";
                    bar.Value = 100;
                    return;

                }
                catch (Exception)
                {
                    label.Text = "sending failed";
                    bar.Value = 0;
                }
            }


        }
        /// <summary>
        /// Method will generate verification code for registration
        /// </summary>
        /// <returns>verification code</returns>
        private string GenerateVerificationCode()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            string verification_code = "";
            bool in_database = true;
            while (true)
            {
                var i = random.Next(chars.Length);
                verification_code += chars[i];

                if (verification_code.Length >= 6)
                {
                    in_database = new VerifyCodeInDatabase().verify(verification_code);
                    if (in_database == false)
                    {
                        return verification_code;
                    }
                    else
                    {
                        continue;
                    }


                }
                else
                {
                    continue;
                }


            }

        }


        /// <summary>
        /// Method will finish registration and insert new user in to database
        /// </summary>
        /// <returns>true if registration was successful false if not</returns>
        public bool FinishRegistration()
        {
            SqlConnection connection = ConnectionSingleton.Connection();
            try
            {
                using (SqlCommand command = new SqlCommand("Insert into [dbo].[AplicationUser] (name,[verification_code],[email],[salt],[hash]) values(@username,@verificationcode,@email,@salt,@hash);", connection))
                {
                    SqlParameter userName = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
                    SqlParameter verificationCode = new SqlParameter("@verificationcode", System.Data.SqlDbType.VarChar);
                    SqlParameter email = new SqlParameter("@email", System.Data.SqlDbType.VarChar);
                    SqlParameter salt = new SqlParameter("@salt", System.Data.SqlDbType.VarChar);
                    SqlParameter hash = new SqlParameter("@hash", System.Data.SqlDbType.VarChar);

                    if (new VerifyUserNameInDatabase().verify(User.UserName) == true || new MyRegex(User.Password).CheckPassword() == false)
                    {
                        MessageBox.Show("Registration failed dude to already existing user name or wrong format of password.");
                        return false;

                    }
                    userName.Value = User.UserName;
                    verificationCode.Value = User.VerificationCode;
                    email.Value = User.Email;
                    salt.Value = User.Salt;
                    hash.Value = User.Hash;
                    command.Parameters.Add(userName);
                    command.Parameters.Add(verificationCode);
                    command.Parameters.Add(salt);
                    command.Parameters.Add(hash);
                    command.Parameters.Add(email);
                    var result = Convert.ToInt32(command.ExecuteNonQuery());
                    if (result > 0)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// Method will create an email message of type mime message
        /// </summary>
        /// <returns>Mimemessage message to send on users email </returns>
        private MimeMessage GetMessage()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Oesc", ConfigurationManager.AppSettings["RegistrationEmailSenderEmail"]));
            message.To.Add(new MailboxAddress("Recipient Name", User.Email));
            message.Subject = "Verification code for oesc";
            var verification_code = GenerateVerificationCode();
            string body = $"Verification code for your account is: {verification_code} \n Date of sending: {DateTime.Now} \n Thank you for using Oesc!";
            message.Body = new TextPart("plain") { Text = body };
            User.VerificationCode = verification_code;
            return message;
        }


    }

}
