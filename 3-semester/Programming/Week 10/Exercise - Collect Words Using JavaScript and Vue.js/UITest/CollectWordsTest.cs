using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace UITest
{
    [TestClass]
    public class CollectWordsTest
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
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void TestMethod()
        {
            string url = "C:/Users/Gabriel/repos/Zealand/3-semester/Programming/Week 10/Exercise - Collect Words Using JavaScript and Vue.js/CollectWords/index.html";

            driver!.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                string word = "apple";
                driver!.Navigate().GoToUrl(url);
                IWebElement inputField = driver.FindElement(By.Id("input"));
                inputField.SendKeys(word);
                IWebElement saveButton = driver.FindElement(By.Id("save"));
                saveButton.Click();
                IWebElement showButton = driver.FindElement(By.Id("show"));
                showButton.Click();
                IWebElement outputField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("outputField")));
                string text = outputField.Text;
                Assert.AreEqual(word, text);
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail($"Element not found: {ex.Message}");
            }
        }
    }
}
