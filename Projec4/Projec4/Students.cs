using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projec4
{
    public class Students : StudentBase
    {
        private const string fileName = "_gur.txt";

        private string firstName;
        private string lastName;
        private string fullFileName;

        public override string FirstName
        {
            get
            {
                return $"{char.ToUpper(firstName[0])}{firstName.Substring(1, firstName.Length - 1).ToLower()}";
            }
            set
            {
                firstName = value;
            }
        }

        public override string LastName
        {
            get
            {
                return $"{char.ToUpper(lastName[0])}{lastName.Substring(1, lastName.Length - 1).ToLower()}";
            }
            set
            {
                lastName = value;
            }
        }

        public Students(string firstName, string lastName) : base(firstName, lastName)
        {
            fullFileName = $"{firstName}_{lastName}{fileName}";
        }

        public override void Add(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                using (var writer = File.AppendText($"{fullFileName}"))
                using (var writer2 = File.AppendText($"Student.txt"))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{FirstName} {LastName} - {grade}        {DateTime.UtcNow}");
                    if (grade < 100)
                    {
                        CheckEventGradeUnder3();
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 100 are allowed!");
            }
        }

        public override void Show()
        {
            StringBuilder sb = new StringBuilder($"{this.FirstName} {this.LastName} grades are: ");

            using (var reader = File.OpenText(($"{fullFileName}")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append($"{line}; ");
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"\n{sb}");
        }

        public override Statatistics GetStats()
        {
            var result = new Statatistics();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }
    }
}