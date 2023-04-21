>**Name of project :** Omega explorer sports club (OESC)	
>	
>**Author :** Adéla Kopecká
>
>**Contact on author:**  adela-kopecka@post.cz
>
>**Date of creation :** 18.4.2023
>
<a href="https://www.buymeacoffee.com/adelakopecka" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>
---
## Table of Contents
1.  Description of Program
2.  Structure of Program
3.  Database Structure
4.  Installation
---
## Description of Program
#### Description of app
>OESC (short for OmegaExplorerSportClub)
Introducing our comprehensive volleyball club management software. Our program provides a complete suite of tools to manage your volleyball club with ease, including registration and management of players, trainers, teams, and training groups. Our user-friendly interface makes it easy to perform basic CRUD actions, allowing you to focus on what really matters - your club's success.
With our program, you can schedule matches and track detailed statistics on your teams and matches, giving you the insights you need to make informed decisions about your club. Our advanced reporting features include pie charts that show the breakdown of players in each training group, as well as detailed match reports that help you understand your team's performance.
To make your life even easier, our program allows you to download your player data in CSV format, giving you complete control over your data. Our charts and graphs make it easy to visualize and analyse your player data, so you can make informed decisions about your club.
In summary, our volleyball club management software is the ultimate tool for managing your volleyball club. Its powerful features and user-friendly interface help you manage your club with ease and make informed decisions about your team.

#### Samples from the application
>[Log in form show](https://drive.google.com/file/d/1UBs70VfRagPqJhbMiPAxOhd7wWxRNjIn/view?usp=share_link)
>
> [Registration form show](https://drive.google.com/file/d/1zp-D1jhVsdV1evDLmcs-_E1q-sZcQbH-/view?usp=share_link)
>  
>  [Main menu form show](https://drive.google.com/file/d/1inwUPhuEPSTuSno-6925ODJ_gka4dvDP/view?usp=share_link)
>  
>  [App demo video](https://drive.google.com/file/d/165lpFoRprHvCmi08-2ymhV2QSl2zwjje/view?usp=share_link)

---
## Structure of Program
###### OESC is built using the following third side libraries:
 - BCrypt.Net-Next
 - DarkModeUI
 - LiveCharts and LiveCharts.WinForms
 - MailKit
 - MimeKit
 - MaterialSkin.2
 - System.Data.SqlClient
 - Zen.Barcode.Rendering.Framework
 For more information take look in [Structure of project](https://docs.google.com/document/d/1-Jr5OvlXUMW0oLhe98hGjl3EPvQwPRK9m0w1K8ISCfA/edit?usp=share_link) also this file is located in program source code
 
###### The program is structured:
> Main menu design pattern is layered more at [Main menu architecture](https://drive.google.com/file/d/1qEn-Vg8cHUzVue00JQGTPyxK5cDs4k7P/view?usp=share_link)
> Log in process here [Log in process](https://drive.google.com/file/d/1na1aVo82lYkpu3KHTTwsADCA7_-U9dDf/view?usp=share_link)


---
## Database Structure

OESC uses a relational database specifically [sql Server(Microsoft)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) , from users personal information there is only stored e-mail address. The database is structured as follows:
- [Logical schema of database](https://drive.google.com/file/d/1mmo1nk9ySRoXnhWY_MCWapb6p29UazEl/view?usp=share_link)
- [Relational schema of database](https://drive.google.com/file/d/1kIPbx4cq78DB_ZKAoAc5nX6FhHJFH42S/view?usp=share_link)
---
## Installation guide and troubleshooting

##### To install OESC, follow these steps:
1. Set up database server and create new log in with access in to Omega database 
    (If you doesn't have Sql server and Microsoft management studio use [this tutorial](https://www.youtube.com/watch?v=kGdTg-vGs-E) )
2. Open ***OESC database structure export.sql*** script from Database folder in Microsoft management studio and run the script, then run  ***OESC dial.sql*** both scripts have to be runnered at same database.
3. Check if whole database exist on your server. If there is problem check troubleshot part.
4. Open ***Application*** folder, if you doesn't have installed .Net 6.0 then downland it from [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), after that continue. If you have .Net 6.0 then click on ***OmegaSportExplorerClub.exe*** app will open, but show you are disconnected from database. Close app and continue with setting up configuration file. 
5. Setting up configuration file: 
  Open in text editor:  ***OmegaSportExplorerClub.dll.config***
  
  >***Now set up database setting part of configuration file***:
> On this line enter your server name instead of *NameOfYourServer* :
> `<add key="DatabaseDataSource" value="NameOfYourServer"/>`

>On this line you will enter your user name of your log in to database on place *NameOfUser* :
> `<add key="DatabaseLogInName" value="NameOfUser"/>`

> On this line you will fill password of your log in on place *PasswordOfUser* :
> `<add key="DatabaseLogInPassword" value="PasswordOfUser"/> `

  >***Now set up email sender*** :
Enter your email on *SenderEmail* and password on *SenderPassword* it will work as sender of verification email, program won't abuse youe data.
`<add key="RegistrationEmailSenderEmail" value="SenderEmail"/>`
`<add key="RegistrationEmailSenderPassword" value="SenderPassword"/>`

> Last tow lines are port and SMTP server of services to which your email belongs.
> Those information can be found on service website
> List of services with link on website with this information([seznam](https://napoveda.seznam.cz/cz/imap-pop3-smtp/),[gmail](https://kinsta.com/blog/gmail-smtp->server/),[outlook](https://support.microsoft.com/en-us/office/pop-imap-and-smtp-settings-8361e398-8af4-4e97-b147-6c6c4ac95353))
> 
 >Fill smtp email information instead of *SMTPEmail*: `<add key="StmEmail" value="SMTPEmail/>`
 >Fill smtp port information instead of *SMTPPort*: `<add key="StmPort" value="SMTPPort"/>`

6. After is configuration file filled save it and your app shut successfully connect and send verification codes, after that open *OmegaSportExplorerClub.exe*. In Case of problems look in to ***troubleshooting*** section.

##### Troubleshooting of installation
> **App won't connect to database**
> 	This happens when the configuration file is filled incorrectly or your database is accessible on the Internet, another reason is that the Internet access is prohibited. Another possibility is that the Login you use from the program has access to only the databases on the server.
> 	
> **App won't send an email or crash of app after sending an email** 
> 	In this case is possible that your email is wrong or SMTP server information are wrong, also if you are using Gmail you have to allow third party to use your email. Also is necessary to be connected to an internet.
> 	
> **App won't connect to sender**
> 	In this case you have blocked port for STMP service and you can't unblocked it or change internet connection insert in to database this, but ***it is not advised to do that!***:   
> 	`Insert into AplicationUser values('root','UPXQ1F','email@example.com',''$2a$11$qaaOIYqzLVWY7WQ4SVDSxO'	,'$2a$11$qaaOIYqzLVWY7WQ4SVDSxOHz9bJhLJTFmiE94Bns6X92Gg2f.YDhe');` 
> 	
>			**user name:** *root*
>			
>			**password:** *root*



