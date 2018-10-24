using CLB.Infrastructure;
using DapperExtensions;
using DapperExtensions.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLB.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public int CourseRef { get; set; }
        public int UserRef { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set;}


        public CourseStudent()
        {
            StudentName = "";
            StudentNumber = "";
        }

        public int save()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
            using (MySqlConnection cn = DAL.getCn())
            {


                if (this.Id != 0)
                {
                    this.Id = cn.Insert(this);
                }
                else
                {
                    cn.Update(this);
                }
            }

            return this.Id;
        }




    }



}
