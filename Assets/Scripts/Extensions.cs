// Created by Dr. Adam Streck, 2023, adam.streck@gmail.com


using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    private static readonly System.Random _rnd = new System.Random();

    // List shuffle extension
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        => source.OrderBy(_ => _rnd.Next());
}