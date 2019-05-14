using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogWriters
{
    class FileManager
    {
        private string _filePath;
        private string _fileName;
        private string _text;

        public FileManager(string text, string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
            _text = text;
        }
        public void UpdateFileInFolder()
        {
            CreateFolderIfNotExist();
            CreateFileIfNotExist();
            using (var writer = new StreamWriter(_filePath + _fileName, true,Encoding.UTF8))
                {
                writer.WriteLine(_text);
                writer.Close();
                }
            }

        private void CreateFolderIfNotExist()
        {
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }
        }
        private void CreateFileIfNotExist()
        {
            if (!File.Exists(_filePath + _fileName))
            {
                using (File.Create(_fileName));
            }
        }
    }
}
