using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum
{
    public int CardIndex { get; private set; }
    public List<Card> Cards { get; private set; }
    public bool Keep { get; private set; }

    public Card CurrentCard
    {
        get => Cards[CardIndex];
    }

    public Drum(List<Card> cards)
    {
        CardIndex = 0;
        Cards = cards;
        Keep = false;
    }

    public void SetRandomCard()
    {
        if (Keep)
        {
            return;
        }

        CardIndex = Random.Range(0, Cards.Count);
    }
}
