using FluToDo.Models.Entities;
using FluToDo.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.ViewModels
{
    public class TodoItemViewModel : ObservableObject
    {
        public TodoItemViewModel(TodoItem item)
        {
            this.Name = item.Name;
            this.IsComplete = item.IsComplete;
            this.IsBusy = false;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private bool isComplete = false;
        public bool IsComplete
        {
            get { return isComplete; }
            set
            {
                IsCompleteAndUpdate = IsBusy == true ? false : value;
                SetProperty(ref isComplete, value);
            }
        }

        /// <summary>
        /// Allows to show a progress indicator if the net request is taking too long
        /// </summary>
        private bool isCompleteAndUpdate = false;
        public bool IsCompleteAndUpdate
        {
            get { return isCompleteAndUpdate; }
            set { SetProperty(ref isCompleteAndUpdate, value); }
        }

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                IsCompleteAndUpdate = value == true ? false: IsComplete;
                SetProperty(ref isBusy, value);
            }
        }


    }
}
