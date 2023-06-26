namespace FileReaderCS
{
    public partial class Form1 : Form
    {

        private String filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK) { 
                filename = fileDialog.FileName; 
            }

        }

    }
}