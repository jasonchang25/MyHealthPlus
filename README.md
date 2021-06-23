# MyHealthPlus
Fullstack development of MyHealthPlus exercise using .Net Core/5 backend and Angular 12 frontend.

<strong>Specifications:</strong> 
    
    Build & software used:
    - .Net Core/5 - Back End
    - JWT authorisation tokens
    - Entity Framework Core - code first
    - SQLite - Demo Database for ease of use (Sql Express for MVP)
    - SSMS - Database Management
    - Angualar 12 - Front End

<strong>Problem Statment:</strong>
 
My name is Dr Mark Stephenson and I run a successful Medical General Practice in Brisbane CBD called MyHealthPlus. My administrative team and I are currently struggling to manage the high number of appointments we receive. Currently we utilise a desktop system to manage these appointments which is highly outdated.

We would like to transition to a website that allows our patients to register then self-serve and book an appointment with me. The two main types of appointment we offer are general check-ups and skin cancer checks. To be effective the appointments will need to show the patient details and the appointment details such as date / time. While my staff can monitor for booking conflicts I would prefer if the system stopped double bookings from happening. When I log into the system I should be able to see my appointments for the day and click into them to view details. I should also be able to save a comment against the appointment.

My staff should also be able to log in and view my appointments from their account after they have registered.

<strong>Building Project and testing:</strong> 

    Backend:
    1. Navigate to directory called "Backend" and launch the solution
    2. Run the 'MyHealthPlus' project in debug mode using IIS
      - A semi populated database has been configured already, if at any time you would like to 
        restart from a clean state delete 'MyHealthPlus.db' and run 'dotnet ef database update' 
        in the package manager console.
    3. Swagger has been added for ease of API testing
    
    Frontend:
    1. Navigate to directory called "Frontend"
    2. run 'npm i' in console
    3. run 'ng serve'
    
    General:
    Admin account  - username: admin@myhealthplus.com         password: Admin123
    Staff account  - username: staff@myhealthplus.com         password: Staff123
    Client account - username: client@myhealthplus.com        password: Client123
    Or make your own
 
<strong>Features:</strong> 
    - Valdiation of user details before allowing them to access the rest of the site
    - Front end and backend validation of appointment bookings to prevent clashes of times
    - Front end and backend validation of page access and API calls base on authorisation levels
    - inline edit table.
    - Staff and Admin accounts can only be created by Admin
 
<strong>Overview of pages:</strong> 
A website has been developed to help clients make online bookings for appointments and have staff and administrators view and manage them.
Depending on permission level of the user they will have access to the following pages:

<b>Login/Register</b>
![login](https://user-images.githubusercontent.com/21240686/123115782-b5277b80-d483-11eb-9064-b8dab37f4f61.png)

<b>Book Appointment</b>
![bookappointment](https://user-images.githubusercontent.com/21240686/123116434-40a10c80-d484-11eb-87ec-17f011f40134.png)

<b>View Appointments</b>
![image](https://user-images.githubusercontent.com/21240686/123116538-56aecd00-d484-11eb-93f4-2896031c6da1.png)
![image](https://user-images.githubusercontent.com/21240686/123116624-67f7d980-d484-11eb-863f-a6938a1f9b87.png)

<b>Create Staff Account<b/>    
![image](https://user-images.githubusercontent.com/21240686/123116679-75ad5f00-d484-11eb-9489-18a6ac1844fd.png) 



