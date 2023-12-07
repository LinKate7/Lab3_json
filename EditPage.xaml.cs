using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Lab3_json;

public partial class EditPage : ContentPage
{
    public List<Student> Students { get; set; }
    public string Path { get; set; }
    public MainViewModel _mainViewModel;
    private MainPage _mainPage;
    public EditPage(string selectedJsonFilePath, MainViewModel mainViewModel, MainPage mainPage)
    {
		InitializeComponent();
        BindingContext = new MainViewModel(selectedJsonFilePath);
        Path = selectedJsonFilePath;
        Students = mainViewModel.Students;
        _mainPage = mainPage;

    }
   
    private void OnAddClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddStudentPage(this, Path));
    }
    public void AddStudent(Student newStudent)
    {
        Students.Add(newStudent);
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {

    }

    private void OnEditClicked(object sender, EventArgs e)
    {

    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        BindingContext = new MainViewModel(Path);
        _mainPage.BindingContext = new MainViewModel(Path);
    }
    
}
