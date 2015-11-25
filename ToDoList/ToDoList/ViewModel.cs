using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ToDoList
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Schedule schedule;

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

        private string _newItem;
        public string newItem
        {
            get { return _newItem; }
            set { _newItem = value; }
        }
        

        public ViewModel()
        {
            newList = new ObservableCollection<string>();
            schedule = new Schedule();
        }

        private ObservableCollection<string> _newList;
        public ObservableCollection<string> newList
        {
            get { return _newList; }
            set
            {
                _newList = value;
                OnPropertyChanged("newList");

            }
        }

        public void AddItem(string text)
        {
            if (text == string.Empty)
            {
                MessageBox.Show("Enter a message");
            }
            else
            {
                schedule.list.Add(text);

            }
        }

        public void EditItem(string text)
        {
            if (text == string.Empty)
            {
                MessageBox.Show("Enter an Item");
            }
            else
            {
                try
                {
                    int textId = schedule.list.IndexOf(text);
                    schedule.list[textId] = newItem;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        public void MarkItem(string text)
        {
            try
            {
                int textId = schedule.list.IndexOf(text);
                schedule.list[textId] = text + "\t\t\t" + "completed";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void RemoveItem(string text)
        {
            if (text == string.Empty)
            {
                MessageBox.Show("Enter a message");
            }
            else
            {
                schedule.list.Remove(Convert.ToString(text));
            }
        }

        public void ViewItems()
        {
            newList = schedule.list;
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

        private ICommand _removeitemCommand;
        public ICommand RemoveitemCommand
        {
            get
            {
                if (_removeitemCommand == null)
                {
                    _removeitemCommand = new Command<string>(RemoveItem, CanRemoveItems);
                }

                return _removeitemCommand;
            }
            set { _removeitemCommand = value; }
        }

        private ICommand _markitemCommand;
        public ICommand MarkitemCommand
        {
            get
            {
                if (_markitemCommand == null)
                {
                    _markitemCommand = new Command<string>(MarkItem, CanMarkItems);
                }

                return _markitemCommand;
            }
            set { _markitemCommand = value; }
        }


        private ICommand _editItemsCommand;
        public ICommand EditItemsCommand
        {
            get
            {
                if (_editItemsCommand == null)
                {
                    _editItemsCommand = new Command<string>(EditItem, CanEditItems);
                }

                return _editItemsCommand;
            }
            set { _editItemsCommand = value; }
        }
        public bool CanViewItems()
        {
            return true;
        }

        public bool CanAddItem(string item)
        {
            return true;
        }

        public bool CanRemoveItems(string item)
        {
            return true;
        }

        public bool CanMarkItems(string item)
        {
            return true;
        }

        public bool CanEditItems(string item)
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
