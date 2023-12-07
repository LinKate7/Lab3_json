using System.Collections.ObjectModel;
using System.Text.Json;
using Newtonsoft.Json;

namespace Lab3_json;

public partial class MainPage : ContentPage
{

    
    string selectedJsonFilePath;
    public string jsonContent;
    public MainViewModel mainViewModel;
    public MainPage()
    {
        InitializeComponent();
        
    }

    private async void OnAddJsonFileClicked(object sender, EventArgs e)
    {
        var CustomFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            {DevicePlatform.iOS, new[] {"come.adobe.json"} },
            {DevicePlatform.macOS, new[] {"json"} },
            {DevicePlatform.Android, new[] {"application/json"} },
            {DevicePlatform.WinUI, new[] {".json"} },
            {DevicePlatform.MacCatalyst, new[] {"json"} },
        });
        FileResult result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick a json file",
            FileTypes = CustomFileType

        });

        if (result != null)
        {
            selectedJsonFilePath = result.FullPath;
            mainViewModel = new MainViewModel(selectedJsonFilePath);
            BindingContext = mainViewModel;
        }
    }


    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditPage(selectedJsonFilePath, mainViewModel, this));
    }
    
    private void OnSerializeClicked(object sender, EventArgs e)
    {
        string serializedJson = JsonConvert.SerializeObject(mainViewModel?.Students);
        Label1.Text = serializedJson;
    }
    private async void OnMoreClicked (object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AboutForm());
    }
}

  


