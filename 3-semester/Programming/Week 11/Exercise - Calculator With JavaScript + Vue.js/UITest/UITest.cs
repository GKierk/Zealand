// dotnet add package Selenium.WebDriver
// dotnet add package Selenium.Support

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace UITest;






[TestClass]
public class UITest
{
    private IWebDriver? driver;


    [TestInitialize]
    public void Initialize()
    {
        driver = new FirefoxDriver();
    }

    [TestCleanup]
    public void TearDown()
    {
        driver?.Quit();
    }

    [TestMethod]
    public void Test_UI()
    {
        string url = "C:/Users/Gabriel/repos/Zealand/3-semester/Programming/Week 11/Exercise - Calculator With JavaScript + Vue.js/Calculator/index.html";

        try
        {
            driver!.Navigate().GoToUrl(url);

            IWebElement num1 = driver.FindElement(By.Id("num1"));
            num1.SendKeys("8");

            IWebElement selectOperator = driver.FindElement(By.Id("operator"));
            SelectElement operatorElement = new SelectElement(selectOperator);
            operatorElement.SelectByText("+");

            IWebElement num2 = driver.FindElement(By.Id("num2"));
            num2.SendKeys("4");

            IWebElement button = driver.FindElement(By.Id("calculate"));
            new Actions(driver).ContextClick(button).Perform();

            IWebElement result = driver.FindElement(By.Id("result"));

            Assert.Equals(14, result);

            num1.SendKeys("4");
            operatorElement.SelectByText("-");
            num2.SendKeys("2");
            new Actions(driver).ContextClick(button).Perform();
            Assert.Equals(2, result);

            num1.SendKeys("3");
            operatorElement.SelectByText("*");
            num2.SendKeys("8");
            new Actions(driver).ContextClick(button).Perform();
            Assert.Equals(24, result);

            num1.SendKeys("50");
            operatorElement.SelectByText("/");
            num2.SendKeys("10");
            new Actions(driver).ContextClick(button).Perform();
            Assert.Equals(5, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}