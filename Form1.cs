using System.Data.Common;

namespace FileReaderCS
{
    public partial class Form1 : Form
    {

        private string filePath = "";
        private string directoryPath = "";
        private List<Person> persons = new List<Person>();
        private string[] columnNames = new string[5];

        public Form1()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectFile();
            ReadFile();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SelectDirectory();
            SaveFile();
        }

        // Open a file dialog and register the file selected by the user
        private void SelectFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
            }
        }

        // Read the registered file and saves its data in the form of a list of Clients
        private void ReadFile()
        {
            StreamReader sr = new StreamReader(filePath);
            string? line = sr.ReadLine();
            char separator = line.TrimStart("ABCDEFGHIJKLMNOPQRSTUVWXYZ_".ToCharArray())[0];
            columnNames = line.Split(separator);
            persons = new List<Person>();
            while ((line = sr.ReadLine()) is not null)
            {
                persons.Add(new Person(line, separator, columnNames));
            }
            sr.Close();
        }

        // Write the data in a new file in the registered directory
        private void SaveFile()
        {
            StreamWriter sw = new StreamWriter(
                Path.Combine(directoryPath, Path.GetFileName(filePath)));
            sw.WriteLine(String.Join(";", columnNames));
            foreach (Person person in persons)
            {
                sw.WriteLine(person.ToCSVLine(columnNames));
            }
            sw.Close();
        }

        // Open a browser dialog and select the directory selected by the user
        private void SelectDirectory()
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                directoryPath = browserDialog.SelectedPath;
            }
        }

    }
}