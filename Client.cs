namespace FileReaderCS
{
    internal class Client
    {

        private string title, lastName, firstName, postalCode, town;
        internal static readonly string[] columnNames = { "CIV_LIBELLE", "NOM", "PRENOM", "CP", "VILLE" };

        public Client(string csvLine, char separator, Dictionary<string, int> columnOrder)
        {
            string[] data = csvLine.Split(separator);
            title = data[columnOrder[columnNames[0]]];
            lastName = data[columnOrder[columnNames[1]]];
            firstName = data[columnOrder[columnNames[2]]];
            postalCode = data[columnOrder[columnNames[3]]];
            town = data[columnOrder[columnNames[4]]];
        }

        public string getTitle()
        {
            return title;
        }

        public string getLastName()
        {
            return lastName;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getPostalCode()
        {
            return postalCode;
        }

        public string getTown()
        {
            return town;
        }

    }
}
