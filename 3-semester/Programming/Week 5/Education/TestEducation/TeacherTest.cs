using Education;

namespace TestEducation;

[TestClass]
public class TeacherTest
{
    [TestMethod]
    public void TestTeacherToString()
    {
        Teacher teacher = new Teacher() { ID = 1, Name = "John Doe", Gender = Person.Genders.Male, Salary = 1000 };
        string expected = "ID: 1, Name: John Doe, Gender: Male, Salary: 1000";
        string actual = teacher.ToString();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestTeacherValidateName()
    {
        Teacher teacher = new Teacher() { ID = 1, Name = "John Doe", Gender = Person.Genders.Male, Salary = 1000 };
        bool actual = teacher.ValidateName();
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestTeacherValidateSalary()
    {
        Teacher teacher = new Teacher() { ID = 1, Name = "John Doe", Gender = Person.Genders.Male, Salary = 1000 };
        bool actual = teacher.ValidateSalary();
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestTeacherValidateClasses()
    {
        Teacher teacher = new Teacher() { ID = 1, Name = "John Doe", Gender = Person.Genders.Male, Salary = 1000, Classes = new List<string>() { "Math", "Science" } };
        bool actual = teacher.ValidateClasses();
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestTeacherEquals()
    {
        Teacher teacher = new Teacher() { ID = 1, Name = "John Doe", Classes = new List<string>() { "Math", "Science" }, Salary = 1000 };
        Teacher expected = new Teacher() { ID = 1, Name = "John Doe", Classes = new List<string>() { "Math", "Science" }, Salary = 1000 };

        bool actual = teacher.Equals(expected);
    }

    [TestMethod]
    public void TestTeacherGetHashCode()
    {
        Teacher teacher = new Teacher() { ID = 1, Name = "John Doe", Classes = new List<string>() { "Math", "Science" }, Salary = 1000 };
        int actual = teacher.GetHashCode();
        Assert.IsInstanceOfType(actual, typeof(int));
    }
}
