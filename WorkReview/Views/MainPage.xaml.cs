using WorkReview.Models;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using WorkReview.ViewModels;

namespace WorkReview.Views;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainviewModel();
      
    }

    public void OnNewAddButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        App.ProductRepo.AddNewProduct(newProduct.Text);
        statusMessage.Text = App.ProductRepo.StatusMessage;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Product> products = App.ProductRepo.GetAllProducts();
        productList.ItemsSource = products;
    }
    public async void OnFileSelectClicked(object sender, EventArgs args)
    {
        var result = await FilePicker.PickAsync();
        if (result != null)
        {
            if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
            {
                var stream = await result.OpenReadAsync();
                userPreview.Source = ImageSource.FromStream(() => stream);

                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    byte[] imageBinary = memoryStream.ToArray();
                    ///Ç±Ç±Ç…ViewmodelÇÃÉoÉCÉiÉäObservablepropertyÇèëÇ≠
                    MainViewModel.GazouBynary = imageBinary;
                }
            }
        }
    }
}