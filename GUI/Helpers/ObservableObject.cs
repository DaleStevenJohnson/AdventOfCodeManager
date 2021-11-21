using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TeacherPlanner.Helpers
{

    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises a property changed event for the property named
        /// Call this in a property setter like so:
        /// RaiseAndSetIfChanged(ref _privateField, value)
        /// </summary>
        protected virtual bool RaiseAndSetIfChanged<TProperty>(
            ref TProperty field,
            TProperty value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TProperty>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}