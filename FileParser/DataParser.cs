using System.Collections.Generic;

namespace FileParser {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
            foreach(var line in data)
            {
                for(var i = 0; i < line.Count; i+= 1)
                {
                    line[i] = line[i].Trim();
                }
            }

            return data; //-- return result here
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            foreach(var line in data)
            {
                for(var i = 0; i < line.Count; i += 1)
                {
                    line[i] = line[i].Trim('"');
                }
            }
            return data; //-- return result here
        }

    }
}