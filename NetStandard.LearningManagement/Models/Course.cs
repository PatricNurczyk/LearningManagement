using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class Course
    {
        //Class Code
        
        private string code;
        private string name;
        private string description;
        private List<Person> roster;
        private List<AssignmentGroup> assignments;
        private List<Module> modules;

        public string Code
        {
            get { return code; } set { code = value ?? "N/A";}
        }
        //Name
        public string Name
        {
            get { return name; } set { name = value ?? "N/A"; }
        }
        //Description
        public string Description
        {
            get { return description; } set { description = value ?? "N/A"; }
        }
        //Roster
        public List<Person> Roster
        {
            get { return roster; }
            set { roster = value ?? new List<Person>(); }
        }
        //Assignments
        public List<AssignmentGroup> Assignments
        {
            get { return assignments; }
            set { assignments = value ?? new List<AssignmentGroup>(); }
        }
        //Modules
        public List<Module> Modules
        {
            get { return modules; }
            set { modules = value ?? new List<Module>(); }
        }

        public int creditHours { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<TA> TeacherAssist { get; set; }

        public List<Annoucement> Annoucements { get; set; }

        public string Room { get; set; }
        public string Semester { get; set; }

        public Course()
        {
            code = string.Empty;
            name = string.Empty;
            description = string.Empty;
            creditHours = 3;
            Semester = string.Empty;
            Room = string.Empty;
            roster = new List<Person>();
            Teachers = new List<Teacher>();
            TeacherAssist = new List<TA>();
            assignments = new List<AssignmentGroup>();
            modules = new List<Module>();
            Annoucements = new List<Annoucement>();
        }
        
        public override string ToString()
        {
            /* string s = $"Course Code: {Code}| Course Name: {Name}| Description: {Description}| CreditHours: {creditHours} \n";
             s += "Teachers:\n";
             s += "-------------------------------------------------------------\n";
             foreach(Teacher t in Teachers)
             {
                 s += $"    {t.Name} - Role: Teacher\n";
             }
             s += "-------------------------------------------------------------\n";
             s += "TAs: \n";
             s += "-------------------------------------------------------------\n";
             foreach (TA t in TeacherAssist)
             {
                 s += $"    {t.Name} - Role: TA\n";
             }
             s += "-------------------------------------------------------------\n";
             s += "Roster: \n";
             foreach (Students t in Roster)
             {
                 int index = 0;
                 for (int i = 0; i < t.CourseTaken.Count; i++)
                 {
                     if (Code == t.CourseTaken[i].Code)
                     {
                         index = i; 
                         break;
                     }
                 }
                 s += $"    {t.Name} - Class: {t.Classification} - Grade: {t.Grades[index].Grade}\n";
             }
             s += "-------------------------------------------------------------\n";
             s += "Annoucements: \n";
             s += "-------------------------------------------------------------\n";
             foreach (Annoucement a in Annoucements)
             {
                 s += a.ToString() + "\n";
             }
             s += "-------------------------------------------------------------\n";
             s += "Modules: \n";
             s += "-------------------------------------------------------------\n";
             foreach (Module m in modules)
             {
                 s += m.ToString() + "\n";
             }
             s += "-------------------------------------------------------------\n";
             s += "Assignments:\n";
             s += "-------------------------------------------------------------\n";
             foreach (AssignmentGroup a in assignments)
             {
                 s += a.ToString() + "\n";
             }
             s += "-------------------------------------------------------------\n"; */

            return $"{Code} - {Name} - {creditHours}";
        }
    }
}