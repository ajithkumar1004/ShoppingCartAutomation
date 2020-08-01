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
    public class ProductSearchPageObjects : BaseWebPage
    {
        #region Declaration
        WebDriverWait Wait;
        #endregion

        #region Search Product
        By _searchTextBox = By.Id("search_query_top");
        By _searchedProduct = By.CssSelector("#index > div.ac_results > ul > li > strong");
        By _breadcrumb = By.CssSelector("#columns > div.breadcrumb.clearfix");
        #endregion

        #region Product Display
        By _productDisplay = By.CssSelector("#center_column > div > div > div.pb-center-column.col-xs-12.col-sm-4 > h1");
        #endregion

        public ProductSearchPageObjects(IWebDriver driver) : base(driver)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromMinutes(Constants.DriverWait));
        }

        public void ProductSearch(string Product)
        {
            Session.Instance.Product = Product;
            ClearValue(_searchTextBox);
            SendValue(_searchTextBox,Product);
            WaitForElement(_searchedProduct);
            ClickElement(_searchedProduct);
        }

        public void ProductElementDisplay(string Product)
        {
            WaitForElementPresent(_breadcrumb);
            Assert.AreEqual(GetElementValue(_productDisplay).ToLower(), Product.ToLower(), "Searched products are not matched");
        }
    }
}
 