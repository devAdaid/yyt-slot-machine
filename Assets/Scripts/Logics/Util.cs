using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Util
{
    #region Strings
    private static Dictionary<CardSymbol, string> symbolStrings = new Dictionary<CardSymbol, string>()
    {
        { CardSymbol.Club, "클로버" },
        { CardSymbol.Diamond, "다이아몬드" },
        { CardSymbol.Heart, "하트" },
        { CardSymbol.Spade, "스페이드" },
    };

    private static Dictionary<CardRank, string> rankStrings = new Dictionary<CardRank, string>()
    {
        { CardRank.Two, "2" },
        { CardRank.Three, "3" },
        { CardRank.Four, "4" },
        { CardRank.Five, "5" },
        { CardRank.Six, "6" },
        { CardRank.Seven, "7" },
        { CardRank.Eight, "8" },
        { CardRank.Nine, "9" },
        { CardRank.Ten, "10" },
        { CardRank.Jack, "J" },
        { CardRank.Queen, "Q" },
        { CardRank.King, "K" },
        { CardRank.Ace, "A" },
    };
    #endregion

    public static string GetSymbolString(CardSymbol symbol)
    {
        if (symbolStrings.TryGetValue(symbol, out var str))
        {
            return str;
        }

        Debug.LogWarning($"Symbol {symbol}에 대응하는 텍스트가 없음");
        return "?";
    }

    public static string GetRankString(CardRank rank)
    {
        if (rankStrings.TryGetValue(rank, out var str))
        {
            return str;
        }

        Debug.LogWarning($"Rank {rank}에 대응하는 텍스트가 없음");
        return "?";
    }

    public static void Shuffle<T>(this List<T> list)
    {
        int count = list.Count;
        for(int i = 0; i < count; i++)
        {
            var targetIndex = UnityEngine.Random.Range(0, list.Count);
            list.Swap(i, targetIndex);
        }
    }

    public static void Swap<T>(this List<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }
}