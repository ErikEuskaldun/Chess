using UnityEngine;
using UnityEngine.EventSystems;

public class Square : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string squareName = "null";
    public Material defaultMaterial, selectedMaterial, eatMaterial;
    [SerializeField] MeshRenderer meshRenderer;
    public Pice pice = null;
    public Pice piceToMove = null;
    public bool selected = false;
    Board board;

    public void Instantiate(Board board)
    {
        this.board = board;
    }

    public void Select(Pice piceToMove, bool canEat)
    {
        selected = true;
        meshRenderer.material = canEat ? eatMaterial : selectedMaterial;
        this.piceToMove = piceToMove;
        piceToMove.selectedSquares.Add(this);
    }

    public void Deselect()
    {
        selected = false;
        meshRenderer.material = defaultMaterial;
        this.piceToMove = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!selected)
            return;
        board.GetSquare((int)piceToMove.transform.position.x, (int)piceToMove.transform.position.z).pice = null;
        if(pice!=null)
            Destroy(pice.gameObject);
        pice = piceToMove;
        pice.transform.position = new Vector3(this.transform.position.x, pice.transform.position.y, this.transform.position.z);
        pice.DeselectSquares();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //meshRenderer.material = selectedMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //meshRenderer.material = defaultMaterial;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }
}
