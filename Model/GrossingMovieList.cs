using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfMultiColumnDropDownControlDemo
{
    class GrossingMoviesList : NotificationObject
    {
        #region Properties
        private int serialNumber;
        private string title;
        private string cast;
        private string director;
        private string genre;
        private string ratingMPAA;

        public int SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                serialNumber = value;
                RaisePropertyChanged("SerialNumber");
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string Cast
        {
            get
            {
                return cast;
            }
            set
            {
                cast = value;
                RaisePropertyChanged("Cast");
            }
        }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
                RaisePropertyChanged("Director");
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                RaisePropertyChanged("Genre");
            }
        }

        public string Rating
        {
            get
            {
                return ratingMPAA;
            }
            set
            {
                ratingMPAA = value;
                RaisePropertyChanged("Rating");
            }
        }
        #endregion

        #region Ctor

        public GrossingMoviesList(int serialNumber, string title, string cast, string director, string genre, string ratingMPAA)
        {
            this.serialNumber = serialNumber;
            this.title = title;
            this.cast = cast;
            this.director = director;
            this.genre = genre;
            this.ratingMPAA = ratingMPAA;
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
