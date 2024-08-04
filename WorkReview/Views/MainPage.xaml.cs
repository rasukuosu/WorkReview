using WorkReview.Models;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using WorkReview.ViewModels;

namespace WorkReview.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }


        public async void OnFileSelectClicked(object sender, EventArgs args)
        {
            try
            {
                var result = await FilePicker.PickAsync();
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var stream = await result.OpenReadAsync())
                        {
                            using (var memoryStream = new MemoryStream())///using(var)はUsingステートメント,{}内の処理が終わったときにリソースが開放される
                            {
                                await stream.CopyToAsync(memoryStream);
                                (BindingContext as MainViewModel).gazouBinary = memoryStream.ToArray();
                                var previewStream = new MemoryStream(memoryStream.ToArray());
                                userPreview.Source = ImageSource.FromStream(() => previewStream);
                            }
                        }
                    }
                    else
                    {
                        statusMessage.Text = "Unsupported file type.";
                    }
                }
            }
            catch (Exception ex)
            {
                statusMessage.Text = $"Error selecting file: {ex.Message}";
            }
        }
    }
}
