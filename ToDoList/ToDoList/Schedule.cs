using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
   public class Schedule
    {
        private ObservableCollection<string> _list;
        public ObservableCollection<string> list
        {
            get { return _list; }
            set { _list = value; }
        }

        public Schedule()
        {
            list = new ObservableCollection<string>();
            list.Add("Meeting Lunch");
            list.Add("Interview");
            list.Add("Yoga");
        }
      
    }
}
