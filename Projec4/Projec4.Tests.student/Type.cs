namespace Projec4.Tests.student
{
    public class Type
    {
        [Fact]
        public void GetStudentReturnsDifferentObjects()
        {
            var student1 = GetStudent("Rob", "Lewand");
            var student2 = GetStudent("Lio", "Mes");

            Assert.NotSame(student1, student2);
            Assert.False(student1.Equals(student2));
            Assert.False(Object.ReferenceEquals(student1, student2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var student1 = GetStudent("Rob", "Lewand");
            var student2 = student1;

            Assert.Same(student1, student2);
            Assert.True(student1.Equals(student2));
            Assert.True(Object.ReferenceEquals(student1, student2));
        }

        private StudentInM GetStudent(string firstName, string secondName)
        {
            return new StudentInM(firstName, secondName);
        }
    }
}
