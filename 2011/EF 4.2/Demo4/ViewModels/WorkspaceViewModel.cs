using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Dajbych.Demo4.Models;
using Dajbych.Demo4.Commands;
using System.Windows.Input;
using System.Windows;
using System.Data.Entity;

namespace Dajbych.Demo4.ViewModels {
    public class WorkspaceViewModel {

        public WorkspaceViewModel() {
            using (var db = DemoDb.Connection) {
                Aircrafts = new ObservableCollection<Aircraft>(db.Aircrafts.Include(a => a.Images));
            }
        }

        public ObservableCollection<Aircraft> Aircrafts { get; private set; }

    }
}