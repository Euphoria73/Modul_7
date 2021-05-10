using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    class WorkModuls
    {
        readonly WorkWithFiles file = new WorkWithFiles();
        readonly WorkWithNotebook notebook = new WorkWithNotebook();
        readonly string pathOut = AppDomain.CurrentDomain.BaseDirectory + "\\Notebook.json"; //путь к главному файлу
        /// <summary>
        /// Метод, ограничивающий ввод только целочисленного значения
        /// </summary>
        /// <returns></returns>
        public byte Enter()
        {
            string stringEnter = "";
            byte integerEnter;
            while (!Byte.TryParse(stringEnter, out integerEnter))
            {
                Console.Write("Введите число: ");
                try
                {
                    integerEnter = Convert.ToByte(Console.ReadLine());
                    return integerEnter;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Это не число, будьте внимательнее");
                }
            }
            return integerEnter;
        }
        /// <summary>
        /// Метод чтения их файла
        /// </summary>
        /// <returns></returns>
        public List<NotebookBody> Read()
        {
            List<NotebookBody> generalList = file.Read(pathOut);                   //чтение из файла            
            return generalList;
        }
        /// <summary>
        /// Метод создания записи
        /// </summary>
        /// <param name="generalList">общий список записей</param>
        /// <returns></returns>
        public List<NotebookBody> Create(List<NotebookBody> generalList)
        {
            int totalNoteNumber = generalList.Count;
            List<NotebookBody> newList = notebook.Create(totalNoteNumber);             //создание новой записи
            List<NotebookBody> generalAddList = notebook.Add(generalList, newList, totalNoteNumber + 1); //дополняем существующий ежедневник новой записью      
            return generalAddList;
        }
        /// <summary>
        /// Метод удаления записи
        /// </summary>
        /// <param name="generalList"></param>
        /// <returns></returns>
        public List<NotebookBody> Delete(List<NotebookBody> generalList)
        {
            Console.WriteLine("Выберите номер записи для удаления:");
            int deleteNoteNumber = Enter();
            List<NotebookBody> deleteList = notebook.Delete(generalList, deleteNoteNumber);
            Console.WriteLine("Запись удалена успешно!");
            return deleteList;
        }
        /// <summary>
        /// Метод импорта записей из другого файла в основной
        /// </summary>
        /// <param name="generalList"></param>
        /// <returns></returns>
        public List<NotebookBody> Import(List<NotebookBody> generalList)
        {
            string import_path = AppDomain.CurrentDomain.BaseDirectory + "\\importNotebook.json";
            List<NotebookBody> importlList = file.Read(import_path);     
            int totalNoteNumber = generalList.Count;
            List<NotebookBody> importlAddList = notebook.Add(generalList, importlList, totalNoteNumber + 1);
            Print(importlAddList);
            Console.WriteLine("Изменения верные? Да - (1), Нет - (другая цифра)");
            int importChoise = Enter();
            if (importChoise != 1)
            {
                Console.WriteLine("Изменения не приняты");
                return generalList;
            }
            return importlAddList;
        }
        /// <summary>
        /// Метод редактирования записи
        /// </summary>
        /// <param name="generalList"></param>
        /// <returns></returns>
        public List<NotebookBody> Edit(List<NotebookBody> generalList)
        {

            Console.WriteLine("Какую запись редактировать?");
            int editNoteNumber = Enter();
            List<NotebookBody> editList = notebook.Edit(generalList, editNoteNumber);
            return editList;
        }
        /// <summary>
        /// Метод поиска записей по дате
        /// </summary>
        /// <param name="generalList"></param>
        /// <returns></returns>
        public List<NotebookBody> DataFind(List<NotebookBody> generalList)
        {            
            try
            {
                Console.WriteLine("Введите начальную дату для поиска. " +
                "Формат ввода: день.месяц.год (прим. 01.12.2020)");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Введите конечную дату для поиска. " +
               "Формат ввода: день.месяц.год (прим. 01.12.2020)");
                DateTime finishDate = Convert.ToDateTime(Console.ReadLine());
                List<NotebookBody> dataFindlList = notebook.DataFind(generalList, startDate, finishDate);
                generalList = dataFindlList;     
            }
            catch (FormatException)
            {
                Console.WriteLine("Введеные данные не соответствуют формату");          
                
            }                                   
            return generalList;
        }
        /// <summary>
        /// Метод сортировки полей
        /// </summary>
        /// <param name="generalList"></param>
        /// <returns></returns>
        public List<NotebookBody> Sort(List<NotebookBody> generalList)
        {            
            List<NotebookBody> sortList = notebook.Sort(generalList);
            Console.WriteLine("Изменения верные? Да - (1), Нет - (другая цифра)");
            int importChoise = Enter();
            if (importChoise != 1)
            {
                Console.WriteLine("Изменения не приняты");
                return generalList;
            }            
            return sortList;
        }       

        /// <summary>
        /// Метод сохранения записей в файл
        /// </summary>
        /// <param name="generalList"></param>
        public void Save(List<NotebookBody> generalList)
        {
            file.Save(generalList, pathOut);
        }
        /// <summary>
        /// Метод вывода записей на экран
        /// </summary>
        /// <param name="generalList"></param>
        public void Print(List<NotebookBody> generalList)
        {
            notebook.Print(generalList);

        }
           
    }
}
