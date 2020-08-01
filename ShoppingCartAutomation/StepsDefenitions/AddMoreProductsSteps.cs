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
    public class AddMoreProductsSteps : Hook
    {
        AddProductPageObjects addProduct = new AddProductPageObjects(GetWebDriver());
        ProductSearchPageObjects productSearch = new ProductSearchPageObjects(GetWebDriver());
        AddMoreProductsPageObjects addMoreProducts = new AddMoreProductsPageObjects(GetWebDriver());

        [Given(@"I am on the shopping cart summary page")]
        public void GivenIAmOnTheShoppingCartSummaryPage()
        {
            productSearch.ProductSearch(Constants.Product);
            productSearch.ProductElementDisplay(Constants.Product);
            addProduct.ScrollHomePage();
            addProduct.AddCart();
        }

        [Given(@"I scroll down the page")]
        public void GivenIScrollDownThePage()
        {
            addMoreProducts.Scrollpage();
        }

        [When(@"I click on the product link image")]
        public void WhenIClickOnTheProductLinkImage()
        {
            addMoreProducts.ClickProductImage();
        }

        [Then(@"I could see the product add cart page")]
        public void ThenICouldSeeTheProductAddCartPage()
        {
            addMoreProducts.ProductAddCartPage();
        }

        [Then(@"I increment and validate the quantity")]
        public void ThenIIncrementAndValidateTheQuantity()
        {
            addMoreProducts.IncrementQuantityValidation();
        }

        [Then(@"I decrement the and validate the quantity")]
        public void ThenIDecrementTheAndValidateTheQuantity()
        {
            addMoreProducts.DecrementQuantityValidation();
        }

        [Then(@"I select different size")]
        public void ThenISelectDifferentSize()
        {
            addMoreProducts.SelectDifferentSize();
        }

        [When(@"I click on Add to Cart button")]
        public void WhenIClickOnAddToCartButton()
        {
            addMoreProducts.ClickAddCartButton();
        }

        [Then(@"I could see the message as product added successfully")]
        public void ThenICouldSeeTheMessageAsProductAddedSuccessfully()
        {
            addMoreProducts.AddCart();
        }

        [When(@"I click on Proceed to checkout button")]
        public void WhenIClickOnProceedToCheckoutButton()
        {
            addMoreProducts.ClickProceedToCheckOutButton();
        }

        [Then(@"I can see all the products added in the cart")]
        public void ThenICanSeeAllTheProductsAddedInTheCart()
        {
            addMoreProducts.DisplayAllTheProducts();
        }
    }
}
