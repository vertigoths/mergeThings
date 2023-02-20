using System;
using TMPro;
using UnityEngine;

public class Item : Movable
{
    public int Rank { get; private set; }
    private TMP_Text _rankText;

    public void SetRank(int rank)
    {
        Rank = rank;
        
        _rankText = GetComponentInChildren<TMP_Text>();
        _rankText.text = Rank.ToString();
    }
}