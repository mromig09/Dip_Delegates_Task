using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace FileParser {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) 
        {
            var lines = new List<string>();

            var reader = new StreamReader(filePath);
            
            while(true)
            {
                var line = reader.ReadLine();
                if(line == null)
                {
                    break;
                }
                lines.Add(line);
            }

            reader.Close();

            return lines; //-- return result here
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) 
        {
            var writer = new StreamWriter(filePath, false);

            foreach(var row in rows)
            {
                for(var i = 0; i < row.Count; i+= 1)
                {
                    writer.Write(row[i]);

                    if(i != row.Count - 1) 
                    {
                        writer.Write(delimeter);
                    }
                }

                writer.WriteLine();
            }
            writer.Close();
        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter) 
        {
            var result = new List<List<string>>();

            foreach(var line in data)
            {
                var columns = line.Split(new char[] { delimiter });
                result.Add(new List<string>(columns));
            }
            return result; //-- return result here 
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) 
        {
            var result = new List<List<string>>();

            foreach(var line in data)
            {
                var columns = line.Split(new char[] { ',' });
                result.Add(new List<string>(columns));
            }

            return result;  //-- return result here
        }
    }
}