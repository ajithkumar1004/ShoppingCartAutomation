using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCartAutomation.Common
{
    public class BaseWebPage
    {
        #region Declaration
        public IWebDriver driver;
        private int _pollingIntervalInMilliSeconds = 500;
        #endregion

        public BaseWebPage(IWebDriver Driver)
        {
            driver = Driver;
        }

        /// <summary>
        /// Method to send the value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>

        public void SendValue(By element, string text)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
#pragma warning disable CS0618 // Type or member is obsolete
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
#pragma warning restore CS0618 // Type or member is obsolete
                driver.FindElement(element).SendKeys(text);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while sending the value", exception.ToString());
            }
        }

        /// <summary>
        /// Method to clear the field value
        /// </summary>
        /// <param name="element"></param>

        public void ClearValue(By element)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
#pragma warning disable CS0618 // Type or member is obsolete
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
#pragma warning restore CS0618 // Type or member is obsolete
                driver.FindElement(element).Clear();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while clearing the value", exception.ToString());
            }
        }

        /// <summary>
        /// Method to wait for an element
        /// </summary>
        /// <param name="element"></param>

        public void WaitForElement(By element)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
#pragma warning disable CS0618 // Type or member is obsolete
                Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while waiting for an element", exception.ToString());
            }
        }

        /// <summary>
        /// Method to click for an element
        /// </summary>
        /// <param name="element"></param>

        public void ClickElement(By element)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
#pragma warning disable CS0618 // Type or member is obsolete
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
#pragma warning restore CS0618 // Type or member is obsolete
                driver.FindElement(element).Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while clicking on element", exception.ToString());
            }
        }

        /// <summary>
        /// Method to wait until the element to be displayed
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeout"></param>

        public void WaitForElementPresent(By by, int timeout = 0)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
                Wait.Until(display =>
                {
                    var webelement = driver.FindElement(by);
                    return webelement.Displayed;
                }
                    );
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while waiting for an element to be displayed", exception.ToString());
            }
        }

        /// <summary>
        /// Method to get the text from the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>

        public string GetElementValue(By element)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
#pragma warning disable CS0618 // Type or member is obsolete
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
#pragma warning restore CS0618 // Type or member is obsolete
                return driver.FindElement(element).Text.Trim();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while getting an element", exception.ToString());
            }
            return null;
        }

        /// <summary>
        /// Method to scroll the bar to an element
        /// </summary>
        /// <param name="element"></param>

        public void ScrollToElement(By element)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
#pragma warning disable CS0618 // Type or member is obsolete
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                IWebElement webElement = driver.FindElement(element);
                Actions action = new Actions(driver);
                action.MoveToElement(webElement).Perform();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while scrolling to an element", exception.ToString());
            }
        }

        /// <summary>
        /// Method to get the attribute value of an element
        /// </summary>
        /// <param name="element"></param>

        public string GetElementAttributeValue(By element)
        {
            try
            {
                var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
#pragma warning disable CS0618 // Type or member is obsolete
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return driver.FindElement(element).GetAttribute("value");

            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while retrieving the value from an element", exception.ToString());
            }
            return null;
        }

        /// <summary>
        /// Method to verify the element present or not
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>

        public bool ElementPresent(By element)
        {
            try
            {           
                driver.FindElement(element);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to select a text from the dropdown list with regular expression match
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>

        public void SelectDropDownValue(By element, string text)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
                var dropDownList = driver.FindElements(element);
                IWebElement dropDownElement = dropDownList.Where(k => k.Text.Replace(Constants.SizeDropdownList,Constants.Size) == text).FirstOrDefault();
                dropDownElement.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while selecting the velue from dropdown list", exception.ToString());
            }
        }

        /// <summary>
        /// Method to click an element using JavaScript
        /// </summary>
        /// <param name="element"></param>

        public void JavaScriptClick(By element)
        {
            try
            {
                IWebElement webelement = driver.FindElement(element);
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
                javaScriptExecutor.ExecuteScript("arguments[0].click();", webelement);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while clicking an element using JavaScript method", exception.ToString());
            }
        }

        /// <summary>
        /// Method to get the list count
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>

        public int GetListCount(By element)
        {
            try
            {
                IList<IWebElement> lists = driver.FindElements(element);
                return Convert.ToInt32(lists.Count);
            }
            catch (Exception exception)
            {
                Console.WriteLine("No items are listed in shopping cart summary page", exception.ToString());
            }
            return 0;
        }

        /// <summary>
        /// Method to scroll and click the webelement using JavaScript
        /// </summary>
        /// <param name="element"></param>

        public void ScrollUsingJavaScriptClick(By element, By locator)
        {
            try
            {
                IWebElement webelement = driver.FindElement(locator);
                //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
                //javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", webelement);

                IWebElement webElement = driver.FindElement(element);
                Actions action = new Actions(driver);
                action.MoveToElement(webElement).Perform();
                driver.FindElement(element).Click();

            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured while scrolling and clicking an element", exception.ToString());
            }
        }

        /// <summary>
        /// Method to compare list values with passing string
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="text"></param>
        /// <returns></returns>

        public bool CompareListsWithText(List<string> list1, String text)
        {
            try
            {
                if (list1.Contains(Constants.Size).ToString() == text)
                {
                    return true;
                }                
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while comparing strings", exception.ToString());
            }
            return false;
        }

        /// <summary>
        /// Method to clear the text
        /// </summary>
        /// <param name="element"></param>

        public void ClearText(By element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                driver.FindElement(element).Clear();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while clearing en element", exception.ToString());
            }
        }

        /// <summary>
        /// Method to get all the elements
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>

        public string GetElement(List<string> fields, string text)
        {
            try
            {
                foreach(var field in fields)
                {
                    if (field.ToString() == text)
                    {
                        return field;
                    }
                }            
            }
            catch (Exception exception)
            {
                Console.WriteLine("No elements are present in the list", exception.ToString());
            } 
            return null;
        }

        /// <summary>
        /// Method to select a value from the dropdown list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>

        public void DropDownValueSelection(By element, string text)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.Wait));
                var dropDownList = driver.FindElements(element);
                IWebElement dropDownElement = dropDownList.Where(k => k.Text == text).FirstOrDefault();
                dropDownElement.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured while selecting the velue from dropdown list", exception.ToString());
            }
        }
    }
}
