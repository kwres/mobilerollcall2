using CLB.Models;
using System;
using System.Collections.Generic;

namespace ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<User> users = new User().getList("",-1,-1);
            foreach(var user in users)
            {
                Console.WriteLine(user.Email);
            }

            Course course = new Course() {
                CourseName="Mobil I",
                Teorical=1,
                Practical=2,
                UserRef=1,
                StartDate=DateTime.Now,
                EndDate=DateTime.Now.AddDays(98),
                TotalWeeks=14,

                CourseTimes =new List<CourseTime>() {
                    new CourseTime(){
                        Day =Day.Monday,
                        StartDate =DateTime.Now.Date + new TimeSpan(14,0,0),
                        EndDate =DateTime.Now.Date + new TimeSpan(14,45,0),
                        Duration=45,
                        CourseType=CourseType.Teorical
                    },
                     new CourseTime(){
                        Day =Day.Monday,
                        StartDate =DateTime.Now.Date + new TimeSpan(15,0,0),
                        EndDate =DateTime.Now.Date + new TimeSpan(15,45,0),
                        Duration=45,
                        CourseType=CourseType.Practical
                    }, new CourseTime(){
                        Day =Day.Monday,
                        StartDate =DateTime.Now.Date + new TimeSpan(16,0,0),
                        EndDate =DateTime.Now.Date + new TimeSpan(16,45,0),
                        Duration=45,
                        CourseType=CourseType.Practical
                    }
                }
            };

            int control = course.save();
            Console.WriteLine("Control value : {0}" + control);


            Console.ReadLine();
        }
    }
}
