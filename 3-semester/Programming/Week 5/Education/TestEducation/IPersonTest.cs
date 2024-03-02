using Education;
using Moq;

namespace TestEducation;

[TestClass]
public class IPersonTest
{
    [TestMethod]
    public void TestPersonToString()
    {
        Mock<IPerson> mock = new Mock<IPerson>();
        mock.Setup(p => p.ToString()).Returns("ID: 1, Name");
    }

    [TestMethod]
    public void TestValidateIDTrue()
    {
        var mockPerson = new Mock<IPerson>();
        var person = mockPerson.Object;

        mockPerson.Setup(p => p.ValidateID(1)).Returns(true);

        var result = person.ValidateID(1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateIDFalse()
    {
        var mockPerson = new Mock<IPerson>();
        var person = mockPerson.Object;

        mockPerson.Setup(p => p.ValidateID(It.Is<int>(id => id != 1))).Returns(false);

        var result = person.ValidateID(2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestPersonValidateNameTrue()
    {
        var mockPerson = new Mock<IPerson>();
        var person = mockPerson.Object;

        mockPerson.Setup(p => p.ValidateName("John Doe")).Returns(true);

        var result = person.ValidateName("John Doe");

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestPersonValidateNameFalse()
    {
        var mockPerson = new Mock<IPerson>();
        var person = mockPerson.Object;

        mockPerson.Setup(p => p.ValidateName(It.Is<string>(name => name != "John Doe"))).Returns(false);

        var result = person.ValidateName("Jane Smith");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestValidateGenderTrue()
    {
        var mockPerson = new Mock<IPerson>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateGender(It.IsAny<Person.Genders?>())).Returns(true);
    }

    [TestMethod]
    public void TestValidateGenderFalse()
    {
        var mockPerson = new Mock<IPerson>();
        var teacher = mockPerson.Object;

        Mock.Get(teacher).Setup(t => t.ValidateGender(It.IsAny<Person.Genders?>())).Returns(false);
    }

    [TestMethod]
    public void TestPersonValidateGenderFalse()
    {
        var mockPerson = new Mock<IPerson>();
        var person = mockPerson.Object;

        mockPerson.Setup(p => p.ValidateGender(It.IsAny<Person.Genders>()));
    }

    [TestMethod]
    public void TestPersonEquals()
    {
        Mock<IPerson> mock = new Mock<IPerson>();
        mock.Setup(p => p.Equals(It.IsAny<object>())).Returns(true);
    }

    [TestMethod]
    public void TestPersonGetHashCode()
    {
        Mock<IPerson> mock = new Mock<IPerson>();
        mock.Setup(p => p.GetHashCode()).Returns(1);
    }
}
