using System;
using System.Collections.Generic;
using System.Text;

//TODO: ALGORITHMUS GRAFISCH AUFZEICHNEN, AB EINER BESTIMMTEN KOMPLEXIT‰T MACHT DAS HERUMGEBASTEL KEINEN SINN MEHR


namespace SudokuSolver
{
    class Program
    {


   /*     static int[,] s = new int[,] {      {0, 0, 0, 4, 5, 6, 7, 8, 9},
                                            {0, 0, 0, 7, 8, 9, 1, 2, 3},
                                            {0, 0, 0, 1, 0, 3, 4, 5, 6},
                                            {0, 0, 0, 5, 6, 7, 8, 9, 1},
                                            {5, 6, 7, 8, 9, 1, 2, 3, 4},
                                            {8, 9, 1, 2, 3, 4, 5, 6, 7},
                                            {3, 4, 5, 6, 7, 8, 9, 1, 0},
                                            {6, 7, 8, 9, 1, 2, 3, 4, 5},
                                            {9, 1, 0, 3, 4, 5, 6, 7, 8}     }; */


    /*    static int[,] s = new int[,] { {0, 9, 0, 0, 0, 7, 4, 0, 0},
                                        {0, 0, 0, 8, 0, 0, 9, 0, 0},
                                        {0, 3, 0, 0, 0, 0, 5, 2, 0},
                                        {1, 0, 0, 3, 6, 0, 0, 5, 0},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                        {0, 2, 0, 0, 9, 1, 0, 0, 8},
                                        {0, 1, 4, 0, 0, 0, 0, 7, 0},
                                        {0, 0, 8, 0, 0, 2, 0, 0, 0},
                                        {0, 0, 9, 5, 0, 0, 0, 6, 0} }; */

    /*    static int[,] s = new int[,] {    {0, 0, 2, 0, 7, 0, 1, 0, 0},
                                            {6, 0, 0, 0, 0, 0, 0, 0, 5},
                                            {0, 0, 3, 0, 4, 0, 8, 0, 0},
                                            {0, 7, 0, 0, 0, 0, 0, 3, 0},
                                            {3, 0, 0, 5, 9, 8, 0, 0, 7},
                                            {0, 9, 0, 0, 0, 0, 0, 4, 0},
                                            {0, 0, 4, 0, 1, 0, 6, 0, 0},
                                            {8, 0, 0, 0, 0, 0, 0, 0, 2},
                                            {0, 0, 5, 0, 3, 0, 7, 0, 0} };  */

    /*    static int[,] s = new int[,] {    {0, 0, 2, 0, 7, 0, 1, 0, 0},
                                            {6, 0, 0, 0, 0, 0, 0, 0, 5},
                                            {0, 0, 3, 0, 4, 0, 8, 0, 0},
                                            {0, 7, 0, 0, 0, 0, 0, 3, 0},
                                            {3, 4, 0, 5, 9, 8, 0, 0, 7},        //3. 1
                                            {0, 9, 0, 0, 0, 0, 0, 4, 0},
                                            {0, 0, 4, 0, 1, 0, 6, 0, 0},
                                            {8, 0, 0, 0, 0, 0, 0, 0, 2},
                                            {0, 0, 5, 0, 3, 0, 7, 0, 0} };
        */

        public static void printSudoku(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for(int j=0; j<9; j++)
                    System.Console.Out.Write(sudoku[i,j] + " ");
                System.Console.Out.WriteLine();
                
            }
            System.Console.WriteLine();
        }

        public static bool hasEmpty(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (sudoku[i, j] == 0)
                        return true;
            }
            return false;
        }

        public static void testRow(bool[] solveData, int[,] sudoku, int x, int y)
        {
            for (int i = 0; i < 9; i++)
                solveData[sudoku[x, i]] = true;
        }

        public static void testCol(bool[] solveData, int[,] sudoku, int x, int y)
        {
            for (int i = 0; i < 9; i++)
                solveData[sudoku[i, y]] = true;
        }

        public static void testField(bool[] solveData, int[,] sudoku, int x, int y)
        {
            for (int i = 3 * (x / 3); i < (3 * (x / 3) + 3); i++)
                for (int j = 3 * (y / 3); j < (3 * (y / 3) + 3); j++)
                {
                    //System.Console.Out.Write(i + "/" + j + " ");
                    solveData[sudoku[i, j]] = true;
                }
        }

        public static int[] testAll(int[,] sudoku, int x, int y)
        {
            bool[] solveData = new bool[] { false, false, false, false, false, false, false, false, false, false };

            int[] possibilities = new int[10];      //[0] anzahl        [1] 1. Mˆglichkeit      [2] 2. Mˆglichkeit ...

            testRow(solveData, s, x, y);
            testCol(solveData, s, x, y);
            testField(solveData, s, x, y);

            for (int i = 0; i < 10; i++)
                if (solveData[i] == false)
                {
                    possibilities[0]++;
                    possibilities[possibilities[0]] = i;
                }

            return possibilities;
            }

        


        public static void solve(int [,] sudoku, ReturnData rData)
        {
            int[] resultList;

            while (hasEmpty(s)&&!rData.noSolution)
            {
            rData.noSolution=true;

            for (int i = 0; i < 9; i++)                     
                for (int j = 0; j < 9; j++)
                {
                    if (s[i, j] == 0)                               //Feld nach Lerfelder durchsuchen und Mˆglichkeiten ermitteln
                    {
                        resultList = (testAll(s, i, j));
                        
                        //checkfaults
                        
                        if (resultList[0] < 2)                      //wenn simpel lˆsbar
                        {
                            rData.noSolution = false;
                            s[i, j] = resultList[1]; 
                        }
                        else
                        {
                            if (rData.resultList[0] > resultList[0])
                            {
                                for(int k=0; k<10; k++) rData.resultList[k] = resultList[k];
                                rData.i = i;
                                rData.j = j;
                            }
                        }
                        printSudoku(s); 
                    }


                }
            System.Threading.Thread.Sleep(100);
            System.Console.Out.WriteLine(rData.noSolution);
            }
        }



        public static int findRow(int [,] sudoku, int i, int j)
        {
            int count=0;
            for (int k = 0; k < 9; k++)
                if (sudoku[k, j] != 0) count++;
            return count;
        }

        public static int findCol(int[,] sudoku, int i, int j)
        {
            int count = 0;
            for (int k = 0; k < 9; k++)
                if (sudoku[i, k] != 0) count++;
            return count;
        }

        public static int findField(int[,] sudoku, int i, int j)
        {
            int count = 0;
            for (int k = 3 * (i / 3); k < (3 * (i / 3) + 3); k++)
                for (int l = 3 * (j / 3); l < (3 * (j / 3) + 3); l++)
                {
                    if (sudoku[k, l] != 0) count++;
                }
            return count;
        }

        public static void findBest(int[,] sudoku, ReturnData rData)
        {
            int count=0;
            int bestCount = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] == 0)
                    {
                        count = findCol(sudoku, i, j) + findRow(sudoku, i, j) + findField(sudoku, i, j);
                        if (count > bestCount)
                        {
                            bestCount = count;
                            rData.i = i;
                            rData.j = j;
                        }
                    }
                }
        }



        public static void solveComplex(ReturnData rData)
        {
            findBest(s, rData);
            System.Console.Out.WriteLine("Best i: " + rData.i + " j: " + rData.j + "value: " + s[rData.i,rData.j]);
            
            int[] possibilities = testAll(s, rData.i, rData.j);

            int[,] backup;

            for (int i = 0; i < possibilities[0]; i++)
            {

                backup = copySudoku(s);


                System.Console.Out.WriteLine(possibilities[0] + " zu durchforsten, durchforste nr: " + (i+1) + " mit inhalt "  + possibilities[i+1] + " an stelle " + rData.i + "/" + rData.j);
                System.Threading.Thread.Sleep(2000);
                s[rData.i, rData.j] = possibilities[i+1];
                rData.noSolution = false;
                solve(s, rData);


                if (rData.noSolution == false) break;
                else
                {
                    
                    System.Console.Out.WriteLine("-----backup----");
                    printSudoku(backup);
                    System.Console.Out.WriteLine("-----aktuell----");
                    printSudoku(s);
                    System.Console.In.Read();

                    s = copySudoku(backup);

                }
                solve(s, rData);

            }
            

        }

        public static int[,] copySudoku(int[,] src)
        {
            int[,] dst = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    dst[i, j] = src[i, j];
            return dst;
        }
        

        public static Guess MasterParent = new Guess();

        static void Main(string[] args)
        {
            MasterParent.BackupSudoku = s;
            ReturnData rData = new ReturnData();

            solve(s, rData);
            if (rData.noSolution) solveComplex(rData);

            System.Console.Out.WriteLine("-------RESULT--------");
            printSudoku(s);

            System.Console.In.Read(); System.Console.In.Read();
        }
    }
}
