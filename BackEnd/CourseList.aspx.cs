using CLB.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd
{
    public partial class CourseList : System.Web.UI.Page
    {

        public Course Course
        {
            get
            {
                Course r = new Course();
                r.Id = Convert.ToInt32(hdnID.Value);
                r.CourseName = txtCourseName.Text;
                r.Theorical = Convert.ToInt32(txtTheorical.Value);
                r.Practical = Convert.ToInt32(txtPractical.Value);
                r.StartDate = Convert.ToDateTime(txtStartDate.Value);
                r.EndDate = Convert.ToDateTime(txtEndDate.Value);
                r.TotalWeeks = Convert.ToInt32(txtTotalWeeks.Value);
                r.UserRef = 1;
                return r;
            }
            set
            {
                hdnID.SetValue(value.Id);
                txtCourseName.SetValue(value.CourseName);
                txtTheorical.SetValue(value.Theorical);
                txtPractical.SetValue(value.Practical);
                txtStartDate.SetValue(value.StartDate);
                txtEndDate.SetValue(value.EndDate);
                txtTotalWeeks.SetValue(value.TotalWeeks);
            }
        }


        public CourseTime CourseTime
        {
            get
            {
                CourseTime r = new CourseTime();

                return r;
            }
            set
            {

            }
        }


        public CourseStudent CourseStudent
        {
            get
            {
                CourseStudent r = new CourseStudent();
                return r;
            }
            set
            {

            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void Command(object sender, Ext.Net.DirectEventArgs e)
        {
            string commanName = e.ExtraParams["command"];
            int Id = Convert.ToInt32(e.ExtraParams["Id"]);
            switch (commanName)
            {
                case "Update":
                    update(Id);
                    break;

                case "CourseTimes":
                    courseTime(Id);
                    break;
                case "StudentList":
                    studentList(Id);
                    break;
                case "RollCallList":
                    rollBack(Id);
                    break;


            }


           


                /*
                int Id = Convert.ToInt32(e.ExtraParams["Id"]);
                string courseName = e.ExtraParams["CN"];
                X.Msg.Alert("UYARI", e.ExtraParams["command"] + "-" + Id.ToString() + "-" + courseName).Show();  
                */
            }




        //public void CommandTime(object sender, Ext.Net.DirectEventArgs e)
        //{
        //    string commanName = e.ExtraParams["commandCourse"];
        //    int Id = Convert.ToInt32(e.ExtraParams["Id"]);
        //    switch (commanName)
        //    {
        //        case "UpdateCourse":
        //            update(Id);
        //            break;

        //    }
        //}

        private void update(int Id)
        {
            Course = new Course() { Id = Id }.get();
            //Course.StartDate = Convert.ToDateTime(txtStartDate.Value);
            //Course.EndDate = Convert.ToDateTime(txtEndDate.Value);
            //string baslangıc = Convert.ToString(txtStartDate.Value);
            //string bitis = Convert.ToString(txtEndDate.Value);
            //if (baslangıc != "" && bitis!="")
            //{
            //    week(baslangıc, bitis);
            //}
           

            wndNew.Show();
        }

        ////private int week(string baslangıc, string bitis)
        ////{

        ////    return 0;
        ////}

       
        private void courseTime(int Id)
        {
            Course = new Course() { Id = Id }.get();
            
            winCourseTime.Show();
        }

        private void studentList(int Id)
        {
            Course = new Course() { Id = Id }.get();
            winStudentList.Show();
        }

        public void rollBack(int Id)
        {
            Course = new Course() { Id = Id }.get();
            winRollBack.Show();
        }


        protected void btnAddNew_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            Course = new Course();
            wndNew.Show();
        }

        protected void btnGetList_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            Store str = grdList.GetStore();
            str.DataSource = new Course().getList(1, txtFilter.Text);
            str.DataBind();
        }

        protected void btnClose_DirectClick(object sender, DirectEventArgs e)
        {
            wndNew.Hide();
        }

        protected void btnSave_DirectClick(object sender, DirectEventArgs e)
        {
            var control = Course;

            if (control.CourseName == "")
            {
                X.Msg.Alert("UYARI", "Lütfen geçerli bir ders adı giriniz").Show();
                return;
            }

            int returnValue = control.save();
            if (returnValue > 0)
            {
                X.Msg.Alert("UYARI", "Ders eklenmiştir. Yeni bir ders daha ekleyebilirsiniz").Show();
                Course = new Course();
            }
            else
            {
                X.Msg.Alert("UYARI", "Ders kayıt edilememiştir").Show();
            }
        }


        protected void btnSaveDersSaati_DirectClick(object sender, DirectEventArgs e)
        {

            var deneme = CourseTime;
            var day = Convert.ToString(deneme.Day);
            if (day == "")
            {
                X.Msg.Alert("Uyarı", "Lütfen geçerli bir gün giriniz").Show();
                return;
            }
            //int returnValue = deneme.save();
            //if (returnValue > 0)
            //{
            //    X.Msg.Alert("UYARI", "Ders saati eklenmiştir.").Show();
            //    CourseTime = new CourseTime();
            //}
            //else
            //{
            //    X.Msg.Alert("UYARI", "Ders saati kayıt edilememiştir").Show();
            //}
        }

        protected void btnSaveCourseTime_DirectClick(object sender, DirectEventArgs e)
        {
            Course = new Course();
            //winCourseTime.Show();
        }

        protected void btnSaveStudentList_DirectClick(object sender, DirectEventArgs e)
        {
            Course = new Course();
            winStudentList.Show();
        }

        protected void btnSaveRollBack_DirectClick(object sender, DirectEventArgs e)
        {
            Course = new Course();
            winRollBack.Show();

        }

        protected void btnStudentAdd_DirectClick(object sender, DirectEventArgs e)
        {
            CourseStudent = new CourseStudent();
            winAddStudent.Show();
        }

        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {

        }

        protected void btnSaveStudent_DirectClick(object sender, DirectEventArgs e)
        {

        }

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            Course c = new Course();
            c.StartDate=Convert.ToDateTime(txtStartDate.Value);
            c.EndDate = Convert.ToDateTime(txtEndDate.Value);

            

        }

        protected void btnStudentSave_DirectClick(object sender, DirectEventArgs e)
        {
            var control = CourseStudent;

            if (control.StudentName == "")
            {
                X.Msg.Alert("UYARI", "Lütfen geçerli bir ad giriniz").Show();
                return;
            }

            int returnValue = control.save();
            if (returnValue > 0)
            {
                X.Msg.Alert("UYARI", "Öğrenci eklenmiştir. Yeni bir öğrenci daha ekleyebilirsiniz").Show();
                CourseStudent = new CourseStudent();
            }
            else
            {
                X.Msg.Alert("UYARI", "Öğrenci kayıt edilememiştir").Show();
            }
        }
    }
}