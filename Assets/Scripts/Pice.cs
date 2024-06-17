using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pice : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Material defaultMaterial, selectedMaterial;
    public EColorType color;
    MeshRenderer meshRenderer;

    public void InstantiatePice(EColorType color, Material material)
    {
        this.color = color;
        defaultMaterial = material;
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    public void CanBeSelected(bool canBeSelected)
    {
        GetComponent<Collider>().enabled = canBeSelected ? true : false;
    }
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
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
