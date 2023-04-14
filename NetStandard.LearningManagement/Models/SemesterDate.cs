using System;
using System.Collections.Generic;
using System.Text;

namespace NetStandard.LearningManagement.Models
{
    public class SemesterDate
    {
        public int Month { get; set; }

        public int Year { get; set; }


        public SemesterDate (int month, int year)
        {
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Month} / {Year}";
        }
    }
}
