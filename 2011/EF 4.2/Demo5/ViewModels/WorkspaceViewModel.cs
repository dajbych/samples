using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Dajbych.Demo5.ViewModels {
    public class WorkspaceViewModel {

        public WorkspaceViewModel() {
            Aircrafts = new ObservableCollection<AircraftViewModel>();

            Aircrafts.Add(new AirbusViewModel() { Name = "A380" });
            Aircrafts.Add(new AirbusViewModel() { Name = "A340" });
            Aircrafts.Add(new BoeingViewModel() { Name = "B737" });
            Aircrafts.Add(new BoeingViewModel() { Name = "B787" });
        }


        internal static WorkspaceViewModel Instance { get; private set; }

        public ObservableCollection<AircraftViewModel> Aircrafts { get; private set; }
    }
}