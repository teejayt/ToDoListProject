using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoList
{
    public class ViewModel : INotifyPropertyChanged
    {

        private string _text;
        public string text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("text");

            }
        }

        public ViewModel()
        {
            newList = new ObservableCollection<string>();
        }

        private ObservableCollection<string> _newList;
        public ObservableCollection<string> newList
        {
            get { return _newList; }
            set { _newList = value;
            OnPropertyChanged("newList");
            
            }
        }

        public void AddItem(string text)
        {
            newList.Add(text);
            //  return newList;
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

        public void ViewItems()
        {
         //  newList = //Call method to get items here 
        }

        private ICommand _viewItemsCommand;
        public ICommand viewItemsCommand
        {
            get
            {
                if (_viewItemsCommand == null)
                {
                    _viewItemsCommand = new Command(ViewItems, CanViewItems);
                }

                return _viewItemsCommand;
            }
            set { _viewItemsCommand = value; }
        }

        private ICommand _additemCommand;
        public ICommand additemCommand
        {
            get
            {
                if (_additemCommand == null)
                {
                    _additemCommand = new Command<string>(AddItem, CanAddItem);
                }

                return _additemCommand;
            }
            set { _additemCommand = value; }
        }

        public bool CanViewItems()
        {
            return true;
        }

        public bool CanAddItem(string item)
        {
            return true;
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
