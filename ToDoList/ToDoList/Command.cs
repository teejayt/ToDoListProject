﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoList
{
    public class Command : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public Command(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute ?? (() => true);
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute();
            }
            catch
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            try
            {
                _execute();
            }
            catch
            {
                Debugger.Break();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public class Command<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public Command(Action<T> execute, Func<T, bool> canexecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canexecute ?? (e => true);
        }

        [DebuggerStepThrough]
        public bool CanExecute(object p)
        {
            try
            {
                var _Value = (T)Convert.ChangeType(p, typeof(T));
                return _canExecute == null ? true : _canExecute(_Value);
            }
            catch { return false; }
        }

        public void Execute(object p)
        {
            if (!CanExecute(p))
                return;
            var _Value = (T)Convert.ChangeType(p, typeof(T));
            _execute(_Value);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public class Command<T,T2> : ICommand
    {
        private readonly Action<T,T2> _execute;
        private readonly Func<T, bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public Command(Action<T,T2> execute, Func<T, bool> canexecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canexecute ?? (e => true);
        }

        [DebuggerStepThrough]
        public bool CanExecute(object p)
        {
            try
            {
                var _Value = (T)Convert.ChangeType(p, typeof(T));
                return _canExecute == null ? true : _canExecute(_Value);
            }
            catch { return false; }
        }

        public void Execute(object p)
        {
            if (!CanExecute(p))
                return;
            var _Value = (T)Convert.ChangeType(p, typeof(T));
            var _Value1 = (T2)Convert.ChangeType(p, typeof(T2));
            
            _execute(_Value,_Value1);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
