using ShoppingCartAutomation.PageObjects;
using ShoppingCartAutomation.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ShoppingCartAutomation.StepsDefenitions
{
    [Binding]
    public class LoginPageValidationSteps : Hook
    {
        LoginPageValidationPageObjects loginPageValidation = new LoginPageValidationPageObjects(GetWebDriver());

        [Given(@"I am on the account creation page")]
        public void GivenIAmOnTheAccountCreationPage()
        {
            loginPageValidation.AccountCreationPage();
        }

        [When(@"I enter invalid email '(.*)' address and click on create button")]
        public void WhenIEnterInvalidEmailAddressAndClickOnCreateButton(string email)
        {
            loginPageValidation.PassInvalidEmailAddress(email);
        }

        [Then(@"I could see the error '(.*)' message")]
        public void ThenICouldSeeTheErrorMessage(string emailInvalidMessage)
        {
            loginPageValidation.DisplayInvalidEmailMessage(emailInvalidMessage);
        }

        [Then(@"I enter the correct email '(.*)' address")]
        public void ThenIEnterTheCorrectEmailAddress(string validEmailAddress)
        {
            loginPageValidation.EnterValidEmailAddress(validEmailAddress);
        }

        [When(@"I click on account button")]
        public void WhenIClickOnAccountButton()
        {
            loginPageValidation.ClickOnAccountButton();
        }

        [Then(@"I could see the personal information page")]
        public void ThenICouldSeeThePersonalInformationPage()
        {
            loginPageValidation.PersonalInformationPage();
        }

        [Then(@"I enter all the mandatory fields except mobile phone")]
        public void ThenIEnterAllTheMandatoryFieldsExceptMobilePhone(Table table)
        {
            var Firstname = table.Rows.Select(row => row["Firstname"]).ToList();
            var Lastname = table.Rows.Select(row => row["Lastname"]).ToList();
            var Password = table.Rows.Select(row => row["Password"]).ToList();
            var Address = table.Rows.Select(row => row["Address"]).ToList();
            var City = table.Rows.Select(row => row["City"]).ToList();
            var ZipCode = table.Rows.Select(row => row["ZipCode"]).ToList();
            var FutureReferenceAddress = table.Rows.Select(row => row["FutureReferenceAddress"]).ToList();
            loginPageValidation.EnterAllMandatoryFieldsExceptMobile(Firstname,Lastname,Password,Address,City,ZipCode,FutureReferenceAddress);
        }

        [When(@"I click on register button")]
        public void WhenIClickOnRegisterButton()
        {
            loginPageValidation.ClickOnRegisterButton();
        }

        [Then(@"I could see the phone error '(.*)' message")]
        public void ThenICouldSeeThePhoneErrorMessage(string phoneErrorMessage)
        {
            loginPageValidation.DisplayPhoneErrorMessage(phoneErrorMessage);   
        }

        [Then(@"I enter all the mandatory fields except address")]
        public void ThenIEnterAllTheMandatoryFieldsExceptAddress(Table table)
        {
            var Mobile = table.Rows.Select(row => row["Mobile"]).ToList();
            loginPageValidation.EnterAllMandatoryFieldsExceptAddress(Mobile);
        }

        [Then(@"I could see the address error '(.*)' message")]
        public void ThenICouldSeeTheAddressErrorMessage(string addressErrorMessage)
        {
            loginPageValidation.DisplayAddressErrorMessage(addressErrorMessage);
        }
    }
}
