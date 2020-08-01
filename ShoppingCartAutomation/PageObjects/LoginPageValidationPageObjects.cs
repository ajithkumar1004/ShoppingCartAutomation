using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ShoppingCartAutomation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCartAutomation.PageObjects
{
    public class LoginPageValidationPageObjects : BaseWebPage
    {
        #region Declaration
        WebDriverWait Wait;
        #endregion

        #region Validate Login Page
        By _signIn = By.CssSelector("[class='login']");
        By _authentication = By.CssSelector("#center_column > h1");
        By _email = By.Id("email_create");
        By _createAccountButton = By.Id("SubmitCreate");
        By _invalidEmailMessage = By.CssSelector("#create_account_error > ol > li");
        By _personalInformation = By.CssSelector("#account-creation_form > div:nth-child(1) > h3");
        By _firstname = By.Id("customer_firstname");
        By _lastname = By.Id("customer_lastname");
        By _password = By.Id("passwd");
        By _address = By.Id("address1");
        By _city = By.Id("city");
        By _zipCode = By.Id("postcode");
        By _mobile = By.Id("phone_mobile");
        By _addressReference = By.Id("alias");
        By _registerButton = By.Id("submitAccount");
        By _state = By.CssSelector("#uniform-id_state>span");
        By _stateOptions = By.CssSelector("#id_state>option");
        By _errorMessage = By.CssSelector("#center_column > div > ol > li");
        #endregion

        public LoginPageValidationPageObjects(IWebDriver driver) : base(driver)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromMinutes(Constants.DriverWait));
        }

        public void AccountCreationPage()
        {
            ClickElement(_signIn);
            WaitForElement(_authentication);
            Assert.AreEqual(GetElementValue(_authentication).ToLowerInvariant(), Constants.Authentication.ToLowerInvariant(), "Both text are not matching");
        }

        public void PassInvalidEmailAddress(string email)
        {
            ClickElement(_email);
            SendValue(_email, email);
            ClickElement(_createAccountButton);
        }

        public void DisplayInvalidEmailMessage(string errorMessage)
        {
            Assert.AreEqual(GetElementValue(_invalidEmailMessage), Constants.EmailErrorMessage, "Both email invalid error message are not matched");
        }

        public void EnterValidEmailAddress(string validEmail)
        {
            ClickElement(_email);
            ClearText(_email);
            SendValue(_email,validEmail);
        }

        public void ClickOnAccountButton()
        {
            ClickElement(_createAccountButton);
        }

        public void PersonalInformationPage()
        {
            WaitForElement(_personalInformation);
            Assert.AreEqual(GetElementValue(_personalInformation),Constants.PersonalInformation,"Both messages are not matching");
        }

        public void EnterAllMandatoryFieldsExceptMobile(List<string> firstname, List<string> lastname, List<string> password, 
            List<string> address, List<string> city, List<string> zipCode, List<string> futureReferenceAddress)
        {
            ClickElement(_firstname);
            SendValue(_firstname, GetElement(firstname, Constants.Firstname));
            ClickElement(_lastname);
            SendValue(_lastname, GetElement(lastname, Constants.Lastname));
            ScrollToElement(_password);
            ClickElement(_password);
            SendValue(_password, GetElement(password, Constants.Password));
            ScrollToElement(_address);
            ClickElement(_address);
            SendValue(_address, GetElement(address, Constants.Address));
            ScrollToElement(_city);
            ClickElement(_city);
            SendValue(_city, GetElement(city, Constants.City));
            ScrollToElement(_zipCode);
            ClickElement(_state);
            DropDownValueSelection(_stateOptions, Constants.State);
            ClickElement(_zipCode);
            SendValue(_zipCode, GetElement(zipCode, Constants.ZipCode));
            ScrollToElement(_addressReference);
            ClickElement(_addressReference);
            ClearText(_addressReference);
            SendValue(_addressReference, GetElement(futureReferenceAddress, Constants.FutureReferenceAddress));
        }

        public void ClickOnRegisterButton()
        {
            ScrollToElement(_registerButton);
            ClickElement(_registerButton);
        }

        public void DisplayPhoneErrorMessage(string mobileErrorMessage)
        {
            WaitForElement(_errorMessage);
            Assert.AreEqual(GetElementValue(_errorMessage), mobileErrorMessage, "Both mobile error messages are not matching");
        }

        public void EnterAllMandatoryFieldsExceptAddress(List<string> mobile)
        {
            ScrollToElement(_password);
            ClickElement(_password);
            SendValue(_password, Constants.Password);
            ScrollToElement(_mobile);
            ClickElement(_mobile);
            SendValue(_mobile, GetElement(mobile,Constants.Mobile));
            ScrollToElement(_address);
            ClickElement(_address);
            ClearText(_address);
        }

        public void DisplayAddressErrorMessage(string addressErrorMessage)
        {
            WaitForElement(_errorMessage);
            Assert.AreEqual(GetElementValue(_errorMessage),addressErrorMessage, "Both address error messages are not matching");
        }
    }
}
 