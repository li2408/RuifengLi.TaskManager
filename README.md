# TaskManager_Final - Ruifeng Li
### Application Description:
This is an application to manager day to day tasks. The technoligies used in this project are Angular and .Net Core Web API, Entity Framework Core, SQL Server Database.

### Usage:
Please use http://localhost:4200 to access the website.
All the API details will show up on the Swagger UI.

### Pages and functionalities introduction:
The home page is called the users. In this page it displays all of the users' information with their names, email and phone numbers visible.
You can click on their names to go to next page.

After you click on their names, you will reach the user's tasks page. In this page, you can see all the tasks they have not done. Each task has the title of the task, 
the description of the task and a button "done" to delete this current task and move this task to the task history. The task will disappear from the user's current tasks
after you click "done" on the task and will show up in the their task history. In this page, you can also see the buttons "task history" and "add a task" on the right corner.
These buttons will enable you to view the user's task history and add a task for them.

After you click on the "add a task" button, you can see there's a form for you to fill out for their task. You can fill out the title, description, duedate, priority, remarks
for this user's task.
