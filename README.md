
# WeBelieveIT
Assessment about creation, assigning and tracking of task progresss and ownership.

I hope you will enjoy reviewing my work, I have developed the Web api usingEntity Framework Core targetting .Net 5 Web api and SSMS to manage my SQL database. There is SQL script that is used to generate a Database and relevant tables, should you want to test the code using the real Database.

I have decided use the 3 tier architecture as our priority was the back-end and this architecture gives us all the flexibility to test our code as it breaks units into different layers Business-Logic and Data-Layer.

**How to run the application**
  o I was using the actual Database to test the APi but how ever I have added a test data on At startup.cs and configure it to work as a default unless code have been commentedd out
  o In short you will have to just install all the required packages to run the Api and ensure its builds successfully before you press F5 on visual studio, it will work using te default data in EF CORE inMemory


 **Reason for specific designs and interfaces**

   
  	o I have decided use the 3 tier architecture as our priority was the back-end and this architecture gives us all the flexibility to test our code as it breaks units into different layers Business-Logic and Data-Layer.
	
  	o Application can scale easy and without degraded performance
	
  	o Improved data integrity as data can be filtered in different layers
	
  	o Access to database is limmitted and its makes it easier to implement\improve security.
	
  	o It’s possible to scale or change the implementation of a tier on its own without affecting other tiers of the system.
	
  	o Registration of controllers using interfaces makes it more controllable.

  
**List any encountered obstacles and how you solved them**

	o In designing ERD (Table relationship), I bumped into circular model referencing and I had to break up some relationship. i.e "Possible object cycle was detected"
	
	o Generating Model from existing database, EF Core did not pick up Primary Key and other specification and that cause ID conflicts with Foreign and Primary Key and issues in consuming posting Api. I had to specify primary Key
	
	o Laptop security in adding some of the packages to complete the assessment.
	
	o Adding Auth security and decided that it was not of high priority
	
	o In creating asp.net Api, I was expecting target framework to be written like .Net Core 5 but I have learnt that "Core" have been removed to indicate that now onwards .Net will support but .Net Framework and .Net Core hence "Framework" and "Core" will be removed all together in future 
	
	o I struggled with iitialising the context so I could be able to use xUnit in correctly tsting my APi, fr now my xUnit tests are not working but I will be looking at them as it bothers me. But i Have tested it using Swagger and all Api are working but it was was just configuring the right context to use in xUnit test that is bothering me.
	

**List resources used and relevant references**

	o Unit Test controller https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-5.0
	
	o Fixing the error “A possible object cycle was detected” in different versions of ASP.NET Core - https://gavilan.blog/2021/05/19/fixing-the-error-a-possible-object-cycle-was-detected-in-different-versions-of-asp-net-core/
	
	o EF Core inMemory - https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=vs
	
        o I ussually use designer tools to generate models from DB but had to try commands for a change https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
	

**How long you took to complete the assignment**

	o I have designed this solutio using two approach MVC and 3 tier architecture, I wanted to use this opportunity as well as to explore the difference between these two approach.
	o Throuugh MVC its took me about a hour to complete the assessment and that was my expectation, MVC is less complicated that 3 tier but its prioritises on client layer(View/Front-End) here is the repo : https://github.com/SniraJavas/WeBelieveIT.Task.Tracker
	o 3 tier took me about 4 hours as there have been breaks and laptop issues, The laptop that I have been using have battery problem so it would switch off anytime due to electricity maintanance that have been taking place and other responsibilities that required my attention.
	o Building Unit test took me +-30 minutes on top of that 4 hours, The delay here came from my approach that I chose to use actuall database and installing and configuring came with other issues. 
	
 **If you have more time, what would you do differently? Also, what would you have 
added additionally?**

	o If I had to get another chance I would have used EF Core inMemory straight up
	o I should have used TDD approach so it would guide me to reach my requirements at a paced rate and assist me from encoutering destruction and end up adding unneccessary features and to produce more quality code.
