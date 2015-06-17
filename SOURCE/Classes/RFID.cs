using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class RFID : IDisposable
    {
        public static bool HasDrivers
        {
            get
            {
                
                try
                {
                    new Phidgets.RFID();
                }
                catch { return false; }
                return true;
            }
        }
        public event Action<Phidgets.RFID> OnAttach = (x) => { };
        public event Action<Phidgets.RFID> OnDetach = (x) => { };
        public event Action<string> OnDetect = (x) => { };
        public event Action<string> OnDetectEnd = (x) => { };
        private event Action<Visitor> onVisitorDetect = (x) => { };
        public event Action<Visitor> OnVisitorDetect
        {
            add
            {
                onVisitorDetect -= value;
                onVisitorDetect += value;
            }
            remove
            {
                onVisitorDetect -= value;
            }
        }
        public event Action<Phidgets.Events.ErrorEventArgs> OnError = (x) => { };

        private Phidgets.RFID reader;
        public bool IsAttached
        {
            get
            {
                if (reader == null)
                    return false;
                return reader.Attached;
            }
        }

        public void ToggleAntena() 
        { 
            if (this.IsAttached)
                reader.Antenna = !reader.Antenna; 
        }

        public void ToggleLED() 
        { 
            if (this.IsAttached)
                reader.LED = !reader.LED; 
        }
        
        public string Type
        {
            get
            {
                if (!this.IsAttached)
                    return "";
                return reader.Type;
            }
        }

        public int Version
        {
            get
            {
                if (!this.IsAttached)
                    return -1;
                return reader.Version;
            }
        }

        public int SerialNumber
        {
            get
            {
                if (!this.IsAttached)
                    return -1;
                return reader.SerialNumber;
            }
        }

        public string Name
        {
            get
            {
                if (!this.IsAttached)
                    return "";
                return reader.Name;
            }
        }

        public bool LEDIsActive
        {
            get
            {
                if (!this.IsAttached)
                    return false;
                return reader.LED;
            }
        }

        public string Label
        {
            get
            {
                if (!this.IsAttached)
                    return "";
                return reader.Label;
            }
        }

        public Phidgets.Phidget.PhidgetID ID
        {
            get
            {
                if (!this.IsAttached)
                    return Phidgets.Phidget.PhidgetID.RFID_2OUTPUT_READ_WRITE;
                return reader.ID;
            }
        }

        public string LastTag
        {
            get
            {
                if (!this.IsAttached)
                    return "";
                return reader.LastTag;
            }
        }

        public bool AntennaIsActive
        {
            get
            {
                if (!this.IsAttached)
                    return false;
                return reader.Antenna;
            }
        }

        public string Address
        {
            get
            {
                if (!this.IsAttached)
                    return "";
                return reader.Address;
            }
        }

        public RFID()
        {
            if (!HasDrivers)
                return;

            reader = new Phidgets.RFID();
            reader.open(-1);
            this.reader.Attach += reader_Attach;
            this.reader.Detach += reader_Detach;
            this.reader.Tag += reader_Tag;
            this.reader.TagLost += reader_TagLost;
            this.reader.Error += reader_Error;

            this.OnError = (x) => this.Dispose();

            this.OnAttach += (x) => Activate();
            this.OnDetach += (x) => DeActivate();
        }

        private void Activate()
        {
            if (!this.IsAttached) return;

            if (!LEDIsActive) ToggleLED();
            if (!AntennaIsActive) ToggleAntena();
        }

        private void DeActivate()
        {
            if (!this.IsAttached) return;

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
            Visitor found = Visitor.Authenticate(e.Tag);
            if (found != null)
                onVisitorDetect(found);
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
            if (this.reader == null)
                return;
            if (!HasDrivers)
                return;

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