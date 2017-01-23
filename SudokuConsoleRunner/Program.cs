using System;
using Sudoku;
using Sudoku.Board;

class Program
{
    static void Main(string[] args)
    {
        var builder = SudokuFactory.CreateBuilder(BoardLevel.Easy);
        Console.WriteLine("Board:");
        Console.WriteLine(builder.GenerateFilledBoard());
    }
}