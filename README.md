# voice-based-email-system-for-blind-people
tool : visual studio

The main scope of the project is to enable blind user to access and work in existing e-mail system
The idea for achieving the voice based e-mail system blind people is by providing the user interface which operate using voice command
The operation and the navigation of the system is done through the voice command
The e-mail is the most commonly used communication platform for official communication like work place communication
That why we particularly design the system to operate on e-mail services

system contain four part or page they are

1.log-in page
2.home page
3.send page
4. receive page

1.log-in page:

The system start at login page

In log in page we need to provide two details 

1 username
2 password

The command to start authentication is "log in " 

After the command is issued the system compare the given detail with database. 
If the match is found the move to home page. Else indicated user to give correct details using the speech synthesis

2.home page:

After the successful login the user is moved to home page

Home is the dashboard of the system from home page only we move to send or receive page 

After completing the task in send or receive page we return home page only we can't move between send and receive page directly

The command used for move to send page is "new"

The command used for move to receive page is "Inbox"
 
The command used to exit from the is "exit"

3.send page
The command used for leaving home and enter send or compose page is "new"
In send or compose page 
We need to give three details
1 is the reciver mail id
2 the subject of mail
3 the content of mail

After giving the required detail the command "compose" is used to send the mail
After the mail is successful send the system notify us using the speech synthesis 
In order to exit from send or compose page and go back to home page the "close" command is used

4.receive page

The command used for leaving home and enter receive page is "inbox"

In receive page 
We need to give two details and it has three field

1 mail id from which you need to check the mail
2 password


After giving the required detail the command "inbox" is used to receive the mail
After the mail is successful received the system notify us using the speech synthesis 

And the details of the received mail is displayed in 3rd field content field

in order to read out the received mail content the "read" command is used

In order to exit from receive page and go back to home page the "close" command is used
*********************************************************************************************

software tool required:

Front end:
      Visual studio 
     	Microsoft Visual Studio is an integrated development environment (IDE) from Microsoft.
  It is used to develop computer programs, as well as websites, web apps, web services and mobile apps.
  Visual Studio uses Microsoft software development platforms such as Windows API, Windows Forms, Windows Presentation Foundation, Windows Store and Microsoft Silverlight.
  
Back end:
      MS SQL
      Microsoft SQL Server is a relational database management system developed by Microsoft. 
      As a database server, it is a software product with the primary function of storing and retrieving data as 
      requested by other software applications—which may run either on the same computer or on another computer across a network
