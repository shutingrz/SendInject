using System;
using System.Threading.Tasks;
using Reactive.Bindings;
using SendInject.Model;
using System.Reactive.Linq;
using Reactive.Bindings.Helpers;
using log4net;

namespace SendInject.ViewModel
{
    public class MainViewModel
    {

        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// StatusView
        /// </summary>
        public ReadOnlyReactiveProperty<string> StatusMessage { get; private set; }


        /// <summary>
        /// ProcessView
        /// </summary>
        public ReadOnlyReactiveCollection<ProcessData> ProcessView { get; private set; }
        public ReactiveCommand RefreshProcessCommand { get; private set; } = new ReactiveCommand();
        public ReactiveCommand AttachProcessCommand { get; private set; } = new ReactiveCommand();
        public ProcessList ProcessList = new ProcessList();

        /// <summary>
        /// LogView
        /// </summary>
        public ReadOnlyReactiveCollection<LogData> LogView { get; private set; }
        public ReactiveCommand CopyBinaryCommand { get; private set; } = new ReactiveCommand();
        public LogList LogList = new LogList();


        public void Init()
        {
            
            Task.Run(() => this.ProcessList.GetProcessList());
        }

        public MainViewModel()
        {

            //ViewModel <= Model
            this.ProcessView = ProcessList.ProcessCollection
                .ToReadOnlyReactiveCollection();
            this.LogView = LogList.LogCollection
                .ToReadOnlyReactiveCollection();

            //ViewModel => Model
            this.RefreshProcessCommand.Subscribe(async _ => await Task.Run(() =>
            {
                this.ProcessList.GetProcessList();
            }));

            this.AttachProcessCommand.Subscribe(pData =>
            {
                ProcessData processData = (ProcessData)pData;

                var logData = new LogData
                {
                    Time = DateTime.Now,
                    ProcessName = processData.ProcessName,
                    LogType = LogData.LogTypeData.General.ToString(),
                    Message = "アタッチしました。"                   
                };

                this.LogList.LogCollection.Add(logData);
            });

            Init();
        }

    }
}
