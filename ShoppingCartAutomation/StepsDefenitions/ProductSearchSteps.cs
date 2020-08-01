using OpenQA.Selenium;
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
    public class ProductSearchSteps : Hook
    {
        ProductSearchPageObjects productsearch = new ProductSearchPageObjects(GetWebDriver());

        [When(@"I explore the product '(.*)' on the search page")]
        public void WhenIExploreTheProductOnTheSearchPage(string product)
        {
            ScenarioContext.Current.Add("Product", product);
            productsearch.ProductSearch(product);
        }
         
        [Then(@"I could see the correct product displayed on the page")]
        public void ThenICouldSeeTheCorrectProductDisplayedOnThePage()
        {
            productsearch.ProductElementDisplay(ScenarioContext.Current.Get<string>("Product"));
        }
    }
}
