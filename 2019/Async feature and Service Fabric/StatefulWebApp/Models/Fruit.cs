using System.Runtime.Serialization;

namespace Dajbych.Models {

    [DataContract]
    public class Fruit : IExtensibleDataObject {

        public Fruit(string name) {
            Name = name;
        }

        [DataMember] public readonly string Name;

        // Forward-Compatible

        private ExtensionDataObject extensionData;

        public virtual ExtensionDataObject ExtensionData {
            get { return extensionData; }
            set { extensionData = value; }
        }

    }
}
