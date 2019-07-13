using System;
using ScientificProgramming.Collections;
using System.Text;

namespace ScientificProgramming.SearchAlgorithms.Abstract
{
    public interface ISearchState
    {
        float Evaluation { get; }

        SList<ISearchState> NextStates();
    }
}
