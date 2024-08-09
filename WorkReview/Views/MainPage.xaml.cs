using WorkReview.Models;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using WorkReview.ViewModels;
using System.Runtime.CompilerServices;

namespace WorkReview.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
        

        public void OnGetAllGazouClicked(object sender, EventArgs args)
        {
            List<GazouByte> gazouByte = App.GazouByteRepo.GetAllGazouBytes();
       
            statusMessage.Text = "got all file list";

        }


        public void OnFileSaveClicked(object sender, EventArgs args)
        {

            
            (BindingContext as MainViewModel).SaveGazouToDataBase(); //BindingVontext�̃C���X�^���X����������.Save~���\�b�h�����s���Ă���
            statusMessage.Text = "file saved";

        }

        public async void OnFileSelectClicked(object sender, EventArgs args)
        {
            try
            {
                var result = await FilePicker.PickAsync();
                var fileExtension = result.ContentType;
                var fileName = result.FileName;
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                           
                        using (var stream = await result.OpenReadAsync())
                        {
                            using (var memoryStream = new MemoryStream())///using(var)��Using�X�e�[�g�����g,{}���̏������I������Ƃ��Ƀ��\�[�X���J�������
                            {
                                await stream.CopyToAsync(memoryStream);�@//memoryStream�ɕۑ����ꂽ�f�[�^��ViewModel�̊Y���ӏ��֑��� / send data to 
                                (BindingContext as MainViewModel).gazouExtension = fileExtension;
                                (BindingContext as MainViewModel).gazouName = fileName;
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
