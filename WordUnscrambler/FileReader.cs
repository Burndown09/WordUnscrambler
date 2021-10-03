using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            // Implement this.
            string filepath = filename;
            StreamReader reader = new StreamReader(filepath);
            
            List<string> listOfWords = new List<string>();
            while(reader.Peek() >= 0) {
                listOfWords.Append(reader.ReadLine());
            
            
            }
            return listOfWords.ToArray();

        }
    }
}
