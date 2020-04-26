using BakuBus.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BakuBus.View
{
    public partial class SearchBusControl : UserControl
    {
        public ObservableCollection<object> vs { get; set; } 
        public SearchBusControl()
        {
            InitializeComponent();
            SearchCommand = new RelayCommand(SearchCommandExecute);
            vs = AddBusList;
            int b = 7;
        }
        public ICommand SearchCommand { get; set; }

        #region ComboBox AddItemList
        public ObservableCollection<object> AddBusList
        {
            get { return (ObservableCollection<object>)GetValue(AddBusListProperty); }
            set { SetValue(AddBusListProperty, value); }
        }

        public static readonly DependencyProperty AddBusListProperty =
            DependencyProperty.Register("AddBusList", typeof(ObservableCollection<object>), typeof(SearchBusControl));

        #endregion

        private void SearchCommandExecute(object param)
        {

        }

    }
}
