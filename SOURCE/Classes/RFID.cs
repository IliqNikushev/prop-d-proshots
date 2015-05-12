using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class RFID : IDisposable
    {
        private Phidgets.RFID reader;
        public bool IsAttached { get { return reader.Attached; } }
        public event Action<Phidgets.RFID> OnAttach = (x) => { };
        public event Action<Phidgets.RFID> OnDetach = (x) => { };
        public event Action<string> OnDetect = (x) => { };
        public event Action<string> OnDetectEnd = (x) => { };
        public event Action<Phidgets.Events.ErrorEventArgs> OnError = (x) => { };

        public void ToggleAntena() { if (this.IsAttached) reader.Antenna = !reader.Antenna; }
        public void ToggleLED() { if (this.IsAttached) reader.LED = !reader.LED; }

        public string Type { get { return reader.Type; } }

        public int Version { get { return reader.Version; } }
        public int SerialNumber { get { return reader.SerialNumber; } }
        public string Name { get { return reader.Name; } }
        public bool LEDIsActive { get { return reader.LED; } }
        public string Label { get { return reader.Label; } }
        public Phidgets.Phidget.PhidgetID ID { get { return reader.ID; } }
        public string LastTag { get { return reader.LastTag; } }
        public bool AntennaIsActive { get { return reader.Antenna; } }
        public string Address { get { return reader.Address; } }

        public RFID()
        {
            reader = new Phidgets.RFID();

            this.reader.Attach += reader_Attach;
            this.reader.Detach += reader_Detach;
            this.reader.Tag += reader_Tag;
            this.reader.TagLost += reader_TagLost;
            this.reader.Error += reader_Error;

            reader.open(-1);
            this.OnError = (x) => this.Dispose();

            this.OnAttach += (x) => Activate();
            this.OnDetach += (x) => DeActivate();
        }

        private void Activate()
        {
            if (!LEDIsActive) ToggleLED();
            if (!AntennaIsActive) ToggleAntena();
        }

        private void DeActivate()
        {
            if (LEDIsActive) ToggleLED();
            if (AntennaIsActive) ToggleAntena();
        }

        void reader_Attach(object sender, Phidgets.Events.AttachEventArgs e)
        {
            OnAttach((Phidgets.RFID)sender);
        }

        void reader_Detach(object sender, Phidgets.Events.DetachEventArgs e)
        {
            OnDetach((Phidgets.RFID)sender);
        }

        void reader_Tag(object sender, Phidgets.Events.TagEventArgs e)
        {
            OnDetect(e.Tag);
        }

        void reader_TagLost(object sender, Phidgets.Events.TagEventArgs e)
        {
            OnDetectEnd(e.Tag);
        }

        void reader_Error(object sender, Phidgets.Events.ErrorEventArgs e)
        {
            OnError(e);
        }

        public void Dispose()
        {
            this.reader.Attach -= reader_Attach;
            this.reader.Detach -= reader_Detach;
            this.reader.Tag -= reader_Tag;
            this.reader.TagLost -= reader_TagLost;
            this.reader.Error -= reader_Error;
            DeActivate();

            this.reader.close();
        }
    }
}
