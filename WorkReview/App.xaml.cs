using WorkReview.Models;
namespace WorkReview
{
    public partial class App : Application
    {
        public static ProductRepository ProductRepo { get; private set; } //これはProductRepositoryオブジェクトを保持するためのプロパティ
        public App(ProductRepository repo)
        {
            InitializeComponent();

            MainPage = new AppShell();
            ProductRepo = repo;
        }
    }
}
