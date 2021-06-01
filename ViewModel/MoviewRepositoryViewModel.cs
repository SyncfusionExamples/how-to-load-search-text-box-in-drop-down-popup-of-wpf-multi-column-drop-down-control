using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace SfMultiColumnDropDownControlDemo
{   

    class MovieRepositoryViewModel : INotifyPropertyChanged
    {
        #region Properties
        private ObservableCollection<GrossingMoviesList> moviesList;
        public ObservableCollection<GrossingMoviesList> MoviesLists
        {
            get
            {
                return moviesList;
            }
            set
            {
                moviesList = value;
                RaisePropertyChanged("MoviesLists");
            }
        }

        #endregion

        #region Ctor
        public MovieRepositoryViewModel()
        {
            MoviesLists = new MovieListRepository();           
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

        private BaseCommand textChanged { get; set; }
        public BaseCommand TextChanged
        {
            get
            {
                if (textChanged == null)
                    textChanged = new BaseCommand(OnTextChangedExecuted);
                return textChanged;
            }
        }

        private BaseCommand popupOpeningCommand { get; set; }

        public BaseCommand PopupOpening
        {
            get
            {
                if (popupOpeningCommand == null)
                    popupOpeningCommand = new BaseCommand(OnPopupOpening);
                return popupOpeningCommand;
            }
        }
        TextBox searchTextBox;
        private void OnTextChangedExecuted(object obj)
        {
            var param = (object[])obj;
            var multiColumnDropDown = param[0] as SfMultiColumnDropDownControl;
            searchTextBox = param[1] as TextBox;
            var grid = multiColumnDropDown.GetDropDownGrid();
            if (grid != null && grid.View != null && grid.View.Filter != null)
                grid.View.RefreshFilter();
        }

        private void OnPopupOpening(object obj)
        {
            var multiColumnDropDown = obj as SfMultiColumnDropDownControl;
            var grid = multiColumnDropDown.GetDropDownGrid();
            if (grid != null)
                grid.View.Filter = CustomerFilter;
        }

        private bool CustomerFilter(object item)
        {
            var movie = item as GrossingMoviesList;
            return movie.Title.ToLower().Contains(searchTextBox.Text.ToLower());
        }
        
    }

    internal class MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.ToArray();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
