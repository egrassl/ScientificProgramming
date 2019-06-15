using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificProgramming.Collections.Abstract
{
    public interface ISCollection<T>
    {
        /// <summary>
        /// Gets All Itens
        /// </summary>
        /// <returns></returns>
        T[] GetItems();

    }
}
