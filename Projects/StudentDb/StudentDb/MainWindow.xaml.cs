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

namespace StudentDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DisplayAllStudents();
            DisplayContactInfo();
        }

        private void DisplayAllStudents()
        {
            using (CollegeEntities db = new CollegeEntities())
            {
                StringBuilder builder = new StringBuilder();
                foreach (Student s in db.Students)
                {
                    builder.Append(s).Append(Environment.NewLine);
                }
                DisplayTB.Text = builder.ToString();
            }
        }

        private void DisplayContactInfo()
        {
            using (CollegeEntities db = new CollegeEntities())
            {
                StringBuilder builder = new StringBuilder();
                foreach(Student s in db.Students)
                {
                    builder.Append(String.Format("{0,-9}   {1,-9}   {2,-9}  {3,-9}", s.FirstName, 
                        s.LastName, s.PhoneNumber, s.Email)).Append(Environment.NewLine);
                }
                DisplayTB.Text = builder.ToString();
            }
        }
    }
}
