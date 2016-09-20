using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using Dajbych.Demo6.Models;
using Dajbych.Demo6.Commands;

namespace Dajbych.Demo6.ViewModels {
    public class WorkspaceViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public WorkspaceViewModel() {
            using (var db = DemoDb.Connection) {
                Machines = db.Machines.ToList();
            }
            Switch = new Command<Machine>(ChangeMachine);
        }

        public ICommand Switch { get; private set; }

        public IList<Machine> Machines { get; private set; }

        private void ChangeMachine(Machine machine) {
            Selected = machine;
        }

        private Machine selected;
        public Machine Selected {
            get {
                return selected;
            }
            private set {
                selected = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
            }
        }

    }
}
