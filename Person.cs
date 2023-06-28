using System.Drawing.Text;

namespace FileReaderCS
{
    internal class Person
    {

        private Dictionary<string, string> data;
        internal static readonly string[] columnNamesDefault = 
            { "CIV_LIBELLE", "NOM", "PRENOM", "CP", "VILLE" };

        public Person(string csvLine, char separator, string[] columnNames)
        {
            string[] entry = csvLine.Split(separator);
            data = new Dictionary<string, string>();
            for (int i = 0; i < entry.Length && i < columnNames.Length; i++)
            {
                data.Add(columnNames[i], entry[i]);
            }
            foreach (string columnName in columnNamesDefault)
            {
                if (!data.ContainsKey(columnName))
                {
                    data.Add(columnName, string.Empty);
                }
            }

            // Standardize data
            foreach (string fieldName in columnNamesDefault)
            {
                data[fieldName] = data[fieldName].Trim();
            }
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

        // Return the value for the field given as parameter
        public string GetFieldValue(string fieldName)
        {
            return data[fieldName];
        }

        public string ToCSVLine(string[] columnNames)
        {
            return ToCSVLine(columnNames, ';');
        }

        /* Convert this Person's data into a CSV line
         * Parameters :
         *      columnNames : A string array with the field names in order of their appearance
         *              in the CSV line
         *      separator : The separator to be used in the CSV line
         */
        public string ToCSVLine(string[] columnNames, char separator)
        {
            return String.Join(
                separator, columnNames.Select(fieldName => GetFieldValue(fieldName)));
        }

    }
}
