using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets

{
  class Lucky : ITask
  {
    public string Run(string[] data)
    {
      int N = Convert.ToInt32(data[0]);
      int answer = GetLuckyCount(N);
      return answer.ToString();
    }

    int GetLuckyCount(int N)
    {
      int possibleSumsCount = N * 9 + 1;
      int iterationCount = (possibleSumsCount) / 2;
      int oneHalf = 0;
      for(int Index=0; Index<iterationCount; Index++)
      {
        int r = GetCombinationCount(N, Index);
        Console.WriteLine($"r=" + r.ToString());
        oneHalf +=  r * r;
      } 
      Console.WriteLine($"half=" + oneHalf.ToString());
      int middle = 0;
      bool odd = (possibleSumsCount & 1) != 0;
      if(odd)
      {
        middle = GetCombinationCount(N, iterationCount) ^ 2;
        Console.WriteLine($"midline=" + middle.ToString());
      }
      
      int answer = oneHalf * 2 + middle;
      return answer;
    }

    int GetCombinationCount(int digitsCount, int sum)
    {
      if(digitsCount == 1)
      {
        return 1;
      }
      else
      { 
        if(sum == 0)
        {
          return 1;
        }
        else
        {
          return digitsCount * sum;
        }
      }
    }
  }
}

/*
N = 1
S:
0   0  : 1
1   1  : 1
2   2  : 1
3   3  : 1
4   4  : 1
5   5  : 1
6   6  : 1
7   7  : 1
8   8  : 1
9   9  : 1
*/

/*
N = 2
S:                                  C   C^2 Total
0   00                            : 1   1   \
1   01 10                         : 2   4   |
2   02 11 20                      : 3   9   |
3   03 12 21 30                   : 4   16  |
4   04 13 22 31 40                : 5   25  | 285 * 2 + $ = 670 - THE RIGHT ANSWER!
5   05 14 23 32 41 50             : 6   36  |           |
6   06 15 24 33 42 51 60          : 7   49  |           |
7   07 16 25 34 43 52 61 70       : 8   64  |           |
8   08 17 26 35 44 53 62 71 80    : 9   81  /           |
9   09 18 27 36 45 54 63 72 81 90 : 10  100 ------------+
10  19 28 37 46 55 64 73 82 91    : 9       .
11  29 38 47 56 65 74 83 92       : 8       .
12  39 48 57 66 75 84 93          : 7
13  49 58 67 76 85 94             : 6
14  59 68 77 86 95                : 5
15  69 78 87 96                   : 4
16  79 88 97                      : 3
17  89 98                         : 2
18  99                            : 1
*/

/*
N = 3
S:
0     00                                                                      : 1
1     001 010 100                                                             : 3
2     002 011 020 101 110 200                                                 : 6
3     003 030 300 012 102 120 021 201 210                                     : 9
4     004 040 400 013 103 130 031 301 310 022 202 220                         : 12
5     005 050 500 014 104 140 023 203 230 032 302 320 041 401 410             : 15
6     006 060 600 015 105 150 024 204 240 033 303 330 042 402 420 051 501 510 : 18
7     07 16 25 34 43 52 61 70                                                 : 21
8     08 17 26 35 44 53 62 71 80                                              : 24
9     09 18 27 36 45 54 63 72 81 90                                           : 27
10    19 28 37 46 55 64 73 82 91                                              : 30
11    29 38 47 56 65 74 83 92                                                 : 33
12                                                                            : 36
13                                                                            : 39
14                                                                            : 39
15                                                                            : 36
16                                                                            : 33
17                                                                            : 30
18                                                                            : 27
19                                                                            : 24
20                                                                            : 21
21                                                                            : 18
22                                                                            : 15
23                                                                            : 12
24                                                                            : 9
25                                                                            : 6
26                                                                            : 3
27                                                                            : 1
*/

/*
  666
  765
  864
  963
*/