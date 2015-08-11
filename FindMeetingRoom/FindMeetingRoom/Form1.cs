/*
 * Orion Tower-2 Meeting Room Locator
 * 
 * Version 1.0              :   Locates Meeting Rooms which are free.
 * Version 2.0(TODO)        :   Book a meeting room
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FindMeetingRoom
{
    /*
     * olBusy               -   2   -   The user is busy.
       olFree               -   0   -   The user is available.
     * olOutOfOffice        -   3   -   The user is out of office.
     * olTentative          -   1   -   The user has a tentative appointment scheduled.
     * olWorkingElsewhere   -   4   -   The user is working in a location away from the office.
     * 
     *  CR-IE3B OT1 - 0C21 (6 chairs, LCD) + Connect360	ConfOT1-0C216chairsLCD@Honeywell.com
     *  CR-IE3B OT1 - 0D21 (6 chairs, LCD)	ConfOT1-0D216chairsLCD@Honeywell.com
     *  CR-IE3B OT1 - 0M35 (4 chairs)	ConfOT1-0M354chairs@Honeywell.com
        CR-IE3B OT1 - 0M37 (4 chairs)	ConfOT1-0M374chairs@Honeywell.com
        CR-IE3B OT1 - 0M51 (6 chairs, LCD) + Connect360	ConfOrionOM-51@Honeywell.com
        CR-IE3B OT1 - 0N03 (6 chairs, LCD)	ConfOT1-0N036chairsLCD@Honeywell.com
        CR-IE3B OT1 - 0O35 (4 chairs)	ConfOT1-0O354chairs@Honeywell.com
        CR-IE3B OT1 - 0O37 (4 chairs)	ConfOT1-0O374chairs@Honeywell.com
        CR-IE3B OT1 - 0P48 (6 chairs, LCD) + Connect360	ConfOrionOP-48@Honeywell.com
        CR-IE3B OT1 - 0Q12 (12 chairs, Projector)	CROT1-0Q1212chairsProjector@Honeywell.com
     * 
        CR-IE3B OT1 - 1D36 (6 chairs, LCD)	ConfOrion1D-36@Honeywell.com
        CR-IE3B OT1 - 1H03 (6 chairs )	ConfOT1-1H036chairs@Honeywell.com
        CR-IE3B OT1 - 1Q12 (10 chairs, Projector) + Connect360	ConfOrion1Q-12@Honeywell.com
        CR-IE3B OT1 - 1R39 (4 chairs)	ConfOT1-1R394chairs@Honeywell.com
        CR-IE3B OT1 - 1R42 (4 chairs)	ConfOT1-1R424chairs@Honeywell.com
        CR-IE3B OT1 - 1S43 (6 chairs, LCD) + Connect360	ConfOT1-1S43@Honeywell.com
     * 
        CR-IE3B OT1 - 2L35	ConfOrion2L-35@Honeywell.com
        CR-IE3B OT1 - 2M42 (6 chairs, LCD)	ConfOrion2M-42@Honeywell.com
        CR-IE3B OT1 - 2O38 (4 chairs)	ConfOT1-2O384chairs@Honeywell.com
        CR-IE3B OT1 - 2O41 (4 chairs)	ConfOT1-2O414chairs@Honeywell.com
        CR-IE3B OT1 - 2P22 (8 chairs projector)	ConfOrion2P-22@Honeywell.com
        CR-IE3B OT1 - 2P35 (8 chairs projector)	ConfOrion2P-35@Honeywell.com
        CR-IE3B OT1 - 2Q12 (Reserved)	ConfOrion2Q-12@Honeywell.com
        CR-IE3B OT1 - 2Q22 (10 chairs, Projector)	ConfOrion2Q-22@Honeywell.com
        CR-IE3B OT1 - 2Q35 (10 chairs, Projector) + Connect360	ConfOrion2Q-35@Honeywell.com
     * 
        CR-IE3B OT1 - 3L22 (10 chairs, Projector) + Connect360	ConfOrion3L-22@Honeywell.com
        CR-IE3B OT1 - 3M01 (6 chairs, LCD)	ConfOT1-3M016chairsLCD@Honeywell.com
        CR-IE3B OT1 - 3M42 (6 chairs, LCD)	ConfOrion3M-42@Honeywell.com
        CR-IE3B OT1 - 3O41 (4 chairs)	ConfOT1-3O414chairs@Honeywell.com
        CR-IE3B OT1 - 3P22 (10 chairs, Projector)	ConfOrion3P-22@Honeywell.com
        CR-IE3B OT1 - 3Q12 (Reserved)	ConfOrion3Q-12@Honeywell.com
        CR-IE3B OT1 - 3Q22 (10 chairs, Projector)	ConfOrion3Q-22@Honeywell.com
        CR-IE3B OT1 - 3Q47 (12 chairs, Projector) + Connect360	ConfOrion3Q-47@Honeywell.com
     * 
        CR-IE3B OT1 - 4L22 (8 chairs projector) + Connect360	ConfOrion4L-22@Honeywell.com
        CR-IE3B OT1 - 4M01 (6 chairs, LCD)	ConfOT1-4M016chairsLCD@Honeywell.com
        CR-IE3B OT1 - 4M26 (Reserved)	ConfOrion4M-26@Honeywell.com
        CR-IE3B OT1 - 4O38 (4 chairs)	ConfOT1-4O384chairs@Honeywell.com
        CR-IE3B OT1 - 4P22 (8 chairs projector)	ConfOrion4P-22@Honeywell.com
        CR-IE3B OT1 - 4P34 (10 chairs, Projector) + Connect360	ConfOrion4P-34@Honeywell.com
        CR-IE3B OT1 - 4Q12 (10 chairs, Projector)	ConfOrion4Q-12@Honeywell.com
        CR-IE3B OT1 - 4Q22 (10 chairs, Projector)	ConfOrion4Q-22@Honeywell.com
        CR-IE3B OT1 - 4Q34 (10 chairs, Projector)	ConfOrion4Q-34@Honeywell.com
        CR-IE3B OT1 - 4Q47 (Reserved)	ConfOT1-4Q47Reserved@Honeywell.com
     * 
        CR-IE3B OT1 - 5L22 (10 Chairs, 1 Projector) + Connect360	ConfOT1-5L22@honeywell.com
        CR-IE3B OT1 - 5M01 (6 chairs, LCD)	ConfOT1-5M016chairsLCD@Honeywell.com
        CR-IE3B OT1 - 5M43 (6 chairs, LCD)	ConfOT1-5M436chairsLCD@Honeywell.com
        CR-IE3B OT1 - 5O38 (4 chairs)	ConfOT1-5O384chairs@Honeywell.com
        CR-IE3B OT1 - 5O42 (4 chairs)	ConfOT1-5O424chairs@Honeywell.com
        CR-IE3B OT1 - 5P22 (10 Chairs, 1 Projector)	ConfOT1-5P22@honeywell.com
        CR-IE3B OT1 - 5Q12 (12 Chairs, 1 Projector)	ConfOT1-5Q12@honeywell.com
        CR-IE3B OT1 - 5Q22 (10 Chairs, 1 Projector)	ConfOT1-5Q22@honeywell.com
        CR-IE3B OT1 - 5Q34 (10 Chairs, 1 Projector)	ConfOT1-5Q34@honeywell.com
        CR-IE3B OT1 - 5Q47 (12 Chairs, 1 Projector) + Connect360	ConfOT1-5Q47@honeywell.com
     * 
        CR-IE3B OT1 - 6L22 (8 chairs, Projector) + Connect360	ConfOrion6L-22@Honeywell.com
        CR-IE3B OT1 - 6L34 (8 chairs, Projector)	ConfOrion6L-34@Honeywell.com
        CR-IE3B OT1 - 6P22 (8 chairs, Projector)	ConfOrion6P-22@Honeywell.com
        CR-IE3B OT1 - 6P34 (8 chairs, Projector)	ConfOT1-6P348chairsProjector@Honeywell.com
        CR-IE3B OT1 - 6Q12 (Reserved)	ConfOrion6Q-22@Honeywell.com
        CR-IE3B OT1 - 6Q47 (10 chairs, Projector) + Connect360	ConfOT1-6Q4710chairsProjector@Honeywell.com
     * 
        CR-IE3B OT1 - 7O42 (6 chairs, LCD )	ConfOrion7O-42@Honeywell.com
        CR-IE3B OT1 - 7P22 (Reserved)	ConfOrion7P-22@Honeywell.com
        CR-IE3B OT1 - 7P39 (4 chairs )	ConfOT1-7P394chairs@Honeywell.com
        CR-IE3B OT1 - 7Q35 (10 chairs, Projector)	ConfOrion7Q-35@Honeywell.com
        CR-IE3B OT1 7L22	CR-IE3BOT17L22@Honeywell.com
        CR-IE3B OT1-LRS02	IE3B-OT1-LRS02@Honeywell.com
     * 
     */
    public partial class Form1 : Form
    {
        Microsoft.Office.Interop.Outlook.Application oApp = null;
        NameSpace mapiNamespace = null;
        MAPIFolder CalendarFolder = null;
        _Folders oFolders;
        Items outlookCalendarItems = null;
        Stores stores = null;
        Recipient oRecipient = null;

        DateTime startTime,endTime;
        
        List<RoomDetails> meetingRoomList;
        List<RoomDetails> availableRooms;
        Dictionary<int, string> timeSlots;
        Dictionary<RoomDetails, string> dictRoomStatus;
        Dictionary<RoomDetails, string> dictUpdatedRoomStatus;
        Dictionary<int,List<RoomDetails>> dictMeetingRooms;

        string[] time = new string[]    {"00:00","01:00","02:00","03:00","04:00","05:00","06:00","07:00","08:00","09:00","10:00",
                                         "11:00","12:00","13:00","14:00","15:00","16:00","17:00","18:00","19:00","20:00","21:00",
                                         "22:00","23:00"};
        
        int startTimeIndex = 0;
        int endTimeIndex = 0;
        int iSelectedFloorIndex = 0;
        CheckBox chkBoxSelectAllHeader = null;
        bool IsHeaderCheckBoxClicked = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            startTime = DateTime.Now;
            endTime = DateTime.Now.AddMinutes(59);
            //listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            LoadTimeSlots();

            LoadMeetingRooms();
            
            LoadConferenceRooms();

            oApp = new Microsoft.Office.Interop.Outlook.Application();
            mapiNamespace = oApp.GetNamespace("MAPI");
            stores = mapiNamespace.Stores;
            oFolders = mapiNamespace.Folders;
            
            CalendarFolder = oApp.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
            outlookCalendarItems = CalendarFolder.Items;
            outlookCalendarItems.IncludeRecurrences = true;

            //CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
            //outlookCalendarItems = CalendarFolder.Items;
            //outlookCalendarItems.IncludeRecurrences = true;
        }


        /// <summary>
        /// Loads all the meeting rooms 
        /// </summary>
        private void LoadMeetingRooms()
        {
            dictMeetingRooms = new Dictionary<int, List<RoomDetails>>();

            /*
             * Ground floor
             */
            List<RoomDetails> groundFloor = new List<RoomDetails>();
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0C21 (6 chairs, LCD) + Connect360", Mail = "ConfOT1-0C216chairsLCD@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0D21 (6 chairs, LCD)", Mail = "ConfOT1-0D216chairsLCD@Honeywell.com" });
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0M35 (4 chairs)",Mail="ConfOT1-0M354chairs@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = " CR-IE3B OT1 - 0M37 (4 chairs)",Mail="ConfOT1-0M374chairs@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0M51 (6 chairs, LCD)",Mail="ConfOrionOM-51@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0N03 (6 chairs, LCD)",Mail="ConfOT1-0N036chairsLCD@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0O35 (4 chairs)",Mail="ConfOT1-0O354chairs@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0O37 (4 chairs)",Mail="ConfOT1-0O374chairs@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0P48 (6 chairs, LCD) + Connect360",Mail="ConfOrionOP-48@Honeywell.com"});
            groundFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 0Q12 (12 chairs, Projector)",Mail="CROT1-0Q1212chairsProjector@Honeywell.com"});
            dictMeetingRooms.Add(0, groundFloor);

            /*
             * First floor
             */
            List<RoomDetails> firstFloor = new List<RoomDetails>();
            firstFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 1D36 (6 chairs, LCD)", Mail= "ConfOrion1D-36@Honeywell.com"});
            firstFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 1H03 (6 chairs)", Mail=  "ConfOT1-1H036chairs@Honeywell.com"});
            firstFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 1Q12 (10 chairs, Projector) + Connect360" , Mail=  "ConfOrion1Q-12@Honeywell.com"});
            firstFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 1R39 (4 chairs)", Mail=  "ConfOT1-1R394chairs@Honeywell.com"});
            firstFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 1R42 (4 chairs)", Mail=  "ConfOT1-1R424chairs@Honeywell.com"});
            firstFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 1S43 (6 chairs, LCD) + Connect360", Mail=  "ConfOT1-1S43@Honeywell.com"});
            dictMeetingRooms.Add(1, firstFloor);
                
            /*
             * Second Floor
             */
             List<RoomDetails> secFloor = new List<RoomDetails>();
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2L35", Mail="ConfOrion2L-35@Honeywell.com"});  
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2M42  (6 chairs,LCD)", Mail="ConfOrion2M-42@Honeywell.com"});
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2O38  (4 chairs)", Mail="ConfOT1-2O384chairs@Honeywell.com"});
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2O41  (4 chairs)", Mail="ConfOT1-2O414chairs@Honeywell.com"});
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2P22  (8 chairs projector)", Mail="ConfOrion2P-22@Honeywell.com"});
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2P35  (8 chairs projector)", Mail="ConfOrion2P-35@Honeywell.com"});
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2Q12  (Reserved)", Mail="ConfOrion2Q-12@Honeywell.com"});
             secFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 2Q22  (10 chairs, Projector)", Mail="ConfOrion2Q-22@Honeywell.com"});
             secFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 2Q35  (10 chairs, Projector) + Connect360", Mail = "ConfOrion2Q-35@Honeywell.com" });
             dictMeetingRooms.Add(2, secFloor);
      
             /*
             * Third floor
             */
             List<RoomDetails> thirdFloor = new List<RoomDetails>();
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3L22 (10 chairs, Projector) + Connect360", Mail="ConfOrion3L-22@Honeywell.com"});  
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3M01 (6 chairs,LCD)", Mail="ConfOT1-3M016chairsLCD@Honeywell.com"});
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3M42 (6 chairs,LCD)", Mail="ConfOrion3M-42@Honeywell.com"});
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3O41 (4 chairs)	  (4 chairs)", Mail="ConfOT1-3O414chairs@Honeywell.com"});
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3P22 (10 chairs, projector)", Mail="ConfOrion3P-22@Honeywell.com"});
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3Q12 (Reserved)", Mail="ConfOrion3Q-12@Honeywell.com"});
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3Q22 (10 chairs,projector", Mail="ConfOrion3Q-22@Honeywell.com"});
             thirdFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 3Q47 (12 chairs,Projector) + Connect 360", Mail="ConfOrion3Q-47@Honeywell.com"});
             dictMeetingRooms.Add(3, thirdFloor);

             /*
             * Fourth floor
             */
             List<RoomDetails> fourthFloor = new List<RoomDetails>();
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4L22 (8 chairs projector) + Connect360", Mail = "ConfOrion4L-22@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4M01 (6 chairs, LCD)", Mail = "ConfOT1-4M016chairsLCD@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4M26 (Reserved)", Mail = "ConfOrion4M-26@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4O38 (4 chairs)", Mail = "ConfOT1-4O384chairs@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4P22 (8 chairs projector)", Mail = "ConfOrion4P-22@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4P34 (10 chairs, Projector) + Connect360", Mail = "ConfOrion4P-34@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4Q12 (10 chairs, Projector)", Mail = "ConfOrion4Q-12@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4Q22 (10 chairs, Projector)", Mail = "ConfOrion4Q-22@Honeywell.com" });
             fourthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 4Q34 (10 chairs, Projector)", Mail = "ConfOrion4Q-34@Honeywell.com" });
             dictMeetingRooms.Add(4, fourthFloor);

             /*
              * Fifth Floor
              */   
             List<RoomDetails> fifthFloor = new List<RoomDetails>();
             fifthFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 5L22 (10 Chairs, 1 Projector) + Connect360" , Mail = "ConfOT1-5L22@honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5M01 (6 chairs, LCD)", Mail = "ConfOT1-5M016chairsLCD@Honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5M43 (6 chairs, LCD)", Mail = "ConfOT1-5M436chairsLCD@Honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5O38 (4 chairs)", Mail = "ConfOT1-5O384chairs@Honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5O42 (4 chairs)", Mail = "ConfOT1-5O424chairs@Honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5P22 (10 Chairs, 1 Projector)", Mail = "ConfOT1-5P22@honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5Q12 (12 Chairs, 1 Projector)", Mail = "ConfOT1-5Q12@honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5Q22 (10 Chairs, 1 Projector)", Mail = "ConfOT1-5Q22@honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name =   "CR-IE3B OT1 - 5Q34 (10 Chairs, 1 Projector)", Mail = "ConfOT1-5Q34@honeywell.com"});
             fifthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 5Q47 (12 Chairs, 1 Projector) + Connect360", Mail = "ConfOT1-5Q47@honeywell.com" });
             dictMeetingRooms.Add(5, fifthFloor);


             /*
              * Sixth Floor
              */   
             List<RoomDetails> sixthFloor = new List<RoomDetails>();
             sixthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 6L22 (8 chairs, Projector) + Connect360", Mail = "ConfOrion6L-22@Honeywell.com" });
             sixthFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 6L34 (8 chairs, Projector)" ,      Mail="ConfOrion6L-34@Honeywell.com"});
             sixthFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 6P22 (8 chairs, Projector)" ,      Mail="ConfOrion6P-22@Honeywell.com"});
             sixthFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 6P34 (8 chairs, Projector)" ,      Mail="ConfOT1-6P348chairsProjector@Honeywell.com"});
             sixthFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 6Q12 (Reserved)",      Mail="ConfOrion6Q-22@Honeywell.com"});
             sixthFloor.Add(new RoomDetails { Name = "CR-IE3B OT1 - 6Q47 (10 chairs, Projector) + Connect360", Mail = "ConfOT1-6Q4710chairsProjector@Honeywell.com" });
             dictMeetingRooms.Add(6, sixthFloor);
               	
            /*
             * Seventh Floor
             */   
             List<RoomDetails> seventhFloor = new List<RoomDetails>();
            seventhFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 7O42 (6 chairs, LCD )",Mail="ConfOrion7O-42@Honeywell.com"});
            seventhFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 7P22 (Reserved)",      Mail="ConfOrion7P-22@Honeywell.com"});
            seventhFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 7P39 (4 chairs )",      Mail="ConfOT1-7P394chairs@Honeywell.com"});
            seventhFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 - 7Q35 (10 chairs, Projector)",      Mail="ConfOrion7Q-35@Honeywell.com"});
            seventhFloor.Add(new RoomDetails { Name =  "CR-IE3B OT1 7L22	",      Mail="CR-IE3BOT17L22@Honeywell.com"});
            seventhFloor.Add(new RoomDetails { Name = "CR-IE3B OT1-LRS02", Mail = "IE3B-OT1-LRS02@Honeywell.com" });
            dictMeetingRooms.Add(7, seventhFloor);
        }


        /// <summary>
        /// 24-hr time slots 
        /// </summary>
        private void LoadTimeSlots()
        {
            timeSlots = new Dictionary<int, string>();
            int iTime = 0;
            foreach (var timeband in time) 
            {
                timeSlots.Add(iTime, timeband);
                iTime++;
            }

            cmbStartTime.Items.AddRange(timeSlots.Values.ToArray());
            cmbEndTime.Items.AddRange(timeSlots.Values.ToArray());
            cmbStartTime.SelectedIndex = 0;
            startTimeIndex = cmbStartTime.Items.IndexOf(DateTime.Now.ToString("HH:00"));
            cmbEndTime.SelectedIndex = 0;
        }


        /// <summary>
        /// Populates all the list of rooms available in Tower 1 
        /// </summary>
        private void LoadConferenceRooms()
        {
            cmbFloorSelection.SelectedIndex = 0;
            UpdateDataGridView(dictMeetingRooms[0]);
            // show animated image
            this.pictureBoxWait.Image = Properties.Resources.Information;
            this.lblInformation.Text = "Find a Meeting Room...";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rooms"></param>
        private void UpdateDataGridView(List<RoomDetails> rooms)
        {
            int rowIndex = 0;

            if (dgvMeetingRoomStatus.Rows.Count > 0)
            {
                dgvMeetingRoomStatus.Rows.Clear();
            }

            foreach (var listItem in rooms)
            {
                if ((listItem.Name != null) && (listItem.Mail != null))
                {
                    dgvMeetingRoomStatus.Rows.Add();
                    dgvMeetingRoomStatus.Rows[rowIndex].Cells[1].Value = listItem.Name;
                    dgvMeetingRoomStatus.Rows[rowIndex].Cells[2].Value = listItem.Mail;
                    rowIndex++;
                }
            }
        }

        /// <summary>
        /// Finds room which are free in the requested period 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindRoom_Click(object sender, EventArgs e)
        {
            if (radBtnLater.Checked)
            {
                GetLatestDateTime();
            }
            else 
            {
                startTime = DateTime.Now;
            }

            if (startTime.Date > DateTime.Now.Date)
            {
                SearchMeetingRoom();
            }
            else
            {
                if (startTime.Hour >= DateTime.Now.Hour)
                {
                    SearchMeetingRoom();
                }
                else
                {
                    DisplayWarning();
                }
            }
        }

        private void SearchMeetingRoom()
        {
            availableRooms = new List<RoomDetails>();
            foreach (DataGridViewRow row in dgvMeetingRoomStatus.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value == chk.TrueValue)
                {
                    availableRooms.Add(new RoomDetails()
                    {
                        Name = ((DataGridViewTextBoxCell)row.Cells[1]).Value.ToString(),
                        Mail = ((DataGridViewTextBoxCell)row.Cells[2]).Value.ToString()
                    });
                }
            }

            if (availableRooms.Count > 0)
            {
                // show animated image
                this.pictureBoxWait.Image = Properties.Resources.Animation;
                this.lblInformation.Text = "Finding available rooms...";
                backgroundWorkerLocator.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Select at least one Meeting Room", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DisplayWarning()
        {
            MessageBox.Show("Please select a later date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        /// <summary>
        /// Update the availability status of the meeting room
        /// </summary>
        private void UpdateMeetingRoomStatus()
        {
            int rowIndex = 0;
            if (dictUpdatedRoomStatus.Count > 0)
            {
                dgvMeetingRoomStatus.Rows.Clear();
                foreach (var listItem in dictUpdatedRoomStatus)
                {
                    if ((listItem.Key != null && listItem.Value != null))
                    {
                        dgvMeetingRoomStatus.Rows.Add();
                        dgvMeetingRoomStatus.Rows[rowIndex].Cells[1].Value = listItem.Key.Name;
                        dgvMeetingRoomStatus.Rows[rowIndex].Cells[2].Value = listItem.Key.Mail;
                        dgvMeetingRoomStatus.Rows[rowIndex].Cells[3].Value = listItem.Value;
                        rowIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Returns availability in 24hr format
        /// </summary>
        /// <param name="roomMailAddress"></param>
        private string GetRoomAvailability(string roomMailAddress) 
        {
            string strReturn;
            try
            {
                oRecipient = oApp.Session.CreateRecipient(roomMailAddress);
                //return oRecipient.FreeBusy(DateTime.Now, 60, true).Substring(0, 24);
                strReturn = oRecipient.FreeBusy(startTime, 60, true).Substring(0, 24);
            }
            catch (System.Exception ex) 
            {
                strReturn = null;
            }
            return strReturn;
        }

        /// <summary>
        /// Get recurring appointments in date range.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns>Outlook.Items</returns>
        private Microsoft.Office.Interop.Outlook.Items GetAppointmentsInRange(
            Microsoft.Office.Interop.Outlook.Folder folder, DateTime startTime, DateTime endTime)
        {
            string filter = "[Start] >= '"
                + startTime.ToString("g")
                + "' AND [End] <= '"
                + endTime.ToString("g") + "'";
            Debug.WriteLine(filter);
            try
            {
                Microsoft.Office.Interop.Outlook.Items calItems = folder.Items;
                calItems.IncludeRecurrences = true;
                calItems.Sort("[Start]", Type.Missing);
                Microsoft.Office.Interop.Outlook.Items restrictItems = calItems.Restrict(filter);
                if (restrictItems.Count > 0)
                {
                    return restrictItems;
                }
                else
                {
                    return null;
                }
            }
            catch { return null; }
        }

        /// <summary>
        /// Books the selected room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            /*
             * Book the selected room
             */

        ////    Outlook.AppointmentItem appt =
        ////    Application.CreateItem(
        ////    Outlook.OlItemType.olAppointmentItem)
        ////as Outlook.AppointmentItem;
        ////    appt.Subject = "Customer Review";
        ////    appt.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
        ////    appt.Location = "36/2021";
        ////    appt.Start = DateTime.Parse("10/20/2006 10:00 AM");
        ////    appt.End = DateTime.Parse("10/20/2006 11:00 AM");
        ////    Outlook.Recipient recipRequired =
        ////        appt.Recipients.Add("Ryan Gregg");
        ////    recipRequired.Type =
        ////        (int)Outlook.OlMeetingRecipientType.olRequired;
        ////    Outlook.Recipient recipOptional =
        ////        appt.Recipients.Add("Peter Allenspach");
        ////    recipOptional.Type =
        ////        (int)Outlook.OlMeetingRecipientType.olOptional;
        ////    Outlook.Recipient recipConf =
        ////       appt.Recipients.Add("Conf Room 36/2021 (14) AV");
        ////    recipConf.Type =
        ////        (int)Outlook.OlMeetingRecipientType.olResource;
        ////    appt.Recipients.ResolveAll();
        ////    appt.Display(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDateTimeSelected(object sender, EventArgs e)
        {
            DateTimePicker date = (DateTimePicker)sender;
            //if (date.Value.Millisecond < DateTime.Now.Millisecond) 
            //{
            //    MessageBox.Show("Select a valid future date");
            //    return;
            //}
            startTime = DateTime.Parse(date.Value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBtnNow_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnNow.Checked)
            {
                startTime = DateTime.Now;
                endTime = DateTime.Now.AddMinutes(59);
            }

            groupBox2.Enabled = !radBtnNow.Checked;
        }

        /// <summary>
        /// Checks/Unchecks all the items in the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMeetingRoomStatus.Rows)
            {
                if (chkBoxSelectAll.Checked)
                {
                    /*
                     * Change the status of the cell only if it was un-checked earlier
                     */
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value != chk.TrueValue)
                    {
                        chk.Value = chk.TrueValue;
                        row.Selected = true;
                    }
                }
                else 
                {
                    /*
                     * Clears the selection of all the cells
                     */
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = chk.FalseValue;
                }
            }
        }

        private void OnDGVCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selectedRow = dgvMeetingRoomStatus.Rows[e.RowIndex];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)selectedRow.Cells[0];
                if (chk.Value == chk.TrueValue)
                {
                    chk.Value = chk.FalseValue;
                }
                else
                {
                    chk.Value = chk.TrueValue;
                    dgvMeetingRoomStatus.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        /// <summary>
        /// Records the Start time of the meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStartTimeSelected(object sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            startTimeIndex = cb.SelectedIndex;
            if (startTimeIndex + 1 <= timeSlots.Count)
            {
                cmbEndTime.Items.Clear();
                cmbEndTime.Items.AddRange(timeSlots.Values.Skip(startTimeIndex + 1).ToArray());
            }

            GetLatestDateTime();

            btnFindRoom.Enabled = true;
            cmbEndTime.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets the latest start date time corresponding to the value selected on the UI
        /// </summary>
        private void GetLatestDateTime()
        {
            var dt = dateTimePicker1.Value.ToString("dd-MM-yyyy"); // time is zero by default
            string timeUpdated = dt + " " + cmbStartTime.Text;
            DateTime.TryParseExact(dt + " " + cmbStartTime.Text, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeLocal, out startTime);
        }

        /// <summary>
        /// Records the End Time of the meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEndTimeSelected(object sender, EventArgs e)
        {
            endTime.Add(TimeSpan.Parse(cmbEndTime.Text));
            //string format = "HH:mm";
            //endTime = DateTime.ParseExact(cmbEndTime.Text, format, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Reset the ongoing search session.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnFindRoom.Enabled = true;
            availableRooms.Clear();
            LoadConferenceRooms();
            btnReset.Enabled = false;
            chkBoxSelectAll.Checked = false;
        }

        /// <summary>
        /// Colors specific row (room detail) in green if the room is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDGVCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMeetingRoomStatus.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvMeetingRoomStatus.Rows)
                {
                    if ((row.Cells[3].Value != null) && (row.Cells[3].Value.ToString() == "FREE"))
                    {
                        row.DefaultCellStyle.BackColor = Color.LimeGreen;
                    }
                }
            }
        }


        /// <summary>
        /// Floor selection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectedFloorChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox) sender;
            List<RoomDetails> floorDetails = dictMeetingRooms[cb.SelectedIndex];
            UpdateDataGridView(floorDetails);
        }

        /// <summary>
        /// Async operation to find a meeting room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDoWorkFindRoom(object sender, DoWorkEventArgs e)
        {
            /*
             * Get the status of the selected meeting rooms
             */
            dictRoomStatus = new Dictionary<RoomDetails, string>(availableRooms.Count);

            Parallel.ForEach(availableRooms, room =>
            {
                string mailAddress = room.Mail;
                string response = GetRoomAvailability(mailAddress);
                if (response != null)
                {
                    if (!dictRoomStatus.ContainsKey(room))
                    {
                        dictRoomStatus.Add(room, response);
                    }
                }
            });


            availableRooms.Clear();
            dictUpdatedRoomStatus = new Dictionary<RoomDetails, string>();

            /*
             * Parallel processing of the room status
             */
            Parallel.ForEach(dictRoomStatus, meetingRooms =>
            {
                var rooms = meetingRooms.Key;
                string response = meetingRooms.Value;

                int val;
                char[] schedule = response.ToCharArray();
                int.TryParse(schedule[startTimeIndex].ToString(), out val);

                RoomStatus status;
                Enum.TryParse<RoomStatus>(schedule[startTimeIndex].ToString(), out status);

                switch (status)
                {
                    case RoomStatus.FREE:
                        dictUpdatedRoomStatus.Add(rooms, "FREE");
                        break;
                    case RoomStatus.BUSY:
                        dictUpdatedRoomStatus.Add(rooms, "BUSY");
                        break;
                    case RoomStatus.TENTATIVE:
                        dictUpdatedRoomStatus.Add(rooms, "TENTATIVE");
                        break;
                    case RoomStatus.OUT_OF_OFFICE:
                        dictUpdatedRoomStatus.Add(rooms, "OUT OF OFFICE");
                        break;
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFindRoomCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // show animated image
                this.pictureBoxWait.Image = Properties.Resources.Error;
                this.lblInformation.Text = "Processing Error";
            }
            else
            {
                // show animated image
                this.pictureBoxWait.Image = Properties.Resources.Information;
                this.lblInformation.Text = "Operation complete";

                /*
                * Update the grid view
                */
                UpdateMeetingRoomStatus();
                btnReset.Enabled = true;
                btnFindRoom.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyMail(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            /*
             * TODO: Copies the mail address to the clipboard
             */
            foreach (DataGridViewRow row in dgvMeetingRoomStatus.Rows)
            {
                if (((DataGridViewCheckBoxCell)row.Cells[0]).Value != null && ((DataGridViewCheckBoxCell)row.Cells[0]).Value.ToString() == "true")
                {
                    sb.Append(((DataGridViewTextBoxCell)row.Cells[2]).Value.ToString());
                    sb.Append(System.Environment.NewLine);
                }
            }

            if (sb != null)
            {
                Clipboard.SetText(sb.ToString());
            }
        }


        #region Commented Code

        ////private void Form1_Load(object sender, EventArgs e)
        ////{
        ////    AddHeaderCheckbox();
        ////    dgvMeetingRoomStatus.CellPainting += new DataGridViewCellPaintingEventHandler(dgvMeetingRoomStatus_CellPainting);
        ////    dgvMeetingRoomStatus.CellValueChanged += new DataGridViewCellEventHandler(dgvMeetingRoomStatus_CellValueChanged);
        ////}

        /////// <summary>
        /////// Cell painting event
        /////// </summary>
        /////// <param name="sender"></param>
        /////// <param name="e"></param>
        ////void dgvMeetingRoomStatus_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        ////{
        ////    if (e.RowIndex == -1 && e.ColumnIndex == 0)
        ////        ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        ////}

        ////private void dgvMeetingRoomStatus_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        ////{
        ////    if (!IsHeaderCheckBoxClicked)
        ////        RowCheckBoxClick((DataGridViewCheckBoxCell)dgvMeetingRoomStatus[e.ColumnIndex, e.RowIndex]);
        ////}

        ////private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        ////{
        ////    if (RCheckBox != null)
        ////    {
        ////        ////Modifiy Counter;            
        ////        //if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
        ////        //    TotalCheckedCheckBoxes++;
        ////        //else if (TotalCheckedCheckBoxes > 0)
        ////        //    TotalCheckedCheckBoxes--;

        ////        ////Change state of the header CheckBox.
        ////        //if (TotalCheckedCheckBoxes < TotalCheckBoxes)
        ////        //    HeaderCheckBox.Checked = false;
        ////        //else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
        ////        //    HeaderCheckBox.Checked = true;
        ////        if (RCheckBox.Value == RCheckBox.TrueValue)
        ////        {
        ////            RCheckBox.Value = RCheckBox.FalseValue;
        ////        }
        ////        else
        ////        {
        ////            RCheckBox.Value = RCheckBox.TrueValue;
        ////            //dgvMeetingRoomStatus.Rows[e.RowIndex].Selected = true;
        ////        }
        ////    }

        ////    //DataGridViewRow selectedRow = dgvMeetingRoomStatus.Rows[e.RowIndex];
        ////    //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)selectedRow.Cells[0];
            
        ////}

        ////private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        ////{
        ////    //Get the column header cell bounds
        ////    Rectangle oRectangle = this.dgvMeetingRoomStatus.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

        ////    Point oPoint = new Point();

        ////    oPoint.X = oRectangle.Location.X + (oRectangle.Width - chkBoxSelectAllHeader.Width) / 2 + 1;
        ////    oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - chkBoxSelectAllHeader.Height) / 2 + 1;

        ////    //Change the location of the CheckBox to make it stay on the header
        ////    chkBoxSelectAllHeader.Location = oPoint;
        ////}

        ////private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        ////{
        ////    HeaderCheckBoxClick((CheckBox)sender);
        ////}

        ////private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        ////{
        ////    if (e.KeyCode == Keys.Space)
        ////        HeaderCheckBoxClick((CheckBox)sender);
        ////}

        ////private void HeaderCheckBoxClick(CheckBox HCheckBox)
        ////{
        ////    IsHeaderCheckBoxClicked = true;

        ////    foreach (DataGridViewRow Row in dgvMeetingRoomStatus.Rows)
        ////    {
        ////        ((DataGridViewCheckBoxCell)Row.Cells["colSelect"]).Value = HCheckBox.Checked;
        ////        if (HCheckBox.Checked)
        ////        {
        ////            Row.Selected = true;
        ////        }
        ////    }

        ////    dgvMeetingRoomStatus.RefreshEdit();

        ////    IsHeaderCheckBoxClicked = false;
        ////}
        /////// <summary>
        /////// 
        /////// </summary>
        ////private void AddHeaderCheckbox()
        ////{
        ////    chkBoxSelectAllHeader = new CheckBox();
        ////    chkBoxSelectAllHeader.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        ////    chkBoxSelectAllHeader.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
        ////    chkBoxSelectAllHeader.Size = new Size(15, 15);

        ////    //Add the CheckBox into the DataGridView
        ////    this.dgvMeetingRoomStatus.Controls.Add(chkBoxSelectAllHeader);
        ////}
        #endregion
    }

    /// <summary>
    /// Represents a room 
    /// </summary>
    public class RoomDetails 
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }

    /// <summary>
    /// Represents room status
    /// olBusy               -   2   -   The user is busy.
    /// olFree               -   0   -   The user is available.
    /// olOutOfOffice        -   3   -   The user is out of office.
    /// olTentative          -   1   -   The user has a tentative appointment scheduled.
    /// olWorkingElsewhere   -   4   -   The user is working in a location away from the office.
    /// </summary>
    ////public class RoomStatus
    ////{
    ////    public string Name { get; set; }
    ////    public string Mail { get; set; }
    ////    public string Status { get; set; }
    ////}
    public enum RoomStatus
    {
        FREE            = 0,
        TENTATIVE       = 1,
        BUSY            = 2,
        OUT_OF_OFFICE   = 3,
        AWAY            = 4
    }
}
