using System;

namespace SendInject.Model
{
    public class LogData
    {
        public enum LogTypeData
        {
            General,
            Send
        }

        private DateTime _time;
        public DateTime Time
        {
            get => _time;
            set => _time = value;
        }

        public string TimeString
        {
            get => this.Time.ToString(this.TimeFormat);
        }

        private string _timeFormat = "H:mm:ss";
        public string TimeFormat
        {
            get => _timeFormat;
            set => _timeFormat = value;
        }

        private string _processName;
        public string ProcessName
        {
            get => _processName;
            set => _processName = value;
        }

        private string _logType;
        public string LogType
        {
            get => _logType;
            set => _logType = value;
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => _message = value;
        }

        private SendObject _sendData;
        public SendObject SendData
        {
            get => _sendData;
            set => _sendData = value;
        }


    }
}
