using UnityEngine;
using UnityEngine.EventSystems;

public class Pice : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Material defaultMaterial, selectedMaterial;
    MeshRenderer meshRenderer;

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
