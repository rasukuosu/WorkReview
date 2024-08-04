using WorkReview.Models;
namespace WorkReview
{
    public partial class App : Application
    {
        public static GazouByteRepositry GazouByteRepo { get; private set; } //これはProductRepositoryオブジェクトを保持するためのプロパティ
        public App(GazouByteRepositry repo)
        {
            InitializeComponent();

            MainPage = new AppShell();
            GazouByteRepo = repo;
        }
    }
}
