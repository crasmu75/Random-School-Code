using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Library_Reader_and_Display
{
    /// <author> H. James de St. Germain</author>
    /// 
    /// <summary>
    ///   Builds a GUI to show DB information
    ///
    /// Warning: some of the events used here need to be modifed, such as the end event, such that the correct data is displayed   
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// The connection string.
        /// </summary>
        public const string connectionString = "server=atr.eng.utah.edu;database=Library_1;uid=cs3500_library;password=hello";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function builds a dataset manually
        /// </summary>
        public void populate_dataset_manually()
        {
            List<Book> dataset = new List<Book>();

            dataset.Add(new Book(1, 1234, false, "Happy", "Jim"));
            dataset.Add(new Book(1, 1234, false, "Thanksgiving", "Erin"));
            dataset.Add(new Book(1, 1234, false, "To", "Joe"));
            dataset.Add(new Book(1, 1234, false, "You", "Dav"));

            this.Book_Display.ItemsSource = dataset;

        }
        
        /// <summary>
        /// Build a dataset and display it using a Database connection
        /// </summary>
        public void populate_dataset_via_db()
        {
            List<Book> dataset = new List<Book>();

            // Connect to the DB
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open a connection
                    conn.Open();

                    // Create a command
                    MySqlCommand command = conn.CreateCommand();
                    // FIXME: incorrect :  command.CommandText = "select * from Books";
                    // FIXME: correct 1 :  command.CommandText = "select * from Titles";
                    // FIXME: correct 2 :  command.CommandText = "select * from Titles NATURAL JOIN Catalog";
                    command.CommandText = "select * from Books";
                    // Execute the command and cycle through the DataReader object
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
// FIXME: incomplete        dataset.Add(new Book(1, (long)(reader["ISBN"]), false, reader["Title"] as String, reader["Author"] as String));
// FIXME: add serial        dataset.Add(new Book(1, (long)(reader["ISBN"]), false, reader["Title"] as String, reader["Author"] as String));
                            dataset.Add(new Book(1, (long)(reader["ISBN"]), false, reader["Title"] as String, reader["Author"] as String));

                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    this.Book_Display.ItemsSource = dataset;

                    foreach (DataGridColumn x in this.Book_Display.Columns)
                    {
                        if (x.Header.ToString() == "ISBN")
                        {
                            x.Visibility = Visibility.Hidden;
                        }

                        if (x.Header.ToString() == "ISBN_string")
                        {
                            x.Header = "ISBN";
                        }

                    }

                    this.Book_Display.CurrentCellChanged += doit;
                }
            }
        }

        private void doit(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("here");
            System.Diagnostics.Debug.WriteLine("finshed editing: " + (this.Book_Display.CurrentItem as Book));
        }

        private EventHandler<EventArgs> doit1()
        {
            System.Diagnostics.Debug.WriteLine("here");
            return null;
        }



        /// <summary>
        ///  Invoke the manual creation of the dataset
        /// </summary>
        /// <param name="sender"> ignored </param>
        /// <param name="e">      ignored </param>
        private void Button_Click_Manual_Creation(object sender, RoutedEventArgs e)
        {
            populate_dataset_manually();
        }
        
        /// <summary>
        ///   Invoke the DB creation of the dataset
        /// </summary>
        /// <param name="sender"> ignored </param>
        /// <param name="e">      ignored </param>
        private void Button_Click_Creation_via_DB(object sender, RoutedEventArgs e)
        {
            populate_dataset_via_db();
        }

        /// <summary>
        ///  called when a cell is modified and focus switches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Book_Display_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("done editing: " + e.Row.Item );
        }

        /// <summary>
        /// Called when a cell is about to be modified
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Book_Display_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("begin editing: " + e.Column.Header + " " + e.Row.Item );
            // Note: alternate access to current item: this.Book_Display.CurrentItem as Book
        }


    }

    /// <summary>
    /// This is just a sample class showing how you might
    /// transform a relational DB implementation of a book into a C# object implementation of a book
    /// </summary>
    class Book
    {
        public int SerialNum   { get; set; }
        public long ISBN       { get; set; }

        public string ISBN_string { get { return ("" + ISBN).Insert(3,"-"); }  }
        public bool CheckedOut { get; set; }
        public string Title    { get; set; }
        public string Author   { get; set; }

        public Book(int serial_num, long isbn, bool checked_out, string title, string author)
        {
            this.SerialNum  = serial_num;
            this.ISBN       = isbn;
            this.CheckedOut = checked_out;
            this.Title      = title;
            this.Author     = author;
        }

        public override string ToString()
        {
            return "Book: " + Title + ", Checked out: " + CheckedOut + ", serial number: " + SerialNum;
        }
    }

}
