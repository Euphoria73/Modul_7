using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notebook
{
    class WorkWithNotebook
    {        
        /// <summary>
        /// Метод создания записи
        /// </summary>
        /// <param name="totalNoteNumber">общее число записей в ежедневнике</param>
        /// <returns>созданная новая запись</returns>
        public List<NotebookBody> Create(int totalNoteNumber)
        {
            Console.WriteLine("Создание новой записи:");

            Console.WriteLine("Введите цель: ");
            string goal = Console.ReadLine();

            Console.WriteLine("Введите комментарий: ");
            string comment = Console.ReadLine();

            Console.WriteLine("Введите контакт: ");
            string contact = Console.ReadLine();

            List<NotebookBody> generalList = new List<NotebookBody>
            { new NotebookBody(totalNoteNumber, goal, comment, contact)
            };
            return generalList;
        }
        /// <summary>
        /// Метод добавления записей в ежедневник
        /// </summary>
        /// <param name="generalList">существующие записи ежедневника</param>
        /// <param name="newList">добавляемая запись в ежедневник</param>
        /// <returns>дополненный записями ежедневник</returns>
        public List<NotebookBody> Add(List<NotebookBody> generalList, List<NotebookBody> newList, int totalNoteNumber)
        {
            List<NotebookBody> generalAddList = generalList.ToList();            
            Print(generalList);
            for (int i = 0; i < newList.Count; i++)
            {
                NotebookBody temporaryList = newList[i];
                temporaryList.Notenumber = totalNoteNumber + i;
                newList[i] = temporaryList;
            }
            for (int i = 0; i < newList.Count; i++)
            {
                generalAddList.Add(newList[i]);
            }            
            return generalAddList;
        }
        /// <summary>
        /// Метод удаления записи
        /// </summary>
        /// <param name="generalList">общий список записей</param>
        /// <param name="deleteNoteNumber">номер записи для удаления</param>
        /// <returns>список записей после удаления</returns>
        public List<NotebookBody> Delete(List<NotebookBody> generalList, int deleteNoteNumber)
        {
            List<NotebookBody> generalDeleteList = generalList;

            generalDeleteList.RemoveAt(deleteNoteNumber - 1);
            for (int i = 0; i < generalDeleteList.Count; i++)
            {
                NotebookBody temporaryList = generalDeleteList[i];
                temporaryList.Notenumber = i + 1;
                generalDeleteList[i] = temporaryList;
            }
            Console.WriteLine("Удалено");
            return generalDeleteList;
        }
        /// <summary>
        /// Метод редактирования записи
        /// </summary>
        /// <param name="generalList">общий список записей</param>
        /// <param name="editNoteNumber">номер записи для редактирования</param>
        /// <returns></returns>
        public List<NotebookBody> Edit(List<NotebookBody> generalList, int editNoteNumber)
        {
            List<NotebookBody> generaEditlList = generalList;
            Console.WriteLine("Зименить всё - 1,\n" +
                " изменить цели - 2,\n" +
                " изменить комментарий - 3,\n" +
                " изменить контакты - 4,\n " +
                "отменить изменение - любая другая цифра");
            WorkModuls module = new WorkModuls();
            int choisefield = module.Enter();
            switch (choisefield)
            {
                case 1:
                    Console.WriteLine("Введите цель: ");
                    string goal = Console.ReadLine();

                    Console.WriteLine("Введите комментарий: ");
                    string comment = Console.ReadLine();

                    Console.WriteLine("Введите контакт: ");
                    string contact = Console.ReadLine();

                    generaEditlList[editNoteNumber - 1] = new NotebookBody(editNoteNumber, goal, comment, contact);
                    break;
                case 2:
                    Console.WriteLine("Введите цель: ");
                    goal = Console.ReadLine();
                    comment = generaEditlList[editNoteNumber - 1].Comment;
                    contact = generaEditlList[editNoteNumber - 1].Contact;
                    generaEditlList[editNoteNumber - 1] = new NotebookBody(editNoteNumber, goal, comment, contact);
                    break;
                case 3:
                    Console.WriteLine("Введите комментарий: ");
                    comment = Console.ReadLine();
                    goal = generaEditlList[editNoteNumber - 1].Goal;
                    contact = generaEditlList[editNoteNumber - 1].Contact;
                    generaEditlList[editNoteNumber - 1] = new NotebookBody(editNoteNumber, goal, comment, contact);
                    break;
                case 4:
                    Console.WriteLine("Введите контакт: ");
                    contact = Console.ReadLine();
                    goal = generaEditlList[editNoteNumber - 1].Goal;
                    comment = generaEditlList[editNoteNumber - 1].Comment;
                    generaEditlList[editNoteNumber - 1] = new NotebookBody(editNoteNumber, goal, comment, contact);
                    break;
                default:
                    Console.WriteLine("Изменение отменено");
                    break;
            }// Конструктор выбора изменения определённых полей
            Console.WriteLine("Изменено");
            return generaEditlList;
        }
        /// <summary>
        /// Поиск записи по дате
        /// </summary>
        /// <param name="generalList">общий список записей</param>
        /// <param name="date">нужная дата</param>
        /// <returns></returns>
        public List<NotebookBody> DataFind(List<NotebookBody> generalList, DateTime startDate, DateTime finishDate)
        {            
            List<NotebookBody> dataFindlList = new List<NotebookBody>();
            for (int i = 0; i < generalList.Count; i++)
            {
                if (generalList[i].Date >= startDate && generalList[i].Date <= finishDate)
                {
                    dataFindlList.Add(generalList[i]);
                }                   
            }
            return dataFindlList;
        }
        public List<NotebookBody> Sort(List<NotebookBody> generalList)
        {            
            List<NotebookBody> sortList = generalList.ToList();
            Console.WriteLine("Cортировать:\n" +
                " номера записей - (1),\n" +
                " Цели - (2),\n" +
                " Комментарии - (3),\n" +
                " Контакты - (4),\n" +
                " отменить сортировку - (любая другая цифра)");
            WorkModuls module = new WorkModuls();
            int choisefield = module.Enter();
            switch (choisefield)
            {
                case 1:
                    NoteNumberComparer nnc = new NoteNumberComparer();
                    Console.WriteLine("Сортировка по номеру записи:");
                    sortList.Sort(nnc);
                    break;
                case 2:                    
                    GoalComparer gc = new GoalComparer();
                    Console.WriteLine("Сортировка по Целям:");
                    sortList.Sort(gc);
                    break;
                case 3:
                    CommentComparer comc = new CommentComparer();
                    Console.WriteLine("Сортировка по Комментариям:");
                    sortList.Sort(comc);
                    break;
                case 4:
                    ContactComparer contc = new ContactComparer();
                    Console.WriteLine("Сортировка по Комментариям:");
                    sortList.Sort(contc);
                    break;
                default:
                    Console.WriteLine("Сортировка отменена");
                    break;
            }// Конструктор выбора сортировки определённых полей
            Print(sortList);            

            return sortList;
        }
        /// <summary>
        /// Метод вывода списка записи в консоль 
        /// </summary>
        /// <param name="generalList">дополненный записями ежедневник</param>
        public void Print(List<NotebookBody> generalList)
        {
            Console.WriteLine("{0,10}{1,10}{2,10}{3,15}{4,10}",
            "№ записи", "Дата", "Задача", "Комментарии", "Контакты");
            for (int i = 0; i < generalList.Count; i++)
            {
                Console.WriteLine(generalList[i].Print());
            }            
        }

    }
}
