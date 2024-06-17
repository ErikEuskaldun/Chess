using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public EColorType color;
    public Material material;
    public List<Pice> pices = new List<Pice>();
    void Start()
    {
        
    }

    public void AddPice(Pice pice)
    {
        pice.InstantiatePice(color, material);
        pices.Add(pice);
    }

    public void IsPlayerTurn(bool isPlayerTurn)
    {
        foreach (Pice pice in pices)
        {
            pice.CanBeSelected(isPlayerTurn);
        }
    }
}
