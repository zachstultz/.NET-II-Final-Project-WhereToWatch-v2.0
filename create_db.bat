ECHO off
rem batch file to run a script to create a database.
rem 9/14/20

rem sqlcmd -S localhost -E -i wheretowatch_db.sql

sqlcmd -S localhost\sqlexpress -E -i wheretowatch_db.sql
rem sqlcmd -S localhost\mssqlserver -E -i wheretowatch_db.sql

ECHO
ECHO if no error messages appear, DB was created.
pause
