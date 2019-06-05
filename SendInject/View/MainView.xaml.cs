using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SendInject.ViewModel;
using SendInject.Model;
using System.Reactive.Linq;

namespace SendInject.View
{
    public partial class MainView
    {

        public MainView()
        {
            InitializeComponent();
        }

        public void ProcessViewFilter(object sender, FilterEventArgs e)
        {
            ProcessData processData = (ProcessData) e.Item;
            string filterStr = this.FilterInput.Text;

            if (filterStr == null)
                filterStr = "";

            e.Accepted = processData.ProcessName.Contains(filterStr);
        }

        private void FilterProcessList_Click(object sender, RoutedEventArgs e)
        {
            ((CollectionViewSource)this.Resources["ProcessViewSource"]).View.Refresh();
        }

        private dynamic VM
        {
            get { return this.DataContext; }
        }
    }

}
