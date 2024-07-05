using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projec4
{
    public class StudentInM : StudentBase
    {
        private List<double> grades;
        private string first;
        private string last;

        public override string FirstName
        {
            get
            {
                return $"{char.ToUpper(first[0])}{first.Substring(1, first.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    first = value;
                }
            }
        }
        public override string LastName
        {
            get
            {
                return $"{char.ToUpper(last[0])}.";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    last = value;
                }
            }
        }

        public StudentInM(string firstName, string lastName) : base(firstName, lastName)
        {
            grades = new List<double>();
        }

        public void ChangeStudentName(string new1)
        {
            string old = this.FirstName;
            foreach (char c in new1)
            {
                if (char.IsDigit(c))
                {
                    this.FirstName = old;
                    break;
                }
                else
                {
                    this.FirstName = new1;
                }
            }
        }

        public override void Add(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                grades.Add(grade);
                if (grade < 30)
                {
                    CheckEventGradeUnder3();
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 100 are allowed!");
            }
        }

        public override void Show()
        {
            StringBuilder sbu = new StringBuilder($"{this.FirstName} {this.LastName} grades are: ");
            for (int ig = 0; ig < grades.Count; ig++)
            {
                if (ig == grades.Count - 1)
                {
                    sbu.Append($"{grades[ig]}.");
                }
                else
                {
                    sbu.Append($"{grades[ig]}; ");
                }
            }
            Console.WriteLine($"\n{sbu}");
        }

        public override Statatistics GetStats()
        {
            var result = new Statatistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            return result;
        }
    }
}
