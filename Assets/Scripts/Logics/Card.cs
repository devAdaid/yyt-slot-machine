using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CardSymbol
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
    public CardSymbol Symbol;
    public CardRank Rank;

    public int Value
    {
        get
        {
            return CardToValue(Symbol, Rank);
        }
    }

    public Card(CardSymbol symbol, CardRank rank)
    {
        Symbol = symbol;
        Rank = rank;
    }

    public Card(int value)
    {
        if (value < 1 || value > 52)
        {
            Symbol = CardSymbol.None;
            Rank = CardRank.None;
        }
        else
        {
            Symbol = (CardSymbol)((value - 1) % 4 + 1);
            Rank = (CardRank)((value - 1) / 4 + 1);
        }
    }

    public static int CardToValue(CardSymbol symbol, CardRank rank)
    {
        int baseValue = ((int)rank - 1) * 4;
        int addValue = (int)symbol - 1;
        return baseValue + addValue;
    }

    public override string ToString()
    {
        return $"{Util.GetSymbolString(Symbol)} {Util.GetRankString(Rank)}";
    }

    public int CompareTo(Card other)
    {
        return Value.CompareTo(other.Value);
    }
}