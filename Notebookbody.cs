using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Notebook
{
    struct NotebookBody
    {

        /// <summary>
        /// поле номера записи
        /// </summary>
        private int notenumber;
        /// <summary>
        /// поле Дата
        /// </summary>
        private DateTime date;
        /// <summary>
        /// поле Цели
        /// </summary>
        private string goal;
        /// <summary>
        /// поле Комментарии
        /// </summary>
        private string comment;
        /// <summary>
        /// поле Контакты
        /// </summary>
        private string contact;

        #region Свойства полей (пока закоментены, т.к. стоят автосвойства)
        /// <summary>
        /// Доступ к полю номера записи
        /// </summary>
        public int Notenumber
        {
            get { return this.notenumber; }
            set { this.notenumber = value; }
        }
        /// <summary>
        /// Доступ к полю даты
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        /// <summary>
        /// Доступ к полю целей
        /// </summary>
        public string Goal
        {
            get { return this.goal; }
            set { this.goal = value; }
        }
        /// <summary>
        /// Доступ к полю комментариев
        /// </summary>
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        /// <summary>
        /// Доступ к полю контактов
        /// </summary>
        public string Contact
        {
            get { return this.contact; }
            set { this.contact = value; }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Создание содержимого ежедневника
        /// </summary>
        /// <param name="notenumber">Номер записи</param>
        /// <param name="date">Дата</param>
        /// <param name="goal">Цели</param>
        /// <param name="comment">Комментарии</param>
        /// <param name="contact">Контакты</param>
        public NotebookBody(int notenumber, DateTime date, string goal, string comment, string contact)
        {
            this.notenumber = notenumber;
            this.date = date;
            this.goal = goal;
            this.comment = comment;
            this.contact = contact;
        }
        /// <summary>
        /// Создание содержимого ежедневника c нынешней датой по умолчанию
        /// </summary>
        /// <param name="goal">цели</param>
        /// <param name="comment">коменты</param>
        /// <param name="contact">контакты</param>
        public NotebookBody(int notenumber, string goal, string comment, string contact) :
            this(notenumber, DateTime.Now, goal, comment, contact)
        {
            
        }
        /// <summary>
        /// Вывод в консоль
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            string dates = Convert.ToString(this.date.ToShortDateString());
            return $"{this.notenumber,10} {dates,10:d} {this.goal,10} {this.comment,10} {this.contact,10}";
        }
        #endregion
    }
}

