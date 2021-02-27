using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Util
{
    #region Strings
    private static Dictionary<CardSuit, string> _suitStrings = new Dictionary<CardSuit, string>()
    {
        { CardSuit.Club, "클로버" },
        { CardSuit.Diamond, "다이아몬드" },
        { CardSuit.Heart, "하트" },
        { CardSuit.Spade, "스페이드" },
    };

    private static Dictionary<CardRank, string> _rankStrings = new Dictionary<CardRank, string>()
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

    private static Dictionary<string, Sprite> _cardSprites = new Dictionary<string, Sprite>();

    public static string GetSymbolString(CardSuit suit)
    {
        if (_suitStrings.TryGetValue(suit, out var str))
        {
            return str;
        }

        Debug.LogWarning($"Symbol {suit}에 대응하는 텍스트가 없음");
        return "?";
    }

    public static string GetRankString(CardRank rank)
    {
        if (_rankStrings.TryGetValue(rank, out var str))
        {
            return str;
        }

        Debug.LogWarning($"Rank {rank}에 대응하는 텍스트가 없음");
        return "?";
    }

    public static Card GetRandomCard()
    {
        int value = Random.Range(0, 52);
        return new Card(value + 1);
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

    public static Sprite GetCardFrontSprite(Card card)
    {
        Sprite sprite = null;
        var spriteName = card.ToSpriteString();
        if (_cardSprites.TryGetValue(spriteName, out sprite))
        {
            return sprite;
        }

        string path = $"Sprites";
        sprite = Resources.LoadAll<Sprite>(path)
            .SingleOrDefault(s => s.name == spriteName);

        _cardSprites.Add(spriteName, sprite);

        return sprite;
    }
}