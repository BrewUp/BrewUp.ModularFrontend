﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BrewUp.Web.Tests.StepDefinitions;

[Binding]
public class NavbarItemsSuccessfulLoadedStepDefinitions
{
    private IWebDriver Driver { get; }
    private const string Url = "https://beerblazor.azurewebsites.net/";

    private IWebElement _navMenu { get; set; }
    private IWebElement _navMenuProductionItem { get; set; }
    private IWebElement _navMenuPubsItem { get; set; }

    public NavbarItemsSuccessfulLoadedStepDefinitions()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("headless");
        //Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
        Driver = new ChromeDriver(Environment.CurrentDirectory);
    }

    [Given(@"The user navigated to the home page")]
    public void GivenTheUserNavigatedToTheHomePage()
    {
        Driver.Navigate().GoToUrl(Url);
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [When(@"The user landed on the home page")]
    public void WhenTheUserLandedOnTheHomePage()
    {
        _navMenu = Driver.FindElement(By.Id("navmenu"));
        _navMenuProductionItem = _navMenu.FindElement(By.Id("production-link"));
        _navMenuPubsItem = _navMenu.FindElement(By.Id("pubs-link"));
    }

    [Then(@"The navbar elements should be loaded successfully")]
    public void ThenTheNavbarElementsShouldBeLoadedSuccessfully()
    {
        Assert.True(_navMenuProductionItem != null);
        Assert.True(_navMenuPubsItem != null);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Driver.Quit();
    }
}