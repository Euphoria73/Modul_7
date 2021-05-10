using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    class DateComparer : IComparer<NotebookBody>
    {
        /// <summary>
        /// Сортировка по дате
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public int Compare(NotebookBody o1, NotebookBody o2)
        {
            DateTime a = Convert.ToDateTime(o1);
            DateTime b = Convert.ToDateTime(o2);
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            return 0;
        }
    }
}
