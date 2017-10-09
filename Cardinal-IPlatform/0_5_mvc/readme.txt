What is expected in this test
-----------------------------
This test is to measure you MVC abilities.

The existing MVC application allows the user to lookup people's information based on their ID numbers. The lookup is done using an existing component (ConsumerViewService). Once a person is looked up, the user has the ability to update the returned information and then add the person to their list of people. To see the application in action have a look at the screenshots in the screenshots folder.

The application is not finished and you are expected to complete the following:

1)	The adding of a selected person to the database
		The database already exists in the form of an in memory database (InMemoryRepository)

2)	The listing page to show all the existing people in the list. Make sure the screen looks similar to the screenshots

3)	Implement the integration to the ID number lookup service (using the ConsumerViewService component). See search.js to 			understand how the lookup will be invoked. You don't have to use AJAX to get the ID number lookup information, you can use 		an old school POST to invoke the service

4)	You will notice at the top of each page a status is given of the number of calls made to the ID number lookup service. 			Implement the functionality to track the number of successfully completed ID number lookups and failed lookups. Display the 	status as per the screenshots. A failed lookup constitutes either an invalid ID number or an external service call failure.

5)	Add an IoC container (the IoC of your choice) to the application. The IoC should resolve all the controllers and 				dependencies.


Test ID numbers
---------------
8111145376080
6312015439089
5211010729083
6107310094082
8212300383083
6701265263084