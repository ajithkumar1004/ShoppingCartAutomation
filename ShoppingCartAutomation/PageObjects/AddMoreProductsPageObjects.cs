using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ShoppingCartAutomation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartAutomation.PageObjects
{
    public class AddMoreProductsPageObjects : BaseWebPage
    {
        #region Declaration
        WebDriverWait Wait;
        private static int _incrementedQuantity;
        private static int _deletedQuantity;
        #endregion

        #region Add More Products
        By _productCheckout = By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium > span");
        By _proceedToCheckout = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a > span");
        By _productImage = By.CssSelector("#product_2_7_0_0 > td.cart_product > a > img");
        By _addCartButton = By.CssSelector("#add_to_cart > button");
        By _breadcrumb = By.CssSelector("#columns > div.breadcrumb.clearfix");
        By _addQuantity = By.CssSelector("#quantity_wanted_p > a.btn.btn-default.button-plus.product_quantity_up > span > i");
        By _quantityValue = By.Id("quantity_wanted");
        By _deleteQuantity = By.CssSelector("#quantity_wanted_p > a.btn.btn-default.button-minus.product_quantity_down > span > i");
        By _sizeDropdownBox = By.Id("uniform-group_1");
        By _sizeDropdownList = By.CssSelector("#group_1 > option:nth-child(2)");
        By _productAddedMessage = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_product.col-xs-12.col-md-6 > h2");
        By _continueShopping = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > span > span");
        By _shoppingContinue = By.Id("product");
        By _shoppingCartSummary = By.Id("cart_title");
        By _productList = By.CssSelector("tbody > tr > td.cart_product");
        By _totalProducts = By.CssSelector("#summary_products_quantity");
        By _wishList = By.Id("wishlist_button");
        By _paymentLogo = By.Id("product_payment_logos");
        #endregion

        public AddMoreProductsPageObjects(IWebDriver driver) : base(driver)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromMinutes(Constants.DriverWait));
        }

        public void Scrollpage()
        {
            WaitForElement(_productCheckout);
            ScrollToElement(_productCheckout);
        }

        public void ClickProductImage()
        {
            ClickElement(_productImage);
            WaitForElementPresent(_addCartButton);
        }

        public void ProductAddCartPage()
        {
            Assert.IsTrue(ElementPresent(_breadcrumb));
        }

        public void IncrementQuantityValidation()
        {
            Session.Instance.ProductQuantityValue = Convert.ToInt32(GetElementAttributeValue(_quantityValue));
            ClickElement(_addQuantity);
            WaitForElement(_quantityValue);
            ClickElement(_quantityValue);
            _incrementedQuantity = Convert.ToInt32(GetElementAttributeValue(_quantityValue));
            Assert.AreEqual(_incrementedQuantity, (Session.Instance.ProductQuantityValue) + 1, "Both incremented quantities are not matched");
        }

        public void DecrementQuantityValidation()
        {
            Session.Instance.ProductQuantityValue = Convert.ToInt32(GetElementAttributeValue(_quantityValue));
            ClickElement(_deleteQuantity);
            WaitForElement(_deleteQuantity);
            ClickElement(_quantityValue);
            _deletedQuantity = Convert.ToInt32(GetElementAttributeValue(_quantityValue));
            Assert.AreEqual(_deletedQuantity, Session.Instance.ProductQuantityValue - 1, "Both deleted quantities are not matched");
            ScrollToElement(_wishList);
        }

        public void SelectDifferentSize()
        {
            ClickElement(_sizeDropdownBox);
            SelectDropDownValue(_sizeDropdownList, Constants.Size);
        }

        public void ClickAddCartButton()
        {
            ScrollUsingJavaScriptClick(_addCartButton, _paymentLogo);
        }

        public void AddCart()
        {
            WaitForElement(_shoppingContinue);
            Assert.AreEqual(GetElementValue(_productAddedMessage), Constants.AddedCartMessage, "Product was not added to the cart");
        }

        public void ClickProceedToCheckOutButton()
        {
            ScrollUsingJavaScriptClick(_proceedToCheckout,_continueShopping);
        }

        public void DisplayAllTheProducts()
        {
            WaitForElement(_shoppingCartSummary);
            Assert.AreEqual(GetListCount(_productList), GetElementValue(_totalProducts).Replace(" Products", " ").Count(), "Products count are not matched");
        }
    }
}
