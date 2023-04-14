using NetStandard.LearningMangement.Models;
using NetStandard.LearningMangement.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    public sealed partial class Grade_Assignment : ContentDialog
    {
        private CourseService courseService;
        public Assignment selectedAssign { get; set; }
        public Students selectedStudent { get; set; }
        public string Header { get; set; }

        private Course course { get; set; }

        private AssignmentGroup group { get; set; }
        public int Points { get; set; }

        public Grade_Assignment()
        {

            this.InitializeComponent();
        }

        public Grade_Assignment(Assignment selectedAssign, Students selectedStudent, string code, string group)
        {
            DataContext = this;
            Header = $"Grade {selectedStudent.Name} for  {selectedAssign.Name}: {selectedAssign.TotalAvailablePoints} Points";
            this.selectedAssign = selectedAssign;
            this.selectedStudent = selectedStudent;
            courseService = CourseService.Current;
            foreach (Course cor in courseService.Courses)
            {
                if (cor.Code == code)
                {
                    course = cor;
                }
            }
            foreach (AssignmentGroup assign in course.Assignments)
            {
                if (assign.Name == group)
                {
                    this.group = assign;
                }
            }
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            gradeAssign();
            PersonService.Current.UpdateGPA(selectedStudent);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }


        public void gradeAssign()
        {
            selectedStudent.Grades[course.Code].Points[group] += Points;
            float total = 0;
            float percent = 0;
            foreach (AssignmentGroup a in course.Assignments)
            {
                percent += a.Percentage;
                total += ((selectedStudent.Grades[course.Code].Points[group] / a.totalPoints) * 100) * a.Percentage;
            }
            selectedStudent.Grades[course.Code].Grade = total / percent;
        }
    }
        
}
