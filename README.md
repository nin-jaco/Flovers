# Flovers
 How to set up:
 1. run scripts in the DAL/Scripts directory
 2. where needed add write permissions for IIS_IUSRS and IIS AppPool\DefaultAppPool on the app_Data\Logs
 
 
- The DAL project implements Entity audit to write information about any changes to the database.  

- The Log project logs asp.net environment logs, exception logging via NLog, unhandled exception logging with elmah, solution wide, to the file system and/or database.  Service exceptions are logged with a global error attribute.

- 
 
 
 
