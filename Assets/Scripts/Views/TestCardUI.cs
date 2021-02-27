using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCardUI : MonoBehaviour
{
    public SpriteRenderer FrontCardRenderer;
    public SpriteRenderer BackCardRenderer;

    public void SetFrontCardSprite(Sprite sprite)
    {
        FrontCardRenderer.sprite = sprite;
    }
}
