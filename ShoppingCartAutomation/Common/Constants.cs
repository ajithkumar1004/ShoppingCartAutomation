using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartAutomation.Common
{
    public class Constants
    {
        #region Browser
        public const string credentialService = "credentials_enable_service";
        public const string profileManager = "profile.password_manager_enabled";
        public static string BrowserName = ConfigurationManager.AppSettings["Browser"].Trim();
        public static string IEBrowser = "IE";
        #endregion

        #region Waits
        public const int DriverWait = 5;
        public const int Wait = 120;
        public const int DynamicWait = 10;
        //public static double WaitTime = Convert.ToDouble(ConfigurationManager.AppSettings["WaitTime"]);
        #endregion

        #region Add Cart
        public const string Cart = "empty";
        public const string AddedCartMessage = "Product successfully added to your shopping cart";
        #endregion

        #region Add More Products to Cart
        public const string Size = "M";
        public const string Product = "blouse";
        public const string SizeDropdownList = "S\r\n\r\nL";
        #endregion

        #region Login Page Validation
        public const string Authentication = "AUTHENTICATION";
        public const string EmailErrorMessage = "Invalid email address.";
        public const string PersonalInformation = "YOUR PERSONAL INFORMATION";
        public const string Firstname = "Shopping";
        public const string Lastname = "Cart";
        public const string Password = "shopp";
        public const string Address = "Lake St";
        public const string City = "Tampa";
        public const string State = "Florida";
        public const string ZipCode = "73621";
        public const string Mobile = "8773892";
        public const string FutureReferenceAddress = "West Blvd";
        #endregion

    }
}
