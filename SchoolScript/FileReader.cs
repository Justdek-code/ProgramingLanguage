using System;
using System.IO;

namespace SchoolScript
{
    public class FileReader
    {
        private string _fileContent;
        private string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
            _fileContent = File.ReadAllText(filePath);
            _fileContent = _fileContent.Replace('\r', ' ');
        }

        public string GetContent()
        {
            return _fileContent;
        }
    }
}