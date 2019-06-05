
namespace SendInject.Model
{
    public class ProcessData 
    {
        private string _processName;
        public string ProcessName
        {
            get => _processName;
            set => _processName = value;
        }

        private int _processId;
        public int ProcessId
        {
            get => _processId;
            set => _processId = value;
        }

        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set => _filePath = value;
        }
        
    }
}
