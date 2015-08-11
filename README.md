# csharp-googledrive-sample
A simple application which gets the list of files on Google Drive

# Steps to run the application

1. Go to https://console.developers.google.com, to register your application for a Google API access key
2. Copy the Client-ID and the Client-Secret code as shared by Google API (Google Drive API in this case)
3. Replace the clientid and client-secret in the Form1.cs 
    String CLIENT_ID = "your client-id from google api goes here";
    String CLIENT_SECRET = "your client-secret key received from google api goes here";
4. Run the application. 
5. If the application is authorized to access the google drive api, then the application shall list the files on the listview
