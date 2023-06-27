namespace FileReaderCS
{
    internal class Client
    {

        private string title, lastName, firstName, postalCode, town;
        internal static readonly string[] columnNames = { "CIV_LIBELLE", "NOM", "PRENOM", "CP", "VILLE" };

        public Client(string csvLine) : this(csvLine, ';') { }

        public Client(string csvLine, char separator)
        {
            string[] data = csvLine.Split(separator);
            title = data[0];
            lastName = data[1];
            firstName = data[2];
            postalCode = data[3];
            town = data[4];
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
