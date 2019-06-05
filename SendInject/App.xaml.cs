namespace SendInject
{
    using System.Windows;
    using SendInject.View;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainView = new MainView();
            mainView.Show();
        }
    }
}
