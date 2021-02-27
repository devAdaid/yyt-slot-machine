using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDrumEntry : MonoBehaviour
{
    public Image CardImage;
    public Text CurrentCardText;
    public Text AllCardText;

    public void SetEntry(Drum drum)
    {
        CardImage.sprite = Util.GetCardFrontSprite(drum.CurrentCard);
        CurrentCardText.text = drum.CurrentCard.ToString();

        string allCardString = string.Empty;
        foreach (var card in drum.Cards)
        {
            if (!string.IsNullOrEmpty(allCardString))
            {
                allCardString += System.Environment.NewLine;
            }

            allCardString += card.ToString();
        }

        AllCardText.text = allCardString;
    }
}
