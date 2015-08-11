#region Author info
/*
 * Author   :   Srivatsa G. Haridas
 * Version  :   v1.0
 * Remarks  :   Retrieves list of files stored on Google Drive
 */
#endregion

#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
#endregion

namespace GoogleDriveFiles
{
    public partial class Form1 : Form
    {
        #region OAuth

        String CLIENT_ID = "your client-id from google api goes here";
        String CLIENT_SECRET = "your client-secret key received from google api goes here";

        #endregion OAuth

        #region Members 
        string[] scopes = new string[] { DriveService.Scope.Drive,
                                 DriveService.Scope.DriveFile};

        private UserCredential credential = null;
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                                                                        {
                                                                            ClientId = CLIENT_ID,
                                                                            ClientSecret = CLIENT_SECRET
                                                                        },
                                                                         scopes,
                                                                         Environment.UserName,
                                                                         CancellationToken.None,
                                                                         new FileDataStore("VATSAG.SiteVerification.Auth.Store")
                                                                                            ).Result;

            if (credential != null)
            {
                txtRefreshToken.Text = credential.Token.RefreshToken.ToString();

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "SiteVerification"
                });

                //Lists the directories on the Google Drive
                //IList directories = GetFiles(service, "mimeType='application/vnd.google-apps.folder' and trashed=false");

                //Lists all files on the Google Drive
                IList directories = GetFiles(service, "trashed=false");

                int i = 1;
                foreach (var dir in directories)
                {
                    var item = dir as Google.Apis.Drive.v2.Data.File;
                    if (item != null)
                    {
                        ListViewItem itemNo = new ListViewItem(i.ToString());
                        itemNo.SubItems.Add(item.Title);
                        listView1.Items.Add(itemNo);
                        i++;
                    }
                }
            }
        }
        /// 
        /// List all of the files and directories for the current user.  
        /// 
        /// Documentation: https://developers.google.com/drive/v2/reference/files/list
        /// Documentation Search: https://developers.google.com/drive/web/search-parameters
        ///a Valid authenticated DriveService        
        ///if Search is null will return all files        
        /// 
        public static IList GetFiles(DriveService service, string search)
        {

            IList Files = new List<File>();

            try
            {
                //List all of the files and directories for the current user.  
                // Documentation : https://developers.google.com/drive/v2/reference/files/list

                FilesResource.ListRequest list = service.Files.List();
                list.MaxResults = 1000;
                if (search != null)
                {
                    list.Q = search;
                }
                FileList filesFeed = list.Execute();

                //// Loop through until we arrive at an empty page
                while (filesFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (File item in filesFeed.Items)
                    {
                        Files.Add(item);
                    }

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }

                    // Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken;

                    // Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex)
            {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);
            }
            return Files;
        }

    }
}
