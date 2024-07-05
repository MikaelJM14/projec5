namespace Projec4
{
    internal class StudentManangementSystemSMS
    {
        private static void Main(string[] args)
        {
            firstAndSeconderyTextWithColour("hello & welcome ", "to the Student Manangement System(SMS) Console App this will give you optsions to give grades to students", ConsoleColor.Blue);

            bool entery = false;

            while (!entery)
            {
                Console.WriteLine();
                firstAndSeconderyTextWithColour("1 - Add student's grades to the program memory and show statistics\n" +
                    "2 - Add student's grades to the .txt file and show statistics\n",
                    "3 - Close app\n",
                    ConsoleColor.Yellow);

                firstAndSeconderyTextWithColour("What you want to do? \nPress key 1 ", "2 or 3:",ConsoleColor.Red);
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        AddGradesToEmployee(true);
                        break;

                    case "2":
                        AddGradesToEmployee(false);
                        break;

                    case "3":
                        entery = true;
                        break;

                    default:
                        firstAndSeconderyTextWithColour("Invalid operation.\n", "or using",ConsoleColor.DarkRed);
                        continue;
                }
                firstAndSeconderyTextWithColour("\n\nBye Bye! Press any key to leave." , "or time for bed" ,ConsoleColor.DarkYellow);
                Console.ReadKey();
            }
        }

        static void OnGradeUnder30(object sender, EventArgs args)
        {
            firstAndSeconderyTextWithColour($"Oh no! Student got grade under 30. We should inform student’s parents about this fact!", "pls Improve YOUR GRADE NOW!!!!!!!!!", ConsoleColor.DarkYellow);
        }

        private static void AddGradesToEmployee(bool isInMemory)
        {
            string firstName = GetValueFromUser("Please insert student's first name: ");
            string lastName = GetValueFromUser("Please insert student's last name: ");
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {

                IStudent student = isInMemory ? new StudentInM(firstName, lastName) : new Students(firstName, lastName);
                student.GradeUnder30 += OnGradeUnder30;
                EnterGrade(student);
                student.ShowStats();
            }
            else
            {
                firstAndSeconderyTextWithColour("Student's firstname and lastname can not be empty", "!", ConsoleColor.Red);
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                firstAndSeconderyTextWithColour($"Enter grade for {student.FirstName} {student.LastName}", ":", ConsoleColor.Yellow);
                var input = Console.ReadLine();

                if (input == "r" || input == "R")
                {
                    break;
                }
                try
                {
                    student.Add(input);
                }
                catch (FormatException ex)
                {
                    firstAndSeconderyTextWithColour(ex.Message, "pls never do that again", ConsoleColor.White);
                }
                catch (ArgumentException ex)
                {
                    firstAndSeconderyTextWithColour(ex.Message,"do not do that ever again", ConsoleColor.White);
                }
                catch (NullReferenceException ex)
                {
                    firstAndSeconderyTextWithColour(ex.Message,"do not do that ever again",ConsoleColor.White);
                }
                finally
                {
                    firstAndSeconderyTextWithColour($"To leave and show {student.FirstName} {student.LastName} statistics enter 'r'", ".",ConsoleColor.Magenta);
                }
            }
        }

        private static void firstAndSeconderyTextWithColour(string first, string second, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(first);
            Console.WriteLine(second);
            Console.ResetColor();
        }

        private static string GetValueFromUser(string comment)
        {
            firstAndSeconderyTextWithColour(comment, "", ConsoleColor.DarkRed);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}