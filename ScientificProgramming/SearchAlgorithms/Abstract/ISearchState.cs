using System;
using ScientificProgramming.Collections;
using System.Text;

namespace ScientificProgramming.SearchAlgorithms.Abstract
{
    public interface ISearchState
    {
        int Evaluation { get; }

        SList<ISearchState> NextStates();

        string Print();
    }
}
