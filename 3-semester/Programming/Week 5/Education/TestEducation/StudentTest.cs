using Education;

namespace TestEducation;

[TestClass]
public class StudentTest
{
    [TestMethod]
    public void TestStudentToString()
    {
        Student student = new Student() { ID = 1, Name = "John Doe", Gender = Person.Genders.Male, Semester = 1 };
        string expected = "ID: 1, Name: John Doe, Gender: Male, Semester: 1";
        string actual = student.ToString();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestStudentValidateName()
    {
        Student student = new Student() { ID = 1, Name = "John Doe", Gender = Person.Genders.Male, Semester = 1 };
        bool actual = student.ValidateName();
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestStudentValidateSemester()
    {
        Student student = new Student() { ID = 1, Name = "John Doe", Gender = Person.Genders.Male, Semester = 1 };
        bool actual = student.ValidateSemester();
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestStudentEquals()
    {
        Student student = new Student() { ID = 1, Name = "John Doe", Semester = 1 };
        Student expected = new Student() { ID = 1, Name = "John Doe", Semester = 1 };

        bool actual = student.Equals(expected);
    }

    [TestMethod]
    public void TestStudentGetHashCode()
    {
        Student student = new Student() { ID = 1, Name = "John Doe", Semester = 1 };
        int actual = student.GetHashCode();
        Assert.IsInstanceOfType(actual, typeof(int));
    }
}
