using DevExpress.Mvvm;
using Mathematical_Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mathematical_Graph.ViewModels
{
    internal class SendEmailWindowViewModel : ViewModelBase
    {
        public string TextEmail { get; set; }
        public ICommand SendEMailCommand { get; set; }
        public ICommand OpenMainCommand { get; set; }

        public SendEmailWindowViewModel()
        {
            SendEMailCommand = new DelegateCommand(()=> Methods.SendEmail(TextEmail));
            OpenMainCommand = new DelegateCommand(Methods.OpenMainWindow);
        }
    }
}
