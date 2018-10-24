using CLB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Email adresi giriniz");

            User newUser = new User()
            {
                Email = "aleyna.kocak.7@gmail.com",
                NameSurname="Aleyna Koçak",
                PasswordHash="123",
                Gsm="0123123"
            };

            if (newUser.register() == true)
            {
                Console.WriteLine("Kayıt eklendi");
            }
            else
            {
                Console.WriteLine("Kayıt eklenemedi");

            }
            
            Console.ReadKey();
             
            
        }
    }
}
