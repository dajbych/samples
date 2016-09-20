using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dajbych.Demo5.ViewModels {
    public abstract class AircraftViewModel {

        public string Name { get; set; }

        public abstract string TypeName { get; }

    }

    public class AirbusViewModel : AircraftViewModel {

        public override string TypeName {
            get { return "Airbus"; }
        }

    }

    public class BoeingViewModel : AircraftViewModel {

        public override string TypeName {
            get { return "Boeing"; }
        }

    }
}