using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm1.Models
{
    public class Employee : INotifyPropertyChanged
    {
        #region constructor
        public Employee()
        {

        }
        public Employee(Employee copy)
        {
            this.age = copy.age;
            this.name = copy.name;
            this.id = copy.id;
        }

        //public Employee operator =(Employee copy)
        //{
        //    return new Employee(copy);
        //}
        #endregion

        #region help
        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + age.ToString();
        }

        #endregion


        #region properties
        int id;
        public int Id { get {return id; } set {id =value; OnPropertyChanged("Id"); } }
        string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        int age;
        public int Age { get { return age; } set { age = value; OnPropertyChanged("Age"); } }
        #endregion

        #region property changes
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
