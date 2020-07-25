# Name 
ImmedisTask

# Installation
Download the project.  
Change your PostgreSQL credentials in the appsettings.json file both in the ImmedisTask and in the ImmedisTask.Tests project.  
Build and run.  
Migrations will be automatically applied + default seeded data will be added for testing.

# Main technologies used:
* .NET Core 3.1
* EntityFrameworkCore.PostgreSQL
* PostgreSQL database
* Bootstrap
* MSTest

# Usage

## Home screen
By entering in the home page, by default, you can see all the existing employees in the database, vizualized in descending order, starting with the last created ones.  
Each employee is displayed in a bootstrap card control, showing only part of the information about it like, department, name, job, salary and join date.  
On each card you have a "Check comments" link button which leads you to the comments viewer/editor.  
On the top of the page, you can filter all the employee cards using the input field "Search for employee", by entering the employee first and last name.  
A bit lower there is a "Create new employee" link button, which leads you to the employee editor screen where you can create a new employee record.  
Also, by clicking on the employee name in the selected card, you can edit the employee record.

## Employee editor
Starting, you can choose the line manager employee from the drop-down menu, as the line manager can be the current employee itself.  
Then you can fill all other fields, which are validated and all required.  
By clicking on the "Save" button, you save the changes and return to the home page menu.

## Comments viewer
By clicking on the "Check comments" link button on some of the employee cards, you open all the comments which correspond to the employee.  
There is also an option "Go back to employees", which leads you to the home page menu.

## Comments editor
Similar to the employee editor,   
you must fill all fields, which also are all validated and required.  
By clicking on the "Save" button, you go back to all comments for the last selected employee.




