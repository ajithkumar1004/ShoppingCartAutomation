using ShoppingCartAutomation.Common;
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
    public class AddProductSteps : Hook
    {
        AddProductPageObjects addProduct = new AddProductPageObjects(GetWebDriver());
        ProductSearchPageObjects productSearch = new ProductSearchPageObjects(GetWebDriver());

        [Given(@"I am on the product search page")]
        public void GivenIAmOnTheProductSearchPage()
        {
            productSearch.ProductSearch(Constants.Product);
            productSearch.ProductElementDisplay(Constants.Product);
        }

        [When(@"I scroll down the page")]
        public void WhenIScrollDownThePage()
        {     
            addProduct.ScrollHomePage();
        }

        [Then(@"I can successfully add the product into the cart")]
        public void ThenICanSuccessfullyAddTheProductIntoTheCart()
        {
            addProduct.AddCart();
        }
    }
}
