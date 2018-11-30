using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Hw.DataModels;

namespace Hw.DataAccess
{
    /// <summary>
    /// Interface defining the behaviour of a 'file' on the file system as a repository target.
    /// </summary>
    public class FileTarget : IRepoTarget
    {
        public string _fileName { get; set; }
        public FileTarget(string fileName)
        {
            _fileName = fileName;
        }
        /// <summary>
        /// Writes a greeting for the specified receipient, to the file 
        /// </summary>
        /// <param name="receipient">Receipient of the greeting</param>
        public async Task WriteGreetingAsync(Receipient receipient)
        {
            string outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(outputFolder, _fileName), append: true))
            {
                await outputFile.WriteLineAsync($"Hello {receipient.Name}!");
            }
        }
    }
}
