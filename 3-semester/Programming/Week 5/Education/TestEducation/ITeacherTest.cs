using Education;
using Moq;

namespace TestEducation;

[TestClass]
public class ITeacherTest
{
    [TestMethod]
    public void TestTeacherToString()
    {
        Mock<ITeacher> mock = new Mock<ITeacher>();
        mock.Setup(t => t.ToString()).Returns("ID: 1, Name");
    }

    [TestMethod]
    public void TestValidateIDTrue()
    {
        var mockPerson = new Mock<ITeacher>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateID(1)).Returns(true);

        var result = teacher.ValidateID(1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateIDFalse()
    {
        var mockPerson = new Mock<ITeacher>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateID(It.Is<int>(id => id != 1))).Returns(false);

        var result = teacher.ValidateID(2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestValidateNameTrue()
    {
        var mockPerson = new Mock<ITeacher>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateName("John Doe")).Returns(true);

        var result = teacher.ValidateName("John Doe");

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateNameFalse()
    {
        var mockPerson = new Mock<ITeacher>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateName(It.Is<string?>(name => name != "John Doe"))).Returns(false);

        var result = teacher.ValidateName("Jane Doe");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestValidateGenderTrue()
    {
        var mockPerson = new Mock<ITeacher>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateGender(It.IsAny<Person.Genders?>())).Returns(true);
    }

    [TestMethod]
    public void TestValidateGenderFalse()
    {
        var mockPerson = new Mock<ITeacher>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateGender(It.IsAny<Person.Genders?>())).Returns(false);
    }

    [TestMethod]
    public void TestTeacherValidateClassesTrue()
    {
        var mockTeacher = new Mock<ITeacher>();
        var teacher = mockTeacher.Object;

        mockTeacher.Setup(t => t.ValidateClasses()).Returns(true);

        bool result = teacher.ValidateClasses();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestTeacherValidateClassesFalse()
    {
        var mockTeacher = new Mock<ITeacher>();
        var teacher = mockTeacher.Object;

        mockTeacher.Setup(t => t.ValidateClasses()).Returns(false);

        bool result = teacher.ValidateClasses();

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestValidateSalaryTrue()
    {
        var mockTeacher = new Mock<ITeacher>();
        var teacher = mockTeacher.Object;

        mockTeacher.Setup(t => t.ValidateSalary()).Returns(true);

        bool result = teacher.ValidateSalary();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateSalaryFalse()
    {
        var mockTeacher = new Mock<ITeacher>();
        var teacher = mockTeacher.Object;

        mockTeacher.Setup(t => t.ValidateSalary()).Returns(false);

        bool result = teacher.ValidateSalary();

        Assert.IsFalse(result);
    }   

    [TestMethod]
    public void TestTeacherEquals()
    {
        Mock<Teacher> mock = new Mock<Teacher>();
        mock.Setup(t => t.Equals(It.IsAny<object>())).Returns(true);
    }

    [TestMethod]
    public void TestTeacherGetHashCode()
    {
        Mock<Teacher> mock = new Mock<Teacher>();
        mock.Setup(t => t.GetHashCode()).Returns(1);
    }
}
