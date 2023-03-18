using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPetApp1 {
    class TwoWayData : INotifyPropertyChanged{

        private int _height;

        public int height {
            get => _height;
            set {
                this._height = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("_height")); //触发事件
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
