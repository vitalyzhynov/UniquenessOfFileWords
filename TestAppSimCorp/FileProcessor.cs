using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppSimCorp
{
    public class FileProcessor
    {
        private UniquenessHelper _uniquenessHelper;

        public FileProcessor()
        {
            _uniquenessHelper = new UniquenessHelper();
        }

        public string CalcWordOccurencesInFile(string path)
        {
            try
            {
                string text = System.IO.File.ReadAllText(path);
                var occurences = _uniquenessHelper.CalcOccurencesSafe(text);
                return occurences.PrettyPrint();
            }
            catch (Exception ex)
            {
                return "Unexpected error while reading the file " + ex.Message;
            }
        }
    }
}
