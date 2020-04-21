using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    public class ViewModel
    {
        #region Fields

        private ObservableCollection<ToDoItem> toDoList;

        #endregion

        #region Constructor

        public ViewModel()
        {
            this.GenerateSource();
        }
        #endregion

        #region Property

        public ObservableCollection<ToDoItem> ToDoList
        {
            get { return toDoList;  }
            set { this.toDoList = value; }
        }
       #endregion

        #region Method

        public void GenerateSource()
        {
            ToDoListRepository todoRepository = new ToDoListRepository();
            toDoList = todoRepository.GetToDoList();
        }
        #endregion
    }
}
