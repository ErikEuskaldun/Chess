using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject squarePrefab, pawnPice, kingPice, knightPice, pishopPice, queenPice, rookPice;
    [SerializeField] Material blackMat, whiteMat, selectedMat;
    void Start()
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
        GameObject instance;
        Quaternion rotate = Quaternion.LookRotation(-transform.forward, Vector3.up);
        //Pawn
        for (int x = 0; x < 8; x++)
        {
            instance = Instantiate(pawnPice, new Vector3(x, 0.125f, 6), Quaternion.identity, this.transform);
            instance.GetComponent<MeshRenderer>().material = blackMat;
            instance.GetComponent<Pice>().defaultMaterial = blackMat;

            instance = Instantiate(pawnPice, new Vector3(x, 0.125f, 1), Quaternion.identity, this.transform);
            instance.GetComponent<MeshRenderer>().material = whiteMat;
            instance.GetComponent<Pice>().defaultMaterial = whiteMat;
        }

        //King
        instance = Instantiate(kingPice, new Vector3(4, 0.125f, 7), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;

        instance = Instantiate(kingPice, new Vector3(4, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;

        //Knight
        instance = Instantiate(knightPice, new Vector3(1, 0.125f, 7), rotate, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;
        instance = Instantiate(knightPice, new Vector3(6, 0.125f, 7), rotate, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;

        instance = Instantiate(knightPice, new Vector3(1, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;
        instance = Instantiate(knightPice, new Vector3(6, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;

        //Pishop
        instance = Instantiate(pishopPice, new Vector3(2, 0.125f, 7), rotate, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;
        instance = Instantiate(pishopPice, new Vector3(5, 0.125f, 7), rotate, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;

        instance = Instantiate(pishopPice, new Vector3(2, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;
        instance = Instantiate(pishopPice, new Vector3(5, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;

        //Queen
        instance = Instantiate(queenPice, new Vector3(3, 0.125f, 7), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;

        instance = Instantiate(queenPice, new Vector3(3, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;

        //Rook
        instance = Instantiate(rookPice, new Vector3(0, 0.125f, 7), rotate, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;
        instance = Instantiate(rookPice, new Vector3(7, 0.125f, 7), rotate, this.transform);
        instance.GetComponent<MeshRenderer>().material = blackMat;
        instance.GetComponent<Pice>().defaultMaterial = blackMat;

        instance = Instantiate(rookPice, new Vector3(0, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;
        instance = Instantiate(rookPice, new Vector3(7, 0.125f, 0), Quaternion.identity, this.transform);
        instance.GetComponent<MeshRenderer>().material = whiteMat;
        instance.GetComponent<Pice>().defaultMaterial = whiteMat;
    }
}
