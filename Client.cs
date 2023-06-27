using System.Drawing.Text;

namespace FileReaderCS
{
    internal class Client
    {

        internal readonly string title, lastName, firstName, postalCode, town = "";
        internal static readonly string[] columnNamesDefault = 
            { "CIV_LIBELLE", "NOM", "PRENOM", "CP", "VILLE" };

        public Client(string csvLine, char separator, string[] columnNames)
        {
            string[] entry = csvLine.Split(separator);
            title = GetFieldValue(entry, columnNames, 0);
            lastName = GetFieldValue(entry, columnNames, 1);
            firstName = GetFieldValue(entry, columnNames, 2);
            postalCode = GetFieldValue(entry, columnNames, 3);
            town = GetFieldValue(entry, columnNames, 4);

            // Standardize data
            string upperTitle = title.ToUpper();
            if (upperTitle.Equals("MR"))
            {
                title = "MR";
            }
            else if (upperTitle.Equals("MME"))
            {
                title = "Mme";
            }
            lastName = lastName.ToUpper();
            firstName = firstName.ToUpper();
            town = town.ToUpper();
            postalCode = postalCode.PadLeft(5, '0');
        }

        /*
         * Return from the entry the value of what would be the field of index i in the default
         * column order as defined in columnNames
         * Parameters :
         *      entry : The entry informations as a string array (possibly not in the default 
         *              column order)
         *      columnNames : the order in which the informations are presented in the entry, as
         *              a string array
         *      i : the index of the field whose value is to be returned
         */
        private string GetFieldValue(string[] entry, string[] columnNames, int i)
        {
            if (entry.Length < i)
            {
                return string.Empty;
            }
            else
            {
                return entry[Array.IndexOf(columnNames, columnNamesDefault[i])];
            }
        }

    }
}
