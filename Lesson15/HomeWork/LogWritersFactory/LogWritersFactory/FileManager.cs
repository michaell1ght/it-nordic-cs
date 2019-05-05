using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogWritersFactory
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
            this.CreateFIleOrFolderNotExist();
            using (var writer = new StreamWriter(_filePath + _fileName, true,Encoding.UTF8))
                {
                writer.WriteLine(_text);
                writer.Close();
                }
            }

        private void CreateFIleOrFolderNotExist()
        {
            if (!Directory.Exists(this._filePath))
            {
                Directory.CreateDirectory(this._filePath);
            }
            if (!File.Exists(_filePath + _fileName))
            {
                File.Create(_filePath + _fileName);
            }
        }
    }
}
