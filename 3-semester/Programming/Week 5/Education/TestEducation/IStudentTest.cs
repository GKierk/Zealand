using Education;
using Moq;

namespace TestEducation;

[TestClass]
public class IStudentTest
{
    [TestMethod]
    public void TestStudentToString()
    {
        Mock<Student> mock = new Mock<Student>();
        mock.Setup(p => p.ToString()).Returns("ID: 1, Name");
    }

    [TestMethod]
    public void TestStudentValidateID()
    {
        Mock<IStudent> mock = new Mock<IStudent>();
        mock.Setup(p => p.ValidateID(It.IsAny<int>())).Returns(true);
    }

    [TestMethod]
    public void TestValidateNameTrue()
    {
        var mockPerson = new Mock<IStudent>();
        var student = mockPerson.Object;

        mockPerson.Setup(p => p.ValidateName()).Returns(true);

        var result = student.ValidateName();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateNameFalse()
    {
        var mockPerson = new Mock<IStudent>();
        var student = mockPerson.Object;

        mockPerson.Setup(p => p.ValidateName()).Returns(false);

        var result = student.ValidateName();

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestValidateGenderTrue()
    {
        var mockPerson = new Mock<IStudent>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateGender(It.IsAny<Person.Genders?>())).Returns(true);
    }

    [TestMethod]
    public void TestValidateGenderFalse()
    {
        var mockPerson = new Mock<IStudent>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateGender(It.IsAny<Person.Genders?>())).Returns(false);
    }

    [TestMethod]
    public void TestValidateSemesterTrue()
    {
        var mockTeacher = new Mock<IStudent>();
        var teacher = mockTeacher.Object;

        mockTeacher.Setup(t => t.ValidateSemester()).Returns(true);

        bool result = teacher.ValidateSemester();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateSemesterFalse()
    {
        var mockPerson = new Mock<IStudent>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateSemester()).Returns(false);
    }

    [TestMethod]
    public void TestStudentEquals()
    {
        Mock<Student> mock = new Mock<Student>();
        mock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
    }

    [TestMethod]
    public void TestStudentGetHashCode()
    {
        Mock<Student> mock = new Mock<Student>();
        mock.Setup(p => p.GetHashCode()).Returns(1);
    }
}
