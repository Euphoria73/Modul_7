using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    class Menu
    {
        public void Notebook()
        {
            WorkModuls modul = new WorkModuls();
            List<NotebookBody> generalList = modul.Read();
            Console.WriteLine("Записи основного файла:");
            modul.Print(generalList);            
            Console.WriteLine("Выберите дальнейшее действие:\n" +
                "Создать новую запись - (1),\n" + 
                "Удалить запись - (2),\n" +
                "Изменить запись - (3),\n" +
                "Импортировать записи из другого файла - (4),\n" +
                "Найти записи по интервалу дат - (5),\n" +
                "Сортировать записи - (6),\n" +
                "Выйти - (любая другая цифра)");            
            byte userChoise = modul.Enter();
            switch ((WorkChoiseEnum)userChoise)
            {
                case WorkChoiseEnum.Create:
                    List<NotebookBody> newList = modul.Create(generalList);
                    generalList = newList;
                    break;
                case WorkChoiseEnum.Delete:
                    Console.WriteLine("Общий список записей:");
                    modul.Print(generalList);
                    List<NotebookBody> deleteList = modul.Delete(generalList);
                    generalList = deleteList;
                    break;
                case WorkChoiseEnum.Change:
                    modul.Print(generalList);
                    List<NotebookBody> editList = modul.Edit(generalList);
                    generalList = editList;
                    break;
                case WorkChoiseEnum.Import:
                    List<NotebookBody> importlList = modul.Import(generalList);
                    Console.WriteLine("Интеграция основного и стороннего файла:");
                    modul.Print(importlList);
                    break;
                case WorkChoiseEnum.Find:
                    List<NotebookBody> dataFind = modul.DataFind(generalList);
                    Console.WriteLine("Найденные записи по вашей дате:");
                    modul.Print(dataFind);
                    break;
                case WorkChoiseEnum.Sort:
                    generalList = modul.Sort(generalList);
                    break;
                default:
                    break;
            }         
            Console.WriteLine("Итоговый файл:");
            modul.Print(generalList);            
            Console.WriteLine("Хотите сохранить изменения? Да - (1), Нет - (другая цифра)");
            int saveChoise = modul.Enter();
            switch (saveChoise)
            {
                case 1:
                    modul.Save(generalList);
                    break;                
                default:
                    Console.WriteLine("Сохранение отменено");
                    break;
            }            
            Console.WriteLine("Продолжить работу в ежедневнике? Да - (1), Нет - (другая цифра)");
            int continueChoise = modul.Enter();
            switch (continueChoise)
            {
                case 1:
                    Console.Clear();
                    Notebook();
                    break;
                default:
                    Console.WriteLine("Ваша цифра - закон. Всего наилучшего!");
                    break;
            }
        }
    }
}
