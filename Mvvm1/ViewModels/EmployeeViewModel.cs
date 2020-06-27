using Mvvm1.Commands;
using Mvvm1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm1.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region private
        EmployeeService empService;
        #endregion

        #region property
        ObservableCollection<Employee> empList;
        public ObservableCollection<Employee> EmpList { get { return empList; } set { empList = value; OnPropertyChanged("EmpList"); } }

        Employee currentEmp;
        public Employee CurrentEmp { 
            get{ return currentEmp; } 
            set {
                currentEmp = value; OnPropertyChanged("CurrentEmp"); } 
        }
        string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value; OnPropertyChanged("UserName");
            }
        }
        #endregion

        #region commands
        //Add command.
        RelayCommand addCommand;
        public RelayCommand AddCommand { get {return addCommand;} }
        public void Add()
        {
            empService.Add(currentEmp);
            LoadData();
        }

        // searchCommand
        public RelayCommand SearchCommand { get; set; }

        void SearchEmp()
        {
            var emp = empService.Search(CurrentEmp.Id);
            CurrentEmp = new Employee(emp) ;


        }
        Action Search;

        #endregion


        #region ctor

        public EmployeeViewModel()
        {
            empService = new EmployeeService();
            currentEmp = new Employee();
            LoadData();
            CreateCommands();
            
        }
        #endregion

        #region privatefunctions
        //create commands
        void CreateCommands()
        {
            addCommand = new RelayCommand(Add);
            Search = SearchEmp;
            SearchCommand = new RelayCommand(Search);
        }
        void LoadData()
        {
            EmpList = new ObservableCollection<Employee>( empService.GetAll());
        }

        #endregion



        #region property
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Error { get { return null; } }

        public string this[string propertyName]
        {
            get
            {
                string result = null;

                switch(propertyName)
                {
                    case "CurrentEmp":
                        if(CurrentEmp.Id < 0)
                        {
                            result = "User name can not be null";
                        }

                        break;

                }
                return result;
            }
        }


        #endregion
    }
}
