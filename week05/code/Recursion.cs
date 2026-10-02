using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// Find the sum of 1^2 + 2^2 + 3^2 + ... + n^2 using recursion.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Insert all permutations of the requested size into results.
    /// </summary>
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remainingLetters =
                letters[..i] + letters[(i + 1)..];

            PermutationsChoose(
                results,
                remainingLetters,
                size,
                word + letters[i]);
        }
    }

    /// <summary>
    /// Count the number of ways to climb s stairs using
    /// steps of one, two, or three stairs.
    /// </summary>
    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        if (s <= 0)
        {
            return 0;
        }

        if (s == 1)
        {
            return 1;
        }

        if (s == 2)
        {
            return 2;
        }

        if (s == 3)
        {
            return 4;
        }

        remember ??= new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        decimal ways =
            CountWaysToClimb(s - 1, remember)
            + CountWaysToClimb(s - 2, remember)
            + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Insert all possible binary strings represented by a wildcard pattern.
    /// </summary>
    public static void WildcardBinary(
        string pattern,
        List<string> results)
    {
        int wildcardIndex = pattern.IndexOf('*');

        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        string zeroPattern =
            pattern[..wildcardIndex]
            + "0"
            + pattern[(wildcardIndex + 1)..];

        string onePattern =
            pattern[..wildcardIndex]
            + "1"
            + pattern[(wildcardIndex + 1)..];

        WildcardBinary(zeroPattern, results);
        WildcardBinary(onePattern, results);
    }

    /// <summary>
    /// Insert all paths from (0,0) to the end of the maze.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        currPath ??= new List<ValueTuple<int, int>>();

        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        SolveMaze(results, maze, x + 1, y, currPath);
        SolveMaze(results, maze, x - 1, y, currPath);
        SolveMaze(results, maze, x, y + 1, currPath);
        SolveMaze(results, maze, x, y - 1, currPath);

        currPath.RemoveAt(currPath.Count - 1);
    }
}