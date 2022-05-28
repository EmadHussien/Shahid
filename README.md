# Shahid

I developed this project in the database course.

Project description: shahid is streaming platform, a desktop application that gives user the ability to register and watch latest movies 
using C# and oracle Db 

Used Technologies: C#, oracle database, crystal reports.

### System Functionalities :

##### Admin can do the following : 
1. Login to his account.
2. see reports that summarize the system like (how many users have accounts , how much money system earn as subscribtions).

##### User can do the following : 
1. create an account (premium / free).
2. update / delete his profile.
3. premium account can see exclusive movies.
4. watch movies.



#### Database Requirements Applied : 

##### A. Using ODP.Net connected mode (OracleConnection and OracleCommand) to:
1. Select one or more rows from DB without where condition
2. Select one or more rows from DB using bind variables and command parameters
3. Insert , Update and Delete rows (without using procedures)
4. Select ONE row from DB using stored Procedures (without using sysRefCursor [use out
parameters of number data type only])
5. Select multiple rows from DB using stored procedures.
6. Insert, Update and Delete rows using stored procedures

##### B. Using ODP.Net Disconnected mode (OracleDataAdapater and Dataset) to:
1. Select certain rows for a given value entered by the user on the form
2. Select All rows from certain table
3. Insert, update, delete using oracle command builder

##### C. Using crystal reports to create reports with:
1. Grouped columns / Summarized columns/ Formulas / Labels to enhance design
and readability
2. Parameters with different data types
3. Calling reports from C#
