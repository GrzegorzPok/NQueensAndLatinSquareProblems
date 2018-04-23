using System;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            Board backTrackingBoard, forwardCheckingBoard;
            for (int i = 1; i < 13; i++)
            {
                backTrackingBoard = new Board(i);
                forwardCheckingBoard = new Board(i);
                var backTrackingWatch = System.Diagnostics.Stopwatch.StartNew();
                backTrackingBoard.AddQueen_backtracking(0);
                
                var elapsedMsBT = backTrackingWatch.ElapsedTicks;
                backTrackingWatch.Stop();
                var ForwardCheckingWatch = System.Diagnostics.Stopwatch.StartNew();
                forwardCheckingBoard.AddQueen_forwardChecking(0);
                
                var elapsedMsFC = ForwardCheckingWatch.ElapsedTicks;
                ForwardCheckingWatch.Stop();
                Console.WriteLine(i + " BackTracking found: " + backTrackingBoard.found + " in " + elapsedMsBT + " returns " + backTrackingBoard.returns);
                Console.WriteLine(i + " ForwardChecking found: " + forwardCheckingBoard.found + " in " + elapsedMsFC + " returns " + forwardCheckingBoard.returns);
            }
        }
    }
}
