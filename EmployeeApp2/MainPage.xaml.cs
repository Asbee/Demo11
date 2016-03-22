using System;
using EmployeeApp2.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EmployeeApp2
{
    public sealed partial class MainPage : Page
    {
        // employee image model
        public EmployeeImageViewModel ImageViewModel { get; set; }
        // employees model
        public EmployeeViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            // initialize view models
            this.ImageViewModel = new EmployeeImageViewModel();
            this.ViewModel = new EmployeeViewModel();
        }

        // New-Button control is clicked
        private void NewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // add a new employee
            EmployeeImage employeeImage = (EmployeeImage)ImageComboBox.SelectedValue;
            ViewModel.AddEmployee(FirstnameTextBox.Text, LastnameTextBox.Text, JobTitleTextBox.Text, employeeImage);

            // empty UI fields
            FirstnameTextBox.Text = "";
            LastnameTextBox.Text = "";
            JobTitleTextBox.Text = "";
            ImageComboBox.SelectedIndex = -1;

            // select firstname
            FirstnameTextBox.Focus(FocusState.Programmatic);
        }
        
private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)EmployeesGridView.SelectedItem;
            // Delete
            ViewModel.RemoveEmployee(employee);
        }

        private void ModifyEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
        
                // get selected employee from GridView
                Employee employee = (Employee)EmployeesGridView.SelectedItem;
                // update selected employee's data from form
                employee.Firstname = FirstnameTextBox.Text;
                employee.Lastname = LastnameTextBox.Text;
                employee.JobTitle = JobTitleTextBox.Text;
                EmployeeImage employeeImage = (EmployeeImage)ImageComboBox.SelectedItem;
                employee.Image = employeeImage;
            
        }
    }
}
