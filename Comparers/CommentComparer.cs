using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    class CommentComparer : IComparer<NotebookBody>
    {
        /// <summary>
        /// Сортировка по комментариям
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public int Compare(NotebookBody o1, NotebookBody o2)
        {
            if (o1.Comment.Length > o2.Comment.Length)
            {
                return 1;
            }
            else if (o1.Comment.Length < o2.Comment.Length)
            {
                return -1;
            }

            return 0;
        }
    }
}
