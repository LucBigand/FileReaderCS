using System.Drawing.Text;

namespace FileReaderCS
{
    internal class Client
    {

        internal readonly string title, lastName, firstName, postalCode, town = "";
        internal static readonly string[] columnNames = { "CIV_LIBELLE", "NOM", "PRENOM", "CP", "VILLE" };

        public Client(string csvLine, char separator, Dictionary<string, int> columnOrder)
        {
            string[] entry = csvLine.Split(separator);
            title = entry[columnOrder[columnNames[0]]];
            lastName = entry[columnOrder[columnNames[1]]];
            firstName = entry[columnOrder[columnNames[2]]];
            postalCode = entry[columnOrder[columnNames[3]]];
            town = entry[columnOrder[columnNames[4]]];
        }

    }
}
