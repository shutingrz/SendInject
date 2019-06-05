using System.Collections.ObjectModel;

namespace SendInject.Model
{
    public class LogList
    {
        public ObservableCollection<LogData> LogCollection { get; private set; } = new ObservableCollection<LogData>();
    }
}
