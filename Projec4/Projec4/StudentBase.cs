using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projec4
{
    public abstract class StudentBase : Person, IStudent
    { 

        public delegate void GradeAddedUnder30Delegade(object sender, EventArgs args);
        public event GradeAddedUnder30Delegade GradeUnder30;
        public override string FirstName {  get; set; }
        public override string LastName {  get; set; }

        public StudentBase(string first, string last) : base(first, last)
        {
        }

        public abstract void Add(double grade);

        public void Add(string gradentered)
        {
            double converted = char.GetNumericValue(gradentered[0]);
            if (gradentered.Length == 2 && char.IsDigit(gradentered[0]) && gradentered[0] <= '6' && (gradentered[1] == '+' || gradentered[1] == '-'))
            {
                switch (gradentered[1])
                {
                    case '+':
                        double gradeP = converted + 0.50;
                        if (gradeP > 1 && gradeP <= 100)
                        {
                            Add(gradeP);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(gradentered)}. Only grades from 1 to 100 are allowed!");
                        }
                        break;

                    case '-':
                        double gradeM = converted - 0.250;
                        if (gradeM > 1 && gradeM <= 100)
                        {
                            Add(gradeM);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(gradentered)}. Only grades from 1 to 100 are allowed!");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid argument: {nameof(gradentered)}. Only grades from 1 to 100 are allowed!");
                }
            }
            else
            {
                double gradeDoubled = 0;
                var Parsed = double.TryParse(gradentered, out gradeDoubled);
                if (Parsed && gradeDoubled > 1 && gradeDoubled <= 100)
                {
                    Add(gradeDoubled);
                }
                else
                {
                    throw new ArgumentException($"Invalid argument entered: {nameof(gradentered)}. Only grades from 1 to 100 are allowed!");
                }
            }
        }

        public abstract void Show();

        public abstract Statatistics GetStats();

        public void ShowStats()
        {
            var stat = GetStats();
            if (stat.Counted != 0)
            {
                Show();
                Console.WriteLine($"{FirstName} {LastName} statistics:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Total grades: {stat.Counted}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Highest grade: {stat.First:N4}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Lowest grade: {stat.Last:N4}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Average: {stat.Ave:N4}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Couldn't get statistics for {this.FirstName} {this.LastName} because no grade has been added.");
                Console.ResetColor();
            }
        }

        protected void CheckEventGradeUnder3()
        {
            if (GradeUnder30 != null)
            {
                GradeUnder30(this, new EventArgs());
            }
        }
    }
}
