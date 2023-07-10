# DDS skill test

Hi, Welcome to the DDS-Security skill test. 
In this quick skill test, you will need to accomplish a lite application that shows stocks changes in a **WPF** application and dammy real-time data changes. 

**Basics**

 - Please complete this project alone. 
 - You can search for help on any site, use open-source components, and use other public code with a comment. But you should specify it in a comment. 
 - The estimated time for this project is a few hours.
 - **Push changes to your forked repo**
 
 ## Instructions
 1. Fork this repository to your own GitHub account.
 2. The project should be under .net 6 or above. 
 3. The code here hints at how to get the data with a SignalR client. 
 4. Create a WPF MVVM project under the solution. And use Prism (https://prismlibrary.com) as composition infrastructure (link below) 
 5. Create  a screen divided into a few sections: 
       a. Header - Title.
       b. Configuration - option to select a color for rising stock and a different color for downing stock
       c. A table that will be filled with stocks and updated in real-time from the SignalR source. 
6. The table result should look like in the StockTableUpdate.mp4 movie - except that the colors might be changed. 
7. Create a DB and insert 10 last rows per symbol name with the latest changes. Keep it updated. The connection should be with EF Core. And can be with LocalDB OR default SQL instance. Create a migration to set-up the database.
8. Prepare the solution for transfer - update the Readme.md with instructions what to do to build and run the solution.
9. When you finish, push your repo changes and add [Adiel-Sharabi]  as a collaborator to your repo. 

  
