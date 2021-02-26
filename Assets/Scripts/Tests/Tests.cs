using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    List<Test> tests = new List<Test>();

    private void Awake()
    {
        tests.Add(new CardTest());
        tests.Add(new SpriteTest());
    }

    private void Start()
    {
        foreach(var test in tests)
        {
            var result = test.Execute();
            Debug.Log($"{test} Result: {result}");
        }
    }
}

public class CardTest : Test
{
    public override bool Execute()
    {
        for (int value = 1; value <= 52; value++)
        {
            Card card = new Card(value);
            if (card.Suit == CardSuit.None || card.Rank == CardRank.None)
            {
                return false;
            }
        }
        return true;
    }
}

public class SpriteTest : Test
{
    public override bool Execute()
    {
        for (int value = 1; value <= 52; value++)
        {
            Card card = new Card(value);
            if (Util.GetCardFrontSrite(card) == null)
            {
                Debug.Log($"SpriteTest Fail: {card}");
                return false;
            }
        }
        return true;
    }
}
