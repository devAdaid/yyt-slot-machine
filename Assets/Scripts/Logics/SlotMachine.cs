using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlotMachine
{
    public static readonly int DRUM_COUNT = 5;
    public static readonly int CARD_COUNT_PER_DRUM = 10;

    public Drum[] Drums = new Drum[DRUM_COUNT];

    private readonly Card SPADE_TEN = new Card(CardSuit.Spade, CardRank.Ten);
    private readonly Card HEART_JACK = new Card(CardSuit.Heart, CardRank.Jack);

    public SlotMachine()
    {
        Initialize();
    }

    public void ShffleDrums()
    {
        Initialize();
    }

    public void DrawCards()
    {
        foreach (var drum in Drums)
        {
            drum.SetRandomCard();
        }
    }

    private void Initialize()
    {
        IEnumerable<int> cardValues = GetShuffledAllCardValues();

        for (int i = 0; i < DRUM_COUNT; i++)
        {
            var cards = cardValues.Take(CARD_COUNT_PER_DRUM)
                .Select(value => new Card(value))
                .ToList();

            Drums[i] = new Drum(cards);

            cardValues = cardValues.Skip(CARD_COUNT_PER_DRUM);
        }
    }

    private List<Card> GetRandomCards(int count, List<int> removeCardValues)
    {
        var candidateValues = GetShuffledAllCardValues();
        foreach (var removeValue in removeCardValues)
        {
            candidateValues.Remove(removeValue);
        }

        return candidateValues.Take(count)
            .Select(value => new Card(value))
            .ToList();
    }

    private List<int> GetShuffledAllCardValues()
    {
        var entireCardValues = Enumerable.Range(1, 52).ToList();
        entireCardValues.Remove(SPADE_TEN.Value);
        entireCardValues.Remove(HEART_JACK.Value);
        entireCardValues.Shuffle();
        return entireCardValues;
    }
}
