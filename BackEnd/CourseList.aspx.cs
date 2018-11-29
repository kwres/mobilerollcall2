﻿using CLB.Models;
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
                try
                {
                    r.StartTime = Convert.ToDateTime(txtStart.Value);
                }
                catch { }
                try
                {
                    r.EndTime = Convert.ToDateTime(txtEnd.Value);
                }
                catch { }
                r.Duration = Convert.ToInt32(txtDuration.Value);
                r.CourseRef = Convert.ToInt32(hdnCourseRef.Value);
                return r;
            }
            set
            {
                //hdnCoursetime.SetValue(value.Id);
                txtStart.SetValue(value.StartTime);
                txtEnd.SetValue(value.EndTime);
                txtDuration.SetValue(value.Duration);
                //hdnCourseRef.SetValue(value.CourseRef);
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
                catch { }

                r.StudentNameSurname = Convert.ToString(txtStudentName.Value);
                r.StudentNumber = Convert.ToString(txtStudentNumber.Value);
                r.UserRef = 1;
                r.CourseRef = Convert.ToInt32(hdnCourseRef.Value);
                return r;
            }
            set
            {
                studentID.SetValue(value.Id);
                txtStudentName.SetValue(value.StudentNameSurname);
                txtStudentNumber.SetValue(value.StudentNumber);
                //hdnCourseRef.SetValue(value.CourseRef);

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
            //hdnStudent.SetValue(Id);
            switch (commanName)
            {
                case "Update":
                    update(Id);
                    break;

                case "CourseTimes":
                    courseTimes(Id);
                    break;
                case "StudentList":
                    studentList(Id);
                    break;
                case "RollCallList":
                    rollBack(Id);
                    break;
                case "UpdateCourseTime":
                    updateCourseTime(Id);
                    break;
                case "DeleteCourseTime":
                    deleteCourseTime(Id);
                    break;

            }
        }








        private void update(int Id)
        {
            Course = new Course() { Id = Id }.get();
            wndNew.Show();
        }


        private void courseTimes(int Id)
        {
            Course course = new Course() { Id = Id }.get();

            var CourseRef = Id;

            List<CourseTime> courseTimes = new CourseTime().getCourseTimeList(course);
            Store str = gridPanelCourseTime.GetStore();
            str.DataSource = courseTimes;
            str.DataBind();
            hdnUpdateCourseTime.SetValue(Id);
            winCourseTime.Show();
        }

        private int courseRefId(int Id)
        {
            Course course = new Course() { Id = Id }.get();
            var CourseRef = Id;

            return CourseRef;
        }









        //öğrenci ekleme
        protected void btnStudentSave_DirectClick(object sender, DirectEventArgs e)
        {
            CourseStudent courseStudent = new CourseStudent();
           // var courseRef = courseRefId(Course.Id);

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
        //öğrenci listeleme
        private void studentList(int Id)
        {
            Course = new Course() { Id = Id }.get();
            List<CourseStudent> courseStudents = new CourseStudent().getStudentList(Course.Id);
            Store str = grdStudentList.GetStore();
            //str.DataSource = new CourseStudent().getStudentList(Id);
            str.DataSource = courseStudents;
            str.DataBind();

            hdnCourseRef.SetValue(Id);
            winStudentList.Show();

        }

        public void rollBack(int Id)
        {
            Course = new Course() { Id = Id }.get();
            //List<CourseTime> courseTimes = new CourseTime().getRollBackList(Course);
            Store str = grdStudentList.GetStore();
            //str.DataSource = courseTimes;
            str.DataBind();

            hdnCourseRef.SetValue(Id);
            winRollBack.Show();
        }

        public void updateCourseTime(int Id)
        {
            //CourseTime course = new CourseTime() { Id = Id }.get();


            CourseTime = new CourseTime();
            //CourseTime.Update();
            winUpdateCourseTime.Show();


        }

        protected void deleteCourseTime(int Id)
        {
         //   CourseTime course = new CourseTime() { Id = Id }.Delete();

            windeleteYesNo.Show();
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
            CourseStudent = new CourseStudent();
            winAddStudent.Show();
        }

        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {

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

        
        protected void txtStartDate_DirectSelect(object sender, DirectEventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(txtStartDate.Value);
            DateTime endDate = Convert.ToDateTime(txtEndDate.Value);

            var diff = endDate.Subtract(startDate).TotalDays;
            int week = Convert.ToInt32(diff / 7);
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
            hdnUpdateCourseTime.SetValue(CourseTime.Id);
            winCourseTimeUpdate.Hide();
        }

        protected void btnKapatOgrEkle_DirectClick(object sender, DirectEventArgs e)
        {
            winAddStudent.Hide();
        }


        protected void btnList_DirectClick(object sender, DirectEventArgs e)
        {

            Store str = grdStudentList.GetStore();
            str.DataSource = new CourseStudent().getStudentList(Convert.ToInt32(hdnStudent.Value));
            DataBind();
        }

        protected void btnDelete_DirectClick(object sender, DirectEventArgs e)
        {

        }


        //Ders bilgilerini değiştirmede yapılan günceleme işlemleri için
        protected void btnUpdateSave_DirectClick(object sender, DirectEventArgs e)
        {
            var control = CourseTime;
            var courseRef = CourseTime.CourseRef;
            int returnValue = control.save(courseRef);
            if (returnValue > 0)
            {
                X.Msg.Alert("UYARI", "Güncelleme Yapılmıştır").Show();
                CourseTime = new CourseTime();
            }
            else
            {
                X.Msg.Alert("UYARI", "Güncelleme yapılamadı.Lütfen tekrar deneyiniz.").Show();
            }

        }

       

        protected void btnKapat_DirectClick(object sender, DirectEventArgs e)
        {
            winCourseTimeUpdate.Hide();
        }

        protected void btnKapatUpdate_DirectClick(object sender, DirectEventArgs e)
        {
            winUpdateCourseTime.Hide();
        }

        protected void btnDeleteNo_DirectClick(object sender, DirectEventArgs e)
        {
            windeleteYesNo.Hide();
        }


        //ders saati silme
        protected void btnDeleteYes_DirectClick(object sender, DirectEventArgs e)
        {
            CourseTime courseTime =  new CourseTime();
            courseTime.Delete();
            winSilindi.Show();
        }

        protected void datafieldTime1_DirectSelect(object sender, DirectEventArgs e)
        {

        }

        protected void datafieldTime2_DirectChange(object sender, DirectEventArgs e)
        {

        }
        protected void timeSelectTİme(object sender, DirectEventArgs e)
        {
            DateTime starTime = Convert.ToDateTime(txtStartTime.Value);
            DateTime endTime = Convert.ToDateTime(txtEndTime.Value);

            var time = endTime.Subtract(starTime).TotalMinutes;
            txtDurationTime.SetValue(time);

        }

        protected void btnCourseTimeUpdateSave_DirectClick(object sender, DirectEventArgs e)
        {

        }

        protected void btnWinCourseTimeUpdateDelete_DirectClick(object sender, DirectEventArgs e)
        {

        }

        protected void btnSilindiKapat_DirectClick(object sender, DirectEventArgs e)
        {
            winCourseTime.Show();
        }
    }
}
