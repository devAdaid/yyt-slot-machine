using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CardSuit
{
    None,

    Club,
    Diamond,
    Heart,
    Spade
}

public enum CardRank
{
    None,

    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

public struct Card : IComparable<Card>
{
    public CardSuit Suit;
    public CardRank Rank;

    public int Value
    {
        get
        {
            return GetCardValue(Suit, Rank);
        }
    }

    public Card(CardSuit suit, CardRank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public Card(int value)
    {
        if (value < 1 || value > 52)
        {
            Suit = CardSuit.None;
            Rank = CardRank.None;
        }
        else
        {
            Suit = (CardSuit)((value - 1) % 4 + 1);
            Rank = (CardRank)((value - 1) / 4 + 1);
        }
    }

    public static int GetCardValue(CardSuit suit, CardRank rank)
    {
        int baseValue = ((int)rank - 1) * 4;
        int addValue = (int)suit - 1;
        return baseValue + addValue;
    }

    public override string ToString()
    {
        return $"{Util.GetSymbolString(Suit)} {Util.GetRankString(Rank)}";
    }

    public string ToSpriteString()
    {
        return $"{Suit}_{Rank}";
    }

    public int CompareTo(Card other)
    {
        return Value.CompareTo(other.Value);
    }
}