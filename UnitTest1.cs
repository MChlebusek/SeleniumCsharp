using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;

namespace SeleniumCsharp
{
    public class Tests
    {

        IWebDriver driver;
        String test_url = "https://arinanikulina22.thkit.ee/untitled/kodutoo.html";
        private readonly Random _random = new Random();

        [SetUp]
        public void TestSurvey()
        {
            driver.Navigate().GoToUrl(test_url);

            // Заполняем поле "Eesnimi" (Имя)
            IWebElement firstNameField = driver.FindElement(By.Id("eesnimi"));
            firstNameField.SendKeys("Arina");

            // Заполняем поле "Perekonnanimi" (Фамилия)
            IWebElement lastNameField = driver.FindElement(By.Id("perekonnanimi"));
            lastNameField.SendKeys("Nikulina");

            // Выбираем опции из выпадающих списков
            SelectElement genderDropdown = new SelectElement(driver.FindElement(By.Id("sugu")));
            genderDropdown.SelectByValue("mees");

            SelectElement educationDropdown = new SelectElement(driver.FindElement(By.Id("haridus")));
            educationDropdown.SelectByValue("keskharidus");

            SelectElement languageDropdown = new SelectElement(driver.FindElement(By.Id("keel")));
            languageDropdown.SelectByValue("B1");

            // Нажимаем кнопку "Kuva Andmed" (Показать данные)
            IWebElement showDataButton = driver.FindElement(By.Id("kuva-andmed"));
            showDataButton.Click();

            // Проверяем результаты опроса (здесь вы можете добавить дополнительные проверки по вашему усмотрению)
            IWebElement surveyResult = driver.FindElement(By.Id("tulemus"));
            Assert.IsTrue(surveyResult.Text.Contains("Arina") && surveyResult.Text.Contains("Nikulina"));

            // Закрываем браузер
            driver.Quit();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}