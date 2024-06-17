using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public EColorType color;
    public Material material;
    public List<Pice> pices = new List<Pice>();
    [SerializeField] Board board;

    public void AddPice(Pice pice, EPiceType piceType)
    {
        pice.InstantiatePice(color, material, piceType);
        pices.Add(pice);
        board.GetSquare((int)pice.transform.position.x, (int)pice.transform.position.z).pice = pice;
    }

    public void IsPlayerTurn(bool isPlayerTurn)
    {
        foreach (Pice pice in pices)
        {
            pice.CanBeSelected(isPlayerTurn);
        }
    }
}
