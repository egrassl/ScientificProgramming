using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificProgramming.SearchAlgorithms.Abstract
{
    public interface ITreeSearch<T>
    {
        T CurrentState { get; }

        T[] SeachedStates { get; }

        T[] StatesToSearch { get; }

        T NextState();
    }
}
