Feature: Shopping Cart Automation

@Smoke
Scenario: TC_01 Explore Product
	When I explore the product 'blouse' on the search page
	Then I could see the correct product displayed on the page

@Smoke
Scenario: TC_02 Product Add To Cart
	Given I am on the product search page
	When I scroll down the page
	Then I can successfully add the product into the cart

@Smoke
Scenario: TC_03 More Products To Cart
	Given I am on the shopping cart summary page
	And I scroll down the page
	When I click on the product link image
	Then I could see the product add cart page
	And I increment and validate the quantity 
	And I decrement the and validate the quantity
	And I select different size
	When I click on Add to Cart button
	Then I could see the message as product added successfully
	When I click on Proceed to checkout button 
	Then I can see all the products added in the cart

@Smoke
Scenario: TC_04 Validation for Login Page
	Given I am on the account creation page
	When I enter invalid email 'shoppingcart.com' address and click on create button
	Then I could see the error 'Invalid email address.' message
	And I enter the correct email 'shopping@us.com' address
	When I click on account button 
	Then I could see the personal information page
	And I enter all the mandatory fields except mobile phone
	| Firstname | Lastname | Password | Address | City  | ZipCode | FutureReferenceAddress |
	| Shopping  | Cart     | shopp    | Lake St | Tampa | 73621   | West Blvd              |
	When I click on register button 
	Then I could see the phone error 'You must register at least one phone number.' message
	And I enter all the mandatory fields except address
	| Mobile  |
	| 8773892 |
	When I click on register button
	Then I could see the address error 'address1 is required.' message