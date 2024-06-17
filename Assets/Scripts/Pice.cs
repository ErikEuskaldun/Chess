using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pice : MonoBehaviour
{
    public Material defaultMaterial, selectedMaterial;
    public EColorType color;
    public EPiceType piceType = EPiceType.Null;
    public List<Square> selectedSquares = new List<Square>();

    protected MeshRenderer meshRenderer;
    protected Board board;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        board = FindAnyObjectByType<Board>();
    }

    public void InstantiatePice(EColorType color, Material material, EPiceType piceType)
    {
        this.color = color;
        defaultMaterial = material;
        this.piceType = piceType;
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    public bool CheckCanEat(Square square)
    {
        if (square.pice != null)
            if (square.pice.color != this.color)
                return true;
        return false;
    }

    public void DeselectSquares()
    {
        foreach (Square square in selectedSquares)
            square.Deselect();
    }

    public void CanBeSelected(bool canBeSelected)
    {
        GetComponent<Collider>().enabled = canBeSelected ? true : false;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Not Implemented Click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material = selectedMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material = defaultMaterial;
    }
}

public enum EPiceType
{
    Null, King, Knight, Pawn, Pishop, Queen, Rook
}
