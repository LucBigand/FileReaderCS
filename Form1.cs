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
            SaveFile2();
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

        // Write the data in a new file in the selected directory
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

        /* Writes the data in two separated files (one for men and one for women) in the selected
         * directory. The columns "NOM" and "PRENOM" are inverted for men, and "CP" and "VILLE" are
         * inverted for women
         */
        private void SaveFile2()
        {
            string fileNameNoExtension = Path.GetFileNameWithoutExtension(filePath);
            StreamWriter swMen = new StreamWriter(
                Path.Combine(directoryPath, fileNameNoExtension + "-hommes.csv"));
            StreamWriter swWomen = new StreamWriter(
                Path.Combine(directoryPath, fileNameNoExtension + "-femmes.csv"));
            string[] columnNamesMen = Utils.Permutate(columnNames, "NOM", "PRENOM");
            string[] columnNamesWomen = Utils.Permutate(columnNames, "CP", "VILLE");
            swMen.WriteLine(String.Join(";", columnNamesMen));
            swWomen.WriteLine(String.Join(";", columnNamesWomen));
            foreach (Person person in persons)
            {
                if (person.GetFieldValue("CIV_LIBELLE").Equals("MR"))
                {
                    swMen.WriteLine(person.ToCSVLine(columnNamesMen));
                }
                else if (person.GetFieldValue("CIV_LIBELLE").Equals("Mme"))
                {
                    swWomen.WriteLine(person.ToCSVLine(columnNamesWomen));
                }
            }
            swMen.Close();
            swWomen.Close();
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