namespace Projec4
{
    public class Person
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public Person(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }
    }
}
