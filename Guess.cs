using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class Guess
    {
        
        public int[,] BackupSudoku;
        public System.Collections.ObjectModel.Collection<Guess> Children;
        public Guess parent;
        public static Guess actual;
        public int[] move;

        public int childCount=0;

        public Guess()
        {
            this.Children = new System.Collections.ObjectModel.Collection<Guess>();
            this.parent = this;
            actual = this;
        } 

        public Guess(Guess Parent)
        {
            this.Children = new System.Collections.ObjectModel.Collection<Guess>();
            this.parent = Parent;
            actual = this;
        }

        public void add(int[] best, int[,] sudoku)
        {
            actual.Children.Add(new Guess(actual));
            childCount++;
            actual.BackupSudoku = sudoku;
            actual.move = best;
            System.Console.Out.WriteLine("==ADD====" + childCount + "=======");
            System.Threading.Thread.Sleep(500);
            //Program.printSudoku(sudoku);
        }

        public int[,] fail()
        {
            actual = parent;
            System.Console.Out.WriteLine("==FAIL===" + childCount + "=======");
            System.Threading.Thread.Sleep(500);
            return actual.BackupSudoku;
            //next if next or parent if no next
        }

    }
}
