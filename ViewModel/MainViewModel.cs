using BakuBus.Model;
using BakuBus.Services;
using Microsoft.Maps.MapControl.WPF;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Documents;
using System.Windows.Threading;

namespace BakuBus.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ApplicationIdCredentialsProvider Provider { get; set; }
        public ObservableCollection<Bus> Buses { get; set; }

        private BakuBusService _busService;

        public MainViewModel()
        {
            Provider = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["ApiKey"]);
            _busService = new BakuBusService();
            Buses = new ObservableCollection<Bus>(_busService.GetAllBuses());

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();

            //_busService.GetAllBusesByRouteCode(1);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Provider = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["ApiKey"]);
            _busService = new BakuBusService();
            Buses = new ObservableCollection<Bus>(_busService.GetAllBuses());
        }
    }
}
