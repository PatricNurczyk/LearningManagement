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
        public List<Person> Roster { get; set; }

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

        private PersonService()
        {
            Roster = new List<Person>();
            Students s = new Students();
            s.Name = "Billy Tester";
            s.Classification = "Freshmen";
            Roster.Add(s);
            Teacher t = new Teacher();
            t.Name = "Teacher Tester";
            t.Classification = "Professor";
            Roster.Add(t);

        }

        public char PersonType(int ID)
        {
            if (ID == 0)
            {
                //Admin
                return 'a';
            }
            else
            foreach(Person person in Roster)
            {
                if (person.ID == ID)
                {
                    if(person.GetType() == typeof(Teacher) || person.GetType() == typeof(TA))
                    {
                        return 't';
                    }
                    else if(person.GetType() == typeof(Students))
                    {
                        return 's';
                    }

                }
            }
            return 's';
        }
    }
}
