# CKEditor-MSQL-DB

It is recommend to read the following medium article before using the project:\
To download the ckeditor: https://ckeditor.com/ckeditor-4/download/

*After cloning(downloading) the project, please make the following changes the relavent files:*

1. **apsettings.json**

    Insert the connection string to your Microsoft SQL database replacing 'ConectionStringToSQLDB' at line 3. This is the connection string with the name 'DefaultConnectioin'. (do not delete the double quotes)
    
    <br/>
    <br/>
    
**Then try the following command in NuGet Package Manger Console:**

    update-database
    
*If it fails to build, Then follow the steps below:*

1. Delete the folder 'Migrations' with the all the contents in it.

3. Run the following command in NuGet Package Manger Console (This will create the migrations again)

    `add-migration BlobUploadWebApp-Migrations`
    
4. The run the following command again. (This will update the database creating the relavent classes)

   `update-database`
