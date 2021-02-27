using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCardFlip : MonoBehaviour
{
    public List<TestCardFlipEntry> Entries;
    public bool IsAutoFliping = false;

    private void Start()
    {
        foreach(var entry in Entries)
        {
            entry.SetFixCardSprite(Util.GetRandomCard());
        }
    }

    public void ShowFlipAt(int index)
    {
        Entries[index].ShowFlip(Util.GetRandomCard());
    }

    public void ShowAutoFlip()
    {
        IsAutoFliping = !IsAutoFliping;
        if (IsAutoFliping)
        {
            foreach (var entry in Entries)
            {
                entry.AutoFlip();
            }
        }
        else
        {
            foreach (var entry in Entries)
            {
                entry.IsAutoFliping = false;
            }
        }
    }
}
