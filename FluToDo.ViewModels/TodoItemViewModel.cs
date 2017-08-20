using FluToDo.Models.Entities;
using FluToDo.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.ViewModels
{
    public class TodoItemViewModel:ObservableObject
    {
        public  TodoItemViewModel(TodoItem item)
        {
            this.Name = item.Name;
            this.IsComplete = item.IsComplete;
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
            set { SetProperty(ref isComplete, value); }
        }

    }
}
