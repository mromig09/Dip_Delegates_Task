using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ObjectLibrary;


namespace FileParser {
    
    //public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            People = new List<Person>();

            foreach (var line in people.Skip(1))
            {
                People.Add(new Person(int.Parse(line[0]), line[1], line[2], new DateTime(long.Parse(line[3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            DateTime oldestDate = People.First().Dob;

            foreach (var person in People)
            {
                if (person.Dob < oldestDate)
                {
                    oldestDate = person.Dob;
                }
            }

            var oldestPeople = new List<Person>();

            foreach (var person in People)
            {
                if (person.Dob == oldestDate)
                {
                    oldestPeople.Add(person);
                }
            }

            return oldestPeople;
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            foreach (var person in People)
            {
                if (person.Id == id)
                {
                    return person.ToString();
                }
            }

            throw new Exception();
        }

        public List<Person> GetOrderBySurname()
        {
            var result = new List<Person>(People);

            result.Sort((a, b) => a.Surname.CompareTo(b.Surname));

            return result;
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            var count = 0;

            foreach (var person in People)
            {
                if (caseSensitive)
                {
                    if (person.Surname.StartsWith(searchTerm))
                    {
                        count += 1;
                    }
                }
                else
                {
                    if (person.Surname.ToUpper().StartsWith(searchTerm.ToUpper()))
                    {
                        count += 1;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
    }
}