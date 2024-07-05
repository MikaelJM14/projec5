namespace Projec4.Tests.student
{
    public class Student
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var student = new StudentInM("Lion", "Mei");
            student.Add(19);
            student.Add(80);
            student.Add(9);
            student.Add(36);
            student.Add(53.0);

            // act
            var result = student.GetStats();

            // assert
            Assert.Equal(4.8, result.Ave, 54.8675);
            Assert.Equal(6.0, result.First, 80.0);
            Assert.Equal(3.5, result.Last, 9.0);
        }
    }
}