﻿using BakuBus.Command;
using BakuBus.Model;
using BakuBus.Services;
using Microsoft.Maps.MapControl.WPF;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;

namespace BakuBus.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ApplicationIdCredentialsProvider Provider { get; set; }
        public ObservableCollection<Bus> Buses { get; set; }
        public List<string> BusesRouteCodes { get; set; }
        public ICommand SearchCommand { get; set; }

        private BakuBusService _busService;

        private string BusNo;

        public MainViewModel()
        {
            Provider = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["ApiKey"]);
            _busService = new BakuBusService();
            Buses = new ObservableCollection<Bus>(_busService.GetAllBuses());

            SearchCommand = new RelayCommand(SearchCommandExecute);

            List<string> buses = new List<string>();
            buses.Add("General list");
            foreach (var item in Buses)
            {
                buses.Add(item.RouteCode);
            }
            BusesRouteCodes = buses.Distinct().ToList();


            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void SearchCommandExecute(object param)
        {
            BusNo = param as string;
            Buses = new ObservableCollection<Bus>(_busService.GetAllBusesByRouteCode(BusNo));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Provider = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["ApiKey"]);
            _busService = new BakuBusService();

            if (BusNo == null)
            {
                BusNo = "General list";
            }

            Buses = new ObservableCollection<Bus>(_busService.GetAllBusesByRouteCode(BusNo));
        }
    }
}
