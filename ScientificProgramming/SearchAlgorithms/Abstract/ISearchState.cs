using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificProgramming.SearchAlgorithms.Abstract
{
    public interface ISearchState<T>
    {
        T State { get; }

        float Evaluation { get; }

        T[] NextStates();
    }
}
