using CLB.Infrastructure;
using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using CLB.Models;
using System.Net;

namespace CLB.Models
{
    //kayacan update
    //yaren update
    //seda update
    public enum UserType
    {
        Teacher,
        Student,
        SuperAdmin
    }

    public enum UserState
    {
        NotApproved,
        Approved,
        Locked
    }

    public class User
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Gsm { get; set; }
        public int PhotoRef { get; set; }
        public UserState State { get; set; }
        public string GoogleProfileld { get; set; }
        public string ActivationCode { get; set; }

        public User()
        {
            Email = "";
            State = UserState.Approved;
            PasswordHash = "";
            Gsm = "";
            GoogleProfileld = "";
            ActivationCode = "";

        }




        /// <summary>
        /// Users save to db
        /// </summary>
        /// <returns>A value of 1 is returned for the registered user</returns>
        public Boolean register()

        {
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
            using (MySqlConnection cn = DAL.getCn())
            {

                if (this.Id == 0)
                {
                    int activationCode = new Random().Next(9999);
                    this.ActivationCode = activationCode.ToString("0000");
                    cn.Insert(this);
                    sendEmail();
                    return true;
                }
                else
                {
                    return false;
                }



            }

        }


        /// <summary>
        /// users login to site
        /// </summary>
        /// <returns>A value of 1 is returned for logged in users</returns>
        public Boolean login()
        {
            User control = new User();

            using (MySqlConnection cn = DAL.getCn())
            {
                control = cn.Query<User>("select * from User where Email=@email and PasswordHash=@passwordHash", new { @email = this.Email, @passwordHash = this.PasswordHash }).FirstOrDefault();

                if (control == null)
                {
                    //böyle bir kayıt yok. Başarısız
                    return false;
                }

                else if (State == UserState.NotApproved)
                {
                    //this.State = UserState.NotApproved;
                    //Durum onaylanmamış.Activationcode burada girilmesi istenecek.Kontrol edilip durumu UserState.Approved olarak değiştirilecek.
                }
                else if (State == UserState.Approved)
                {
                    //this.State = UserState.Approved;

                }

                this.Id = control.Id;
                this.Email = control.Email;
                this.UserType = control.UserType;
                this.Gsm = control.Gsm;
                this.PhotoRef = control.PhotoRef;
                this.State = control.State;

            }
            return true;

        }

        /// <summary>
        /// Send the ActivationCode to user to be activated
        /// </summary>
        /// <returns>İf send the activationcode :true </returns>
        public bool sendEmail()
        {
            var fromAddress = new MailAddress("mobilerollcallproject@gmail.com", "MobileRollCall");
            var toAddress = new MailAddress(this.Email, this.NameSurname);
            const string fromPassword = "Elma.lab";
            const string subject = "Hesap Aktivasyonu";
            string body = String.Format("Sayın {0} \r\n aktivasyonunuzu tamamlamak için gerekli olan kodunuz {1}", this.NameSurname, this.ActivationCode);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);

                }
                catch (Exception ex)
                {

                    return false;
                }
                return true;
            }
            //try
            //{


            //    MailMessage message = new MailMessage();
            //    message.From = new MailAddress(this.Email);
            //    message.To.Add(new MailAddress("mobilerollcall@gmail.com"));
            //    message.Subject = RandomNumber.ToString();
            //    ///smtp classı kullanılacak mail göndermek için


            //}
            //catch
            //{

            //}

        }

        /// <summary>
        /// Gets a list of users by filter parameters
        /// </summary>
        /// <param name="filter">Filters records by Email</param>
        /// <param name="userType">-1 for all, 0 : teacher, 1:student , 2 :superAdmin another value for listing by userType</param>
        /// <param name="state">-1 fpl all states</param>
        /// <returns>List of Users</returns>
        public List<User> getList(string filter, int userType, int state)
        {
            List<User> returnValue = new List<User>();

            using (MySqlConnection cn = DAL.getCn())
            {
                if (userType == -1 && state == -1)
                {
                    returnValue = cn.Query<User>("select * from User where Email like @filter", new { @filter = "%" + filter + "%" }).ToList();
                }
                if (userType == -1 && state != -1)
                {
                    returnValue = cn.Query<User>("select * from User where Email like @filter and State=@state", new { @filter = "%" + filter + "%", @userType = userType }).ToList();
                }

                if (userType != -1 && state == -1)
                {
                    returnValue = cn.Query<User>("select * from User where Email like @filter and UserType=@userType", new { @filter = "%" + filter + "%", @userType = userType }).ToList();
                }

                if (userType != -1 && state != -1)
                {
                    returnValue = cn.Query<User>("select * from User where Email like @filter and UserType=@userType and State=@state", new { @filter = "%" + filter + "%", @userType = userType, @state = state }).ToList();
                }

            }

            return returnValue;
        }

    }

}