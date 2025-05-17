Student Management System – User Guide

Backend : Dot Net Core – Web API – Code First Approach – Clear Architecture

Set up database details in the appsettings.json 
 "ConnectionStrings": {
    "dbSMS": "server=XXXXX;database=SMS;Integrated Security=SSPI;Connection Timeout=30;Encrypt=false;"
    },
    
Run the following command in Package Manager Console so that it will automatically create database and its tables
PM> Add-Migration InitialCreate
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
PM> Update-Database
Build started...
Build succeeded.

 
http://server:port/swagger/index.html
Web Api with FamilyMembers, Nationalities and Students Model
 
 

