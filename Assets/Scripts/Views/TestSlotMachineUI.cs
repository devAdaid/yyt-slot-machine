using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlotMachineUI : MonoBehaviour
{
    public SlotMachine SlotMachine;
    public List<TestDrumEntry> DrumEntries = new List<TestDrumEntry>();

    private void Start()
    {
        SlotMachine = new SlotMachine();
        SetUI();
    }

    public void ShuffleDrums()
    {
        SlotMachine.ShffleDrums();
        SetUI();
    }

    public void DrawCards()
    {
        SlotMachine.DrawCards();
        SetUI();
    }

    private void SetUI()
    {
        for (int i = 0; i < SlotMachine.DRUM_COUNT; i++)
        {
            DrumEntries[i].SetEntry(SlotMachine.Drums[i]);
        }
    }
}
