using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Notebook
{
    class WorkWithFiles
    {
        /// <summary>
        /// Метод чтения файла Json
        /// </summary>
        /// <param name="pathOut">путь к файлу</param>
        /// <returns>возврат кортежа (загруженные записи из ежедневника, общее число записей)</returns>
        public List<NotebookBody> Read(string pathOut)
        {
            List<NotebookBody> generalList = new List<NotebookBody>();
            try
            {
                generalList = JsonConvert.DeserializeObject<List<NotebookBody>>(File.ReadAllText(pathOut));                
                return generalList;
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
                Console.WriteLine("К сожалению файл не соответствует параметрам программы. " +
                    "Создайте новую запись и сохраните её для перезаписи файла (все предыдущие записи будут утеряны)");                
            }
            return generalList;
        }
        /// <summary>
        /// Метод сохранения ежедневника в файл 
        /// </summary>
        /// <param name="pathIn">путь к файлу</param>
        /// <param name="generalList">дополненный записями ежедневник</param>
        public void Save(List<NotebookBody> generalList, string pathIn)
        {
            File.WriteAllText(pathIn, JsonConvert.SerializeObject(generalList));

            Console.WriteLine("Записано");
        }
    }
}
