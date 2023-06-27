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
            title = GetFieldValue(entry, columnOrder, 0);
            lastName = GetFieldValue(entry, columnOrder, 1);
            firstName = GetFieldValue(entry, columnOrder, 2);
            postalCode = GetFieldValue(entry, columnOrder, 3);
            town = GetFieldValue(entry, columnOrder, 4);
        }

        /*
         * Return from the entry the value of what would be the field of index i in the default
         * column order as defined in columnNames
         * Parameters :
         *      entry : The entry informations as a string array (possibly not in the default 
         *              column order)
         *      columnOrder : the order in which the informations are presented in the entry, as
         *              a dictionary that associates the column name with its postion
         *      i : the index of the field whose value is to be returned
         */
        private string GetFieldValue(string[] entry, Dictionary<string, int> columnOrder, int i)
        {
            if (entry.Length < i)
            {
                return string.Empty;
            }
            else
            {
                return entry[columnOrder[columnNames[i]]];
            }
        }

    }
}
