using Newtonsoft.Json;

namespace Lab3_json;

public partial class AddStudentPage : ContentPage
{
    private EditPage editPage;
    private string jsonPath;
    public AddStudentPage(EditPage editPage, string path)
	{
		InitializeComponent();
		this.editPage = editPage;
        jsonPath = path;

        
    }

	private void OnOkClicked(object sender, EventArgs e)
	{
        editPage.AddStudent(new Student
        {
            Id = entryId.Text,
            Name = entryName.Text,
            Surname = entrySurname.Text,
            Faculty = entryFaculty.Text,
            StudyingYear = entryStudyingYear.Text
        });
        string json = JsonConvert.SerializeObject(editPage.Students, Formatting.Indented);

        File.WriteAllText(jsonPath, json);

        Navigation.PopAsync();
    }
    
}
