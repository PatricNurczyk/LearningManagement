using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NetStandard.LearningMangement.Models;

namespace NetStandard.LearningMangement.Services
{
    public class PersonService
    {
        public List<Students> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TA> tAs {  get; set; }

        protected static PersonService instance;

        public static PersonService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonService();
                }
                return instance;
            }
        }

        public PersonService()
        {
            Students= new List<Students>();
            Teachers = new List<Teacher>();
            tAs= new List<TA>();
        }

        public void add(Students s)
        {
            Students.Add(s);
        }
        public void add(Teacher t)
        {
            Teachers.Add(t);
        }

        public void add(TA t)
        {
            tAs.Add(t);
        }

    }
}
