Config Details - 

1. key="DB" - Set value as Sqlite path.
2. key="output_csv" set value as output file path.
3. key="logfile" set value as logfile path.

Project Details - 

In this project, I have created a method to read the data from the database file(.sqlite) and then used inline query(joins) to extract the consolidated data from the database tables.

I have created a method to export the data into csv file by downloading the file into the system on page load.
On UI, I have added an icon for exporting the csv file.

After that, I have created 2 web methods :
one is getUserDetails which is used to fetch the data from database on the basis of id.
other one is to getOver50kSalary which is used to check if the user is having salary over 50k/year.
For this, I have shown 2 buttons on UI to get the details and a table is displayed with the results fetched from API.