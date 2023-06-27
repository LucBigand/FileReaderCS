using System.Data.Common;

namespace FileReaderCS
{
    public partial class Form1 : Form
    {

        private string filePath = "";
        private List<Client> clients = new List<Client>();
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
            clients = new List<Client>();
            while ((line = sr.ReadLine()) is not null)
            {
                clients.Add(new Client(line, separator, columnNames));
            }
            sr.Close();
        }

    }
}