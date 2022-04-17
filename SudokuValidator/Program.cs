// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

int[][] goodSudoku1 = {
    new int[] {7,8,4,  1,5,9,  3,2,6},
    new int[] {5,3,9,  6,7,2,  8,4,1},
    new int[] {6,1,2,  4,3,8,  7,5,9},

    new int[] {9,2,8,  7,1,5,  4,6,3},
    new int[] {3,5,7,  8,4,6,  1,9,2},
    new int[] {4,6,1,  9,2,3,  5,8,7},

    new int[] {8,7,6,  3,9,4,  2,1,5},
    new int[] {2,4,3,  5,6,1,  9,7,8},
    new int[] {1,9,5,  2,8,7,  6,3,4}
};


int[][] goodSudoku2 = {
    new int[] {1,4, 2,3},
    new int[] {3,2, 4,1},

    new int[] {4,1, 3,2},
    new int[] {2,3, 1,4}
};

int[][] badSudoku1 =  {
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},

    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},

    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9}
};

int[][] badSudoku2 = {
    new int[] {1,2,3,4,5},
    new int[] {1,2,3,4},
    new int[] {1,2,3,4},  
    new int[] {1}
};
Debug.Assert(ValidateSudoku(goodSudoku1), "This is supposed to validate! It's a good sudoku!");
Debug.Assert(ValidateSudoku(goodSudoku2), "This is supposed to validate! It's a good sudoku!");
Debug.Assert(!ValidateSudoku(badSudoku1), "This isn't supposed to validate! It's a bad sudoku!");
Debug.Assert(!ValidateSudoku(badSudoku2), "This isn't supposed to validate! It's a bad sudoku!");
static bool ValidateSudoku(int[][] sudoku)
{
    
    var mainList = sudoku.Select(i=> i.ToList()).ToList();
    var count = mainList.Count;
    if (count == 0)
    {
        Console.WriteLine("Input is 0");
        return false;
    }else if (count>9)
    {
        Console.WriteLine("Input is out of bounds");
        return false;
    }

    var sqrt = Math.Sqrt(count);
    bool isRootInteger = sqrt % 1 == 0;
    if (!isRootInteger)
    {
        Console.WriteLine($"Square root of {count} is not integer");
        return false;
    }

    for (int i = 0; i < mainList.Count; i++)
    {
        var row = new List<int>();
        var column = new List<int>();
        for (int j = 0; j < mainList.Count; j++)
        {
            row.Add(sudoku[i][j]);
            column.Add(sudoku[j][i]);
        }

        if (row.Distinct().ToList().Count != row.Count||row.Max()>row.Count)
        {
            Console.WriteLine("This isn't supposed to validate! It's a bad sudoku!");
            return false;
        }
        if (column.Distinct().ToList().Count != column.Count||column.Max()>column.Count)
        {
            Console.WriteLine("This isn't supposed to validate! It's a bad sudoku!");
            return false;
        }
    }

    for(int i = 0; i < mainList.Count - (int)sqrt+1; i += (int)sqrt)
    {
        for(int j = 0; j < mainList.Count - (int)sqrt+1; j += (int)sqrt)
        {
            var intList = new List<int>();
            for(int k = 0; k < (int)sqrt; k++)
            {
                for(int l = 0; l < (int)sqrt; l++)
                {
                    int x = i + k;
                    int y = j + l;
                    int z = sudoku[x][y];
                    if (intList.Contains(z))
                    {
                        Console.WriteLine("This isn't supposed to validate! It's a bad sudoku!");
                        return false;
                    }
                    else
                    {
                        intList.Add(z);
                    }
                }
            }
        }
    }

    Console.WriteLine("This is supposed to validate! It's a good sudoku!");
    return true;
}
