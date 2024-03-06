using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Program
{
    internal class Autotest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Autotest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(19));
        }

        public void ToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        
        public void ToFrame(IWebElement frame)
        {
            driver.SwitchTo().Frame(frame);
        }
        
        public IWebElement FindErByXPath(string xpath)
        {
            return wait.Until(d => d.FindElement(By.XPath(xpath)));
        }

        public IWebElement FindErByCss(string selector)
        {
            return wait.Until(d => d.FindElement(By.CssSelector(selector)));
        }

        public static void Main(string[] args)
        { 
            Autotest a = new Autotest();
            
            // Заход на Портал
            a.ToUrl("https://b24-wk32l8.bitrix24.ru/");
            IWebElement LogInput = a.FindErByXPath("//input[@id='login']");
            LogInput.SendKeys("anatol@staffonly39.ru");
            Thread.Sleep(1900);
            LogInput.SendKeys(Keys.Enter);
            IWebElement PassInput = a.FindErByXPath("//input[@id='password']");
            PassInput.SendKeys("Zu7XGGbFwJ9zqiQ");
            PassInput.SendKeys(Keys.Enter);
           
            // Навигация
            //// Кнопка новая задача
            IWebElement NewTaskBtn = a.FindErByXPath("//*[@id='tasks-buttonAdd']"); 
            NewTaskBtn.Click();

            //// Всплывашка новой задачи
            a.ToFrame(a.FindErByCss("iframe.side-panel-iframe"));
           
            ////Форма
            //// Ввод названия задачи
            IWebElement TaskTitle = a.FindErByXPath("/html/body/div[2]/div[2]/div/form/div[1]/div[1]/div[2]/input");
            TaskTitle.SendKeys("ЗаголовИще");
            
            //// Описание задачи
            IWebElement DescrIFrame = a.FindErByXPath("//*[@id='bx-html-editor-iframe-cnt-bitrix_tasks_task_default_1']/iframe");
            a.ToFrame(DescrIFrame);
            IWebElement DescFuel = a.FindErByXPath("/html/body");
            DescFuel.SendKeys("Новое описание задачи");

            //// Поле дата
            //IWebElement Data = a.FindErByCss("input.task-options-inp");
            //Thread.Sleep(1900);
            //Data.SendKeys("12.08.2024 18:00");

            //// Раскрыть доп поля
            IWebElement MoreBtn = a.FindErByCss(".task-additional-alt-more");
            Thread.Sleep(1900);
            MoreBtn.Click();
            
            /// Чек бокс регулярного события
            IWebElement RegBox = a.FindErByXPath(
                    "//*[@id='task-form-bitrix_tasks_task_default_1']/div[4]/div[2]/div[4]/div/div/label/input[1]");
            RegBox.Click();
            //// Кнопка Поставить задачу
            IWebElement tskBtn = a.FindErByXPath("//*[@id='task - form - bitrix_tasks_task_default_1']/div[5]/div/button[1]");
            tskBtn.Click();
            Thread.Sleep(1900);
        }
    }
}
