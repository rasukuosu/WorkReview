using WorkReview.Models;
using System.Collections.Generic;

namespace WorkReview.Views;


public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
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
    public void OnFileSelectClicked(object sender, EventArgs args) { 
    }
}