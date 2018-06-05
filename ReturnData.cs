using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class ReturnData
    {
        public int i;
        public int j;
        public bool noSolution;
        public bool Reload;
        public bool solved;
        public int[] resultList;

        
        public ReturnData()
        {
            Reset();
        }

        public void Reset()
        {
            i = 99;
            j = 99;
            noSolution = false;
            Reload = false;
            resultList = new int[] { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 };
            solved = false;
        }
        
    }
}
