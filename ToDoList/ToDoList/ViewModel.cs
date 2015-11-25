using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
  public  class ViewModel: INotifyPropertyChanged
    {

        private string _text;
        public string text
        {
            get { return _text; }
            set {
                _text = value;
                OnPropertyChanged("text");
            
            }
        }

        public ViewModel()
        {

        }

        private ObservableCollection<string> newList;
      public void AddItem(string text)
      {
          newList.Add(text);
      }

      public void EditItem(string text)
      {

      }

      public void MarkItem(string text)
      {

      }

      public void RemoveItem(string text)
      {
          newList.Remove(text);
      }

      public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged(string propertyName)
      {
          if (PropertyChanged != null)
          {
              PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
      }
    }
}
