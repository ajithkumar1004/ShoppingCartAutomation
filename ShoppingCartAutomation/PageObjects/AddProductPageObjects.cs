using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ShoppingCartAutomation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCartAutomation.PageObjects
{
    public class AddProductPageObjects : BaseWebPage
    {
        #region Declaration
        WebDriverWait Wait; 
        #endregion

        #region Add Product
        By _cart = By.CssSelector("#header > div:nth-child(3) > div > div > div:nth-child(3) > div > a > span.ajax_cart_no_product");
        By _paymentLogo = By.Id("product_payment_logos");
        By _quantity = By.Id("quantity_wanted");
        By _size = By.Id("group_1");
        By _modelDemo = By.CssSelector("#product_reference > span");
        By _price = By.Id("our_price_display");
        By _addCartButton = By.CssSelector("#add_to_cart > button");
        By _continueShopping = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > span > span"); 
        By _productAddedMessage = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_product.col-xs-12.col-md-6 > h2");
        By _productCheckout = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a > span"); //.icon-chevron-right.right
        By _shoppingCartSummary = By.Id("cart_title");
        By _sku = By.CssSelector("#product_2_7_0_0 > td.cart_description > small.cart_ref");
        By _unitPrice = By.CssSelector("#product_price_2_7_0 > span");
        #endregion

        public AddProductPageObjects(IWebDriver driver) : base(driver)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromMinutes(Constants.DriverWait));
        }

        public void ScrollHomePage()
        {
            WaitForElement(_paymentLogo);
            ScrollToElement(_paymentLogo);
            ScrollUsingJavaScriptClick(_addCartButton, _paymentLogo);
            Session.Instance.ProductQuantity = GetElementValue(_quantity);
            Session.Instance.ProductSize = GetElementValue(_size);
            Session.Instance.ModelDemo = GetElementValue(_modelDemo);
            Session.Instance.Price = GetElementValue(_price);
        }

        public void AddCart()
        {
            WaitForElement(_continueShopping);
            Assert.AreEqual(GetElementValue(_productAddedMessage), Constants.AddedCartMessage, "Product was not added to the cart");
            ScrollUsingJavaScriptClick(_productCheckout, _continueShopping);
            WaitForElement(_shoppingCartSummary);
            Thread.Sleep(2000);
            Assert.AreEqual(GetElementValue(_sku).Replace("SKU :", " ").Trim(), Session.Instance.ModelDemo, "Both models are not matched");
            Assert.AreEqual(GetElementValue(_unitPrice), Session.Instance.Price, "Both prices are incompatible");
        }
    }
}
