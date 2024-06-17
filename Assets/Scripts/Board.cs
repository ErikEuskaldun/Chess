using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject squarePrefab, pawnPice, kingPice, knightPice, pishopPice, queenPice, rookPice;
    [SerializeField] Player playerBlack, playerWhite;
    [SerializeField] Material blackMat, whiteMat;
    void Awake()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int z = 0; z < 8; z++)
            {
                GameObject instance = Instantiate(squarePrefab, new Vector3(x, 0, z), Quaternion.identity, this.transform);
                Material defaultMaterial = (z + x) % 2 == 0 ? blackMat : whiteMat;
                instance.GetComponent<MeshRenderer>().material = defaultMaterial;
                Square square = instance.GetComponent<Square>();
                square.squareName = ChessUtils.ConvertWorldPositionToChessNaming(x, z);
                square.defaultMaterial = defaultMaterial;
            }
        }

        GeneratePices();
    }

    private void GeneratePices()
    {
        Quaternion rotate = Quaternion.LookRotation(-transform.forward, Vector3.up);
        SpawnPices(playerWhite, 1, 0, Quaternion.identity);
        SpawnPices(playerBlack, 6, 7, rotate);
        TurnStart(EColorType.White);
    }

    public void TurnStart(EColorType color)
    {
        if (color == EColorType.White)
        {
            playerWhite.IsPlayerTurn(true);
            playerBlack.IsPlayerTurn(false);
        }
        else
        {
            playerWhite.IsPlayerTurn(false);
            playerBlack.IsPlayerTurn(true);
        }
    }

    public void SpawnPices(Player player, int pawnPosition, int backPosition, Quaternion rotation)
    {
        float y = 0.125f;
        Pice instance;
        //Pawn
        for (int x = 0; x < 8; x++)
        {
            instance = Instantiate(pawnPice, new Vector3(x, y, pawnPosition), rotation, this.transform).GetComponent<Pice>();
            player.AddPice(instance);
        }
        //King
        instance = Instantiate(kingPice, new Vector3(4, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
        //Knight
        instance = Instantiate(knightPice, new Vector3(1, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
        instance = Instantiate(knightPice, new Vector3(6, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
        //Pishop
        instance = Instantiate(pishopPice, new Vector3(2, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
        instance = Instantiate(pishopPice, new Vector3(5, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
        //Queen
        instance = Instantiate(queenPice, new Vector3(3, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
        //Rook
        instance = Instantiate(rookPice, new Vector3(0, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
        instance = Instantiate(rookPice, new Vector3(7, y, backPosition), rotation, this.transform).GetComponent<Pice>();
        player.AddPice(instance);
    }
}
