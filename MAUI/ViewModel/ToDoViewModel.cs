using System.Collections.ObjectModel;

namespace MAUI.ViewModel
{
    public class ToDoViewModel : ViewModelBase
    {

        public ToDoViewModel()
        {
            ToDoItems = new ObservableCollection<ToDoItemViewModel>();
        }

        ObservableCollection<ToDoItemViewModel> ToDoItems { get; }
    }
}
