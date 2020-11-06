using System;
using System.Collections.Generic;
using FileParser;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            var fileHandler = new FileHandler();
            var dataParser = new DataParser();
            var csvHandler = new CsvHandler();

            var dataHandler = new Func<List<List<string>>, List<List<string>>>(dataParser.StripQuotes);
            dataHandler += dataParser.StripWhiteSpace;
            dataHandler += RemoveHashes;

            csvHandler.ProcessCsv("C:/Users/Mark/source/repos/Diploma - OOProgramming/DelegateTask/data.csv", 
                                  "C:/Users/Mark/source/repos/Diploma - OOProgramming/DelegateTask/processed_data.csv", dataHandler);
        }

        public static List<List<string>> RemoveHashes(List<List<string>> data) {
            foreach(var row in data) {
                for (var index = 0; index < row.Count; index++) { 
                    if(row[index][0] == '#')
                        row[index] = row[index].Remove(0,1);
 
                }
            }
            return data;
            
        }
    }
}