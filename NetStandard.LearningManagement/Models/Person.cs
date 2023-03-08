using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Library.Project_2.Models
{
    public class Person
    {
        protected static int lastID = 0;
        private string name = "N/A";
        private string classification = "freshman";

        public int ID { get; protected set; }
        public string Name
        {
            get { return this.name; }
            set { this.name = value ?? "N/A"; }
        }
        public string Classification
        {
            get { return this.classification; }
            set { this.classification = value ?? "freshman"; }
        }

        public List<Course> CourseTaken { get; set; }

        public override string ToString()
        {
            return $"Name: {name}| Class: {classification}";
        }
    }
}
