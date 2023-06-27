using System.Drawing.Text;

namespace FileReaderCS
{
    internal class Person
    {

        internal Dictionary<string, string> data;
        internal static readonly string[] columnNamesDefault = 
            { "CIV_LIBELLE", "NOM", "PRENOM", "CP", "VILLE" };

        public Person(string csvLine, char separator, string[] columnNames)
        {
            string[] entry = csvLine.Split(separator);
            data = new Dictionary<string, string>();
            for (int i = 0; i < entry.Length && i < columnNamesDefault.Length; i++)
            {
                data.Add(columnNamesDefault[i], GetValueFromArray(entry, columnNames, i));
            }

            // Standardize data
            string upperTitle = data["CIV_LIBELLE"].ToUpper();
            if (upperTitle.Equals("MR"))
            {
                data["CIV_LIBELLE"] = "MR";
            }
            else if (upperTitle.Equals("MME"))
            {
                data["CIV_LIBELLE"] = "Mme";
            }
            data["NOM"] = data["NOM"].ToUpper();
            data["PRENOM"] = data["PRENOM"].ToUpper();
            data["VILLE"] = data["VILLE"].ToUpper();
            data["CP"] = data["CP"].PadLeft(5, '0');
        }

        public string getFieldValue(string fieldName)
        {
            return data[fieldName];
        }

        public string ToCSVLine(char separator, string[] columnNames)
        {
            return "";
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
        private static string GetValueFromArray(string[] entry, string[] columnNames, int i)
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
