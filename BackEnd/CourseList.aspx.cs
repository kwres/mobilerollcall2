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
                r.Id = Convert.ToInt32(hdnCoursetime.Value);
                r.StartTime = Convert.ToDateTime(txtStart.Value);
                r.EndTime = Convert.ToDateTime(txtEnd.Value);
                r.Duration = Convert.ToInt32(txtDuration.Value);
                r.CourseRef = 1;
                //r.CourseType = Convert.ToString(txtPractical.Value && txtTheorical.Value);
               
                return r;
            }
            set
            {
                hdnCoursetime.SetValue(value.Id);
                txtStart.SetValue(value.StartTime);
                txtEnd.SetValue(value.EndTime);
                txtDuration.SetValue(value.Duration);
                
            }
        }


        public CourseStudent CourseStudent
        {
            get
            {
                CourseStudent r = new CourseStudent();
                try
                {
                    r.Id = Convert.ToInt32(studentID.Value);
                }
                catch{}
                r.StudentNameSurname = Convert.ToString(txtStudentName.Value);
                r.StudentNumber = Convert.ToString(txtStudentNumber.Value);
                r.UserRef = 1;
                return r;
            }
            set
            {
                studentID.SetValue(value.Id);
                txtStudentName.SetValue(value.StudentNameSurname);
                txtStudentNumber.SetValue(value.StudentNumber);

            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Store str = grdList.GetStore();
            str.DataSource = new Course().getList(1, txtFilter.Text);
            str.DataBind();
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

        public void courseTime(object sender, Ext.Net.DirectEventArgs e)
        {
            string commanName = e.ExtraParams["command"];
            int Id = Convert.ToInt32(e.ExtraParams["Id"]);
            switch (commanName)
            {
                case "UpdateCourseTime":
                    update(Id);
                    break;

              

            }
          
        }
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


        private void courseTime(int Id)
        {
            Course = new Course() { Id = Id }.get();
            
            Store str = gridPanelCourseTime.GetStore();
            str.DataSource = new CourseTime().getCourseTimeList(Id);

            
            var practicalNumber = Convert.ToInt32(txtPractical.Value);
            var teoricalNummber = Convert.ToInt32(txtTheorical.Value);

            for (int i = 0; i < practicalNumber; i++)
            {
                Convert.ToString(txtPractical.Value);
            }
            for (int i = 0; i < teoricalNummber; i++)
            {
                Convert.ToString(txtTheorical.Value);

            }

            DataBind();
            winCourseTime.Show();
           
        }

        private void studentList(int Id)
        {
            Course = new Course() { Id = Id }.get();
            //Store str = grdStudentList.GetStore();
            //str.DataSource = new CourseStudent().getStudentList(Id);
            //DataBind();
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
           
            winAddStudent.Show();
        }

        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {

        }

        protected void btnSaveStudent_DirectClick(object sender, DirectEventArgs e)
        {
            CourseStudent = new CourseStudent();
            var kayit = CourseStudent;
            int kayitReturn = kayit.save();
            if (kayitReturn == 1)
            {
                X.Msg.Alert("UYARI", "Öğrenci Eklenmiştir.").Show();
                CourseStudent = new CourseStudent();
            }
            else
            {
                X.Msg.Alert("UYARI", "Öğrenci Eklenememiştir.Tekrar Deneyiniz...").Show();
            }
        }

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            Course c = new Course();
            c.StartDate = Convert.ToDateTime(txtStartDate.Value);
            c.EndDate = Convert.ToDateTime(txtEndDate.Value);



        }

        protected void btnStudentSave_DirectClick(object sender, DirectEventArgs e)
        {
            var control = CourseStudent;

            if (control.StudentNameSurname == "")
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

        protected void txtStartDate_DirectSelect(object sender, DirectEventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(txtStartDate.Value);
            DateTime endDate = Convert.ToDateTime(txtEndDate.Value);

            var diff = endDate.Subtract(startDate).TotalDays;
            int week =Convert.ToInt32( diff / 7);
            txtTotalWeeks.SetValue(week);

        }
        

        protected void timeSelect(object sender, DirectEventArgs e)
        {
            DateTime starTime = Convert.ToDateTime(txtStart.Value);
            DateTime endTime = Convert.ToDateTime(txtEnd.Value);

            var time = endTime.Subtract(starTime).TotalMinutes;
            txtDuration.SetValue(time);

        }
        
        protected void btnKapatCourseTime_DirectClick(object sender, DirectEventArgs e)
        {
            winCourseTime.Hide();
        }

        protected void btnKapatStudentList_DirectClick(object sender, DirectEventArgs e)
        {
            winStudentList.Hide();
        }

        protected void btnKapatRollBack_DirectClick(object sender, DirectEventArgs e)
        {
            winRollBack.Hide();
        }

        protected void btnWinCourseTimeUpdate_DirectClick(object sender, DirectEventArgs e)
        {
            winCourseTimeUpdate.Hide();
        }

        protected void btnKapatOgrEkle_DirectClick(object sender, DirectEventArgs e)
        {
            winAddStudent.Hide();
        }

        protected void btnCourseList_DirectClick(object sender, DirectEventArgs e)
        {
            Store str = gridPanelCourseTime.GetStore();
            str.DataSource = new CourseTime().getCourseTimeList(Convert.ToInt32(hdnCoursetime.Value));
            DataBind();

        }

        protected void btnList_DirectClick(object sender, DirectEventArgs e)
        {

            Store str = grdStudentList.GetStore();
            str.DataSource = new CourseStudent().getStudentList(Convert.ToInt32(hdnStudent.Value));
            DataBind();
        }
    }
}
