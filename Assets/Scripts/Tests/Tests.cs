using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    List<Test> tests = new List<Test>();

    private void Awake()
    {
        tests.Add(new CardTest());
    }

    private void Start()
    {
        foreach(var test in tests)
        {
            var result = test.Execute();
            Debug.Log($"Test {test} Result: {result}");
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
            if (card.Symbol == CardSymbol.None || card.Rank == CardRank.None)
            {
                return false;
            }
        }
        return true;
    }
}
