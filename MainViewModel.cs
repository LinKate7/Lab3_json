using System;
using Newtonsoft.Json;

namespace Lab3_json
{
	public class MainViewModel
	{
        public List<Student> Students { get; set; }
        public MainViewModel(string path)
		{
			Students = LoadDataFromJsonFile(path);
        }

        private List<Student> LoadDataFromJsonFile(string filePath)
        {
            var jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Student>>(jsonContent);
            
        }


    }
}

