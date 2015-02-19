using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for PnlReports.xaml
    /// </summary>
    public partial class PnlReports : UserControl
    {
        DBConnectionReports reportCon;
        DBConnectionDriver driverCon;
        DBConnectionEvents eventCon;
        public PnlReports()
        {
            InitializeComponent();
            reportCon = new DBConnectionReports();
            driverCon = new DBConnectionDriver();
            eventCon = new DBConnectionEvents();
        }

        private void selectDriver(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                DriverDetailsBean SelectedDriver = (DriverDetailsBean)e.AddedItems[0];
                this.Team_ID.Text = SelectedDriver.Team_id;
                this.Name_txt.Text = SelectedDriver.Name;
                this.Eid_txt.Text = SelectedDriver.Email;
                this.Contact_txt.Text = SelectedDriver.Contact_no;
                this.Address_txt.Text = SelectedDriver.Address;
                this.Gender_txt.Text = SelectedDriver.Gender;
                this.Birthday_txt.Text = SelectedDriver.Birthdate;
                this.age_txt.Text = SelectedDriver.Age;
                this.Vehicle_txt.Text = SelectedDriver.Vehicle_model;
                this.Plate_txt.Text = SelectedDriver.Plate_no;
                this.License_txt.Text = SelectedDriver.License_no;

                tblRacerReports.ItemsSource = reportCon.getDriverRacingDetails(SelectedDriver.Driver_Id);
                tblRacerReports.Items.Refresh();
            }

        }

        public void setDriverList()
        {
            Driver_List.ItemsSource = null;
            Driver_List.ItemsSource = driverCon.GetAllList();

            EventList.ItemsSource = null;
            EventList.ItemsSource = eventCon.selectRaceSession("%%");
        }

        private void selectEvent(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                RaceSession selectedSession = (RaceSession)e.AddedItems[0];
                this.tfEventName.Text = selectedSession.EventName;
                this.tfClassName.Text = selectedSession.ClassName;
                this.tfSessionName.Text = selectedSession.Name;
                this.tfRaceType.Text = selectedSession.Type;
                this.tfDate.Text = selectedSession.Date+" "+selectedSession.SchedTime;
                this.tfLapNumber.Text = Convert.ToString(selectedSession.LapNumber);
                this.tfPlace.Text = selectedSession.Place;
                this.tfDescription.Text = selectedSession.Description;
                this.tfDistance.Text = Convert.ToString(selectedSession.Distance);

                tblEventRaceReports.ItemsSource = reportCon.getEventRacingDetails(selectedSession.SessionId);
                tblEventRaceReports.Items.Refresh();
            }
        }


        //Al
        private void PrintUserReport(object sender, RoutedEventArgs e)
        {

            exportExcel(tblRacerReports, generateDiverDetails(), "UR");
        }

        //Al
        private void PrintRaceReport(object sender, RoutedEventArgs e)
        {

            exportExcel(tblEventRaceReports, generateRaceDetails(),"RR");
        }

        private void ExportUserDocument(object sender, RoutedEventArgs e)
        {
            //reateRacerDocument();
        }

        private void ExportEventDocument(object sender, RoutedEventArgs e)
        {
            CreateSessionDocument();
        }


        //Create document method
        private void CreateSessionDocument()
        {
            try
            {
                //Create an instance for word app
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //Set animation status for word application
                //winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.
                winword.Visible = false;

                //Create a missing variable for missing value
                object missing = System.Reflection.Missing.Value;

                //Create a new document
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Add header into the document
                /*foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Header text goes here";
                }

                //Add the footers into the document
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Footer text goes here";
                }
                 
                // adding line
                //document.Shapes.AddLine(0,0,500,0);
                Microsoft.Office.Interop.Word.InlineShape line = document.Paragraphs.Last.Range.InlineShapes.AddHorizontalLineStandard(ref missing);
                line.Height = 2;
                line.Range.SetRange(-900, 700);
                line.Fill.Solid();
                line.HorizontalLineFormat.NoShade = true;
                line.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                line.HorizontalLineFormat.PercentWidth = 100;
                line.HorizontalLineFormat.Alignment = Microsoft.Office.Interop.Word.WdHorizontalLineAlignment.wdHorizontalLineAlignCenter;

                 */

                //adding text to document
                document.Content.Paragraphs.SpaceBefore = 0f;
                document.Content.Paragraphs.SpaceAfter = 0f;
                document.Content.SetRange(0, 0);
                document.PageSetup.LeftMargin = 40;
                document.PageSetup.RightMargin = 40;
                document.PageSetup.TopMargin = 40;
                document.PageSetup.BottomMargin = 40;
                //document.Content.Text = Environment.NewLine;
                //object styleHeading1 = "Header 1";
                //document.Content.set_Style(ref styleHeading1);

                // add Header
                Microsoft.Office.Interop.Word.Paragraph eventName = document.Content.Paragraphs.Add(ref missing);
                eventName.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tfEventName.Text);
                eventName.SpaceAfter = 3f;
                eventName.Range.Bold = 1;
                eventName.Range.InsertParagraphAfter();


                //Add paragraph with Heading 1 style
                Microsoft.Office.Interop.Word.Paragraph className = document.Content.Paragraphs.Add(ref missing);
                //object styleHeading1 = "No Spacing";
                //para1.Range.set_Style(ref styleHeading1);
                className.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tfClassName.Text + "\t\t\t\t" + tfPlace.Text + "   " + tfDistance.Text) + " m";
                className.SpaceAfter = 0f;
                className.Range.Bold = 0;
                className.Range.InsertParagraphAfter();

                //Add paragraph with Heading 2 style
                Microsoft.Office.Interop.Word.Paragraph raceType = document.Content.Paragraphs.Add(ref missing);
                //object styleHeading2 = "No Spacing";
                //para2.Range.set_Style(ref styleHeading2);
                raceType.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tfRaceType.Text) + "\t\t\t\t" + tfDate.Text;
                raceType.Range.InsertParagraphAfter();

                //Add paragraph with Heading 3 style
                Microsoft.Office.Interop.Word.Paragraph raceDesc = document.Content.Paragraphs.Add(ref missing);
                //object styleHeading3 = "No Spacing";
                //para3.Range.set_Style(ref styleHeading3);
                raceDesc.Range.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tfDescription.Text + " ("+tfLapNumber.Text+" Laps)"+Environment.NewLine);
                raceDesc.Range.InsertParagraphAfter();

                //Create a 5X5 table and insert some dummy record
                Microsoft.Office.Interop.Word.Paragraph table = document.Content.Paragraphs.Add(ref missing);
                Microsoft.Office.Interop.Word.Table firstTable = document.Tables.Add(table.Range, 5, 5, ref missing, ref missing);

                firstTable.Borders.Enable = 0;
                foreach (Microsoft.Office.Interop.Word.Row row in firstTable.Rows)
                {
                    foreach (Microsoft.Office.Interop.Word.Cell cell in row.Cells)
                    {
                        //Header row
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
                            cell.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray25;
                            //Center alignment for the Header cells
                            cell.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        }
                        //Data row
                        else
                        {
                            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                    }
                }


                // adding picture
                Microsoft.Office.Interop.Word.Shape myShape = document.Shapes.AddPicture(@"C:\RaceSystem Documents\RaceHeader.jpg", false, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                myShape.WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapBehind;
                myShape.RelativeHorizontalPosition = Microsoft.Office.Interop.Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionPage;
                myShape.RelativeVerticalPosition = Microsoft.Office.Interop.Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionOuterMarginArea;
                myShape.Top = 30;
                myShape.Left = 30;
                myShape.Width = 550;
                myShape.Height = 80;
                /*myShape.ScaleHeight((float)0.5, Microsoft.Office.MsoTriState.msoTrue);
                myShape.ScaleWidth((float)0.5, Office.MsoTriState.msoTrue);
                myShape.LockAspectRatio = Office.MsoTriState.msoTrue;
                myShape.WrapFormat.Type = Word.WdWrapType.wdWrapBehind;
                myShape.ZOrder(Office.MsoZOrderCmd.msoSendBackward); */

                //Save the document
                object filename = @"C:\\RaceSystem Documents\\temp1.docx";
                document.SaveAs(ref filename);
                //document.Close(true, "C:\\RaceSystem Documents\\temp1.docx", ref missing);
                document.Close(ref missing, ref missing, ref missing);

                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
                MessageBox.Show("Document created successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable DataGridtoDataTable(System.Windows.Controls.DataGrid dg)
        {

            DataTable dt = new DataTable();
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();

         
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            if (result != null)
            {
                string[] Lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                string[] Fields;
                Fields = Lines[0].Split(new char[] { ',' });
                int Cols = Fields.GetLength(0);


                for (int i = 0; i < Cols; i++)
                    dt.Columns.Add(Fields[i].ToUpper(), typeof(string));
                DataRow Row;
                for (int i = 1; i < Lines.GetLength(0) - 1; i++)
                {
                    Fields = Lines[i].Split(new char[] { ',' });
                    Row = dt.NewRow();
                    for (int f = 0; f < Cols; f++)
                    {
                        Row[f] = Fields[f];
                    }
                    dt.Rows.Add(Row);
                }
            }
            return dt;

        }

        public DataTable DataGridToDataTable()
        {
            List<DriversRacingReportBean> list = (List<DriversRacingReportBean>)tblRacerReports.ItemsSource;
            DataTable dt = new DataTable();
            dt.Columns.Add("RFID Tag", typeof(string));
            dt.Columns.Add("Lap", typeof(string));
            dt.Columns.Add("Pos", typeof(string));
            dt.Columns.Add("Race Event", typeof(string));
            dt.Columns.Add("Class Name", typeof(string));
            dt.Columns.Add("Session Name", typeof(string));
            dt.Columns.Add("Lap Time (s)", typeof(string));
            dt.Columns.Add("Best Lap Time (s)", typeof(string));
            dt.Columns.Add("Lap Speed(m/s)", typeof(string));
            dt.Columns.Add("Best Lap Speed(m/s)", typeof(string));

            for (int i = 0; i < list.Count; i++)
            {
                DriversRacingReportBean bean = (DriversRacingReportBean)list.ElementAt(i);
                dt.Rows.Add(bean.RFIDTag, bean.LapNumber, bean.Position, bean.EventName, bean.ClassName, bean.SessionName,
                bean.LapTime, bean.BestLapTime, bean.LapSpeed, bean.BestLapSpeed);
            }

            return dt;
        }

        private string[,] generateDiverDetails()
        {
            //For driver's details
            string[,] driver = new string[5, 6];
            driver[0, 0] = "Name";
            driver[0, 1] = Name_txt.Text;
            driver[0, 2] = "Vehicle Model";
            driver[0, 3] = Vehicle_txt.Text;
            driver[0, 4] = "Team Id";
            driver[0, 5] = Team_ID.Text;

            driver[1, 0] = "Email Id";
            driver[1, 1] = Eid_txt.Text;
            driver[1, 2] = "Plate No.";
            driver[1, 3] = Plate_txt.Text;
            driver[1, 4] = "";
            driver[1, 5] = "";

            driver[2, 0] = "Contact No.";
            driver[2, 1] = Contact_txt.Text;
            driver[2, 2] = "License No.";
            driver[2, 3] = License_txt.Text;
            driver[2, 4] = "";
            driver[2, 5] = "";

            driver[3, 0] = "Address";
            driver[3, 1] = Address_txt.Text;
            driver[3, 2] = "Age";
            driver[3, 3] = age_txt.Text;
            driver[3, 4] = "";
            driver[3, 5] = "";

            driver[4, 0] = "Birth Day";
            driver[4, 1] = Birthday_txt.Text;
            driver[4, 2] = "Gender";
            driver[4, 3] = Gender_txt.Text;
            driver[4, 4] = "";
            driver[4, 5] = "";

            return driver;
        }

        private string[,] generateRaceDetails()
        {
            //For driver's details
            string[,] raceDetails = new string[5, 6];
            raceDetails[0, 0] = "Event Name";
            raceDetails[0, 1] = tfEventName.Text;
            raceDetails[0, 2] = "Race Type";
            raceDetails[0, 3] = tfRaceType.Text;
            raceDetails[0, 4] = "Distance(m)";
            raceDetails[0, 5] = tfDistance.Text;

            raceDetails[1, 0] = "Class Name";
            raceDetails[1, 1] = tfClassName.Text;
            raceDetails[1, 2] = "Date";
            raceDetails[1, 3] = tfDate.Text;
            raceDetails[1, 4] = "";
            raceDetails[1, 5] = "";

            raceDetails[2, 0] = "Session Name";
            raceDetails[2, 1] = tfSessionName.Text;
            raceDetails[2, 2] = "Lap Number";
            raceDetails[2, 3] = tfLapNumber.Text;
            raceDetails[2, 4] = "";
            raceDetails[2, 5] = "";

            raceDetails[3, 0] = "Place";
            raceDetails[3, 1] = tfPlace.Text;
            raceDetails[3, 2] = "";
            raceDetails[3, 3] = "";
            raceDetails[3, 4] = "";
            raceDetails[3, 5] = "";

            raceDetails[4, 0] = "Description";
            raceDetails[4, 1] = tfDescription.Text;
            raceDetails[4, 2] = "";
            raceDetails[4, 3] = "";
            raceDetails[4, 4] = "";
            raceDetails[4, 5] = "";

            return raceDetails;
        }


        public void exportExcel(DataGrid dg, string[,] details, string typeOfReport)
        {

            DataTable dt = DataGridtoDataTable(dg);


            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel._Application app = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            try
            {
                Console.WriteLine("1");
                app = new Excel.Application();
                wb = app.Workbooks.Add(misValue);
                ws = app.ActiveWorkbook.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                Microsoft.Office.Interop.Excel.Range range;
                Console.WriteLine("2");
                range = ws.get_Range("A8", misValue);
                Console.WriteLine("3" + dt.Rows.Count + "  " + dt.Columns.Count);
                range = range.get_Resize(dt.Rows.Count, dt.Columns.Count);
                Console.WriteLine("4");


                Microsoft.Office.Interop.Excel.Range columnNameRange;
                columnNameRange = ws.get_Range("A7", misValue);
                columnNameRange = columnNameRange.get_Resize(1, dt.Columns.Count);

                Microsoft.Office.Interop.Excel.Range driverRange;
                driverRange = ws.get_Range("A1", misValue);
                driverRange = driverRange.get_Resize(5, 6);



                //For driver's details
                //string[,] driver = generateDiverDetails();
                driverRange.set_Value(misValue, details);
                driverRange.Columns.AutoFit();



                string[] columNames = new string[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    columNames[i] = dt.Columns[i].ColumnName;
                columnNameRange.set_Value(misValue, columNames);


                string[,] arr = new string[dt.Rows.Count, dt.Columns.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        arr[i, j] = dt.Rows[i][j].ToString();
                    }
                }
                range.set_Value(misValue, arr);

                ws.Cells.Columns.AutoFit();
                string name = typeOfReport + details[0, 1] + "_"+DateTime.Now.ToString("yyyyMMddHHmmss");
                wb.Close(true, "C:\\RaceSystem Documents\\" + name + ".xlsx", misValue);

                MessageBox.Show("Export Successful \n Please see C:\\RaceSystem Documents\\" + name + ".xlsx", "Export", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message.ToString());
                MessageBox.Show("Export Failed", "Export", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            finally
            {
                // make sure the office process quit after certain operations done.
                if (app != null)
                {
                    app.UserControl = false;
                    app.Quit();
                    app = null;
                }
            }
        }



    }










    public class DriverProfileBean
    {
        private DriverDetailsBean driverDetails;
        private List<DriversRacingReportBean> racingDetails;


        public DriverProfileBean()
        {

        }

        public DriverProfileBean(DriverDetailsBean driverDetails, List<DriversRacingReportBean> racingDetails)
        {
            this.driverDetails = driverDetails;
            this.racingDetails = racingDetails;
        }

        public DriverDetailsBean DriverDetails
        {
            get { return this.driverDetails; }
            set
            {
                this.driverDetails = value;
            }
        }

        public List<DriversRacingReportBean> RacingDetailsList
        {
            get
            {
                return this.racingDetails;
            }
            set
            {
                this.racingDetails = value;

            }
        }
    }
}
