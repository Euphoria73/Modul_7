using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    class GoalComparer : IComparer<NotebookBody>
    {
        /// <summary>
        /// Сортировка по целям
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public int Compare(NotebookBody o1, NotebookBody o2)
        {
            if (o1.Goal.Length > o2.Goal.Length)
            {
                return 1;
            }
            else if (o1.Goal.Length < o2.Goal.Length)
            {
                return -1;
            }

            return 0;
        }
    }
}
