using static Projec4.StudentBase;

namespace Projec4
{
    public interface IStudent
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        event GradeAddedUnder30Delegade GradeUnder30;

        void Add(double grade);

        void Add(string grade);

        void Show();

        Statatistics GetStats();

        void ShowStats();
    }
}
