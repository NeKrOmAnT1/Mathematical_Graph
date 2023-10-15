using DevExpress.Mvvm;
using Mathematical_Graph.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mathematical_Graph.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public string Acoef { get; set; }
        public string Bcoef { get; set; }
        public string Ccoef { get; set; }
        public string timer { get; set; }
        public ICommand GetGraphCommand { get; set; }
        public ICommand SendEmailTehCommand { get; set; }
        public ComboBoxItem SelectedItem { get; set; }
        public PlotModel GraphModel { get; set; }
        public MainWindowViewModel() 
        {
            Acoef = "0";
            Bcoef = "0";
            Ccoef = "0";
            GetGraphCommand = new DelegateCommand(OnGetGraph);
            SendEmailTehCommand = new DelegateCommand(Methods.OpenSendEmailWindow);
        }
        private void OnGetGraph()
        {
            double a, b, c;
            if (!double.TryParse(Acoef, out a) || !double.TryParse(Bcoef, out b) || !double.TryParse(Ccoef, out c))
            {
                MessageBox.Show("Ошибка");
                return;
            }
            if (SelectedItem == null)
            {
                MessageBox.Show("Не была выбрана формула для построения графика");
                return;
            }
            else
            {
            string selectedGraph = SelectedItem.Tag.ToString();
            PlotModel graphModel = Methods.GenerateGraphModel(a, b, c, selectedGraph);
            GraphModel = graphModel;
            }
        }
    }
    
}
