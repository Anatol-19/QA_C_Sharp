using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Program
{
    internal class Autotest
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(19));
           
            // Заход на Портал
            driver.Navigate().GoToUrl("https://b24-wk32l8.bitrix24.ru/");
            IWebElement LogInput = driver.FindElement(By.XPath("//input[@id='login']"));
            LogInput.SendKeys("anatol@staffonly39.ru");
            Thread.Sleep(1900);
            LogInput.SendKeys(Keys.Enter);
            IWebElement PassInput = wait.Until(d => d.FindElement(By.XPath("//input[@id='password']")));
            PassInput.SendKeys("Zu7XGGbFwJ9zqiQ");
            PassInput.SendKeys(Keys.Enter);
           
            // Навигация
            //// Кнопка новая задача
            IWebElement NewTaskBtn = wait.Until(d => d.FindElement(By.XPath("//*[@id='tasks-buttonAdd']"))); 
            NewTaskBtn.Click();
            //// Всплывашка новой задачи
            IWebElement NewTaskForm = wait.Until(d => d.FindElement(By.XPath("//*[@id='iframe_lpp0wdh3ak']")));
            driver.SwitchTo().Frame(NewTaskForm);
            ////Форма
            IWebElement AllInput4Task = driver.FindElement(By.XPath("//*[@id='task-form-bitrix_tasks_task_default_1']"));
            //// Ввод названия задачи
            IWebElement TaskTitle = AllInput4Task.FindElement(By.XPath("//*input[@data-bx-id='task-edit-title']"));
            TaskTitle.SendKeys("Alo");

            Thread.Sleep(1900);
           
            //// Описание задачи
            var DescrIFrame = driver.FindElement(By.XPath("//*[@id='bx-html-editor-iframe-cnt-bitrix_tasks_task_default_1']/iframe"))
            driver.SwitchTo().Frame(DescrIFrame);
                ("/html/body")

            //// Поле дата
            //// Всплыввашка календаря
            //// Раскрыть доп поля
            //// Чек бокс регулярного события
            //// Кнопка Поставить задачу
        }
    }
}
