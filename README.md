Design consideration.

1. Using SQLite Database for data storage
2. Design includes 2 tables. 1) User information with Amount balance and 2) user Payment Transaction details.
3. Docker File to deploy API to Docker.
4. Unit Testing with xunit.

Solution.

1.	The solution consists of 2 project one is API service second is Test project.
2.	Following is the structure of the code.
-	PaymentTransactionRepository repository to deal with data
-	User class – User data 
-	PaymentTransaction class – Payment Transaction for User
-	PaymentTransactionContext – implementing EntityFramwork DbContext . Adding some dummy data on Migration (Model creating)
-	PaymentTransactionControllerTest – unit test for the controller.

Things considered but not taken care right now.
- 	can have account table for user where user can have multiple accounts and each acccount got payment transaction history.
-	Payment transaction can have debit or credit column to calculate Amount Balance in future.
-	Can deploy to Azure app service or Docker.
-	Can publish to iis.
-	Can configure Continuous delivery with Azure. Can create pipeline which will target to Azure app service.
- 	some commented code in test for doing http endpoint testing.

How to execute.
-	clone all code into visual studio code and press F5 to run.
-	When local host is open in browser try yourlocalhost/api/v1/PaymentTransaction/1 (currently data for user id 1 only )

Feedback.
It would be great if you can review the code and provide any feedback on architecture and coding based on your experience
