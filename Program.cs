using System.Diagnostics;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

class Launch {
    public static void Main()
    {
        Console.WriteLine("From mcs and mono");

        new DriverManager().SetUpDriver(new ChromeConfig());

        try
        {
            Visit("https://www.uts.edu.au/");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSelenium Testing was Successful.");
        }
        finally
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSelenum has Terminated!");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static void Visit(string URL)
    {
        IWebDriver Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();

        Driver.Navigate().GoToUrl(URL);

        IWebElement ContactUs = Driver.FindElement(By.XPath("//*[@id=\"block-utilitybar\"]/nav/ul/li[6]/a"));
        ContactUs.Click();

        Wait(Driver, 2);

        IWebElement Search = Driver.FindElement(By.XPath("//*[@id=\"site-search-toggle\"]"));
        Search.Click();

        Wait(Driver, 2);

        IWebElement TextBox = Driver.FindElement(By.XPath("//*[@id=\"edit-search-keys\"]"));
        TextBox.SendKeys("Games Development");
        TextBox.SendKeys(Keys.Enter);

        IWebElement GameDev = Driver.FindElement(By.XPath("//*[@id=\"block-mainpagecontent\"]/main/ol/li[1]/h3/a"));
        Debug.Assert(GameDev.Text == "Bachelor of Games Development | University of Technology Sydney");
        GameDev.Click();

        IWebElement ATAR = Driver.FindElement(By.XPath("//*[@id=\"course-overview\"]/div/div/div/div/div/aside/div[1]/div[2]/div/div/p"));
        Debug.Assert(ATAR.Text ==  "81.20");

        Driver.Quit();
    }

    static void Wait(IWebDriver Driver, int Seconds)
        => Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Seconds);
}