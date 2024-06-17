using UnityEngine;
using UnityEngine.EventSystems;

public class Square : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string squareName = "null";
    public Material defaultMaterial, selectedMaterial;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material = selectedMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material = defaultMaterial;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }
}
