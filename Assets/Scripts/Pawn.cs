using UnityEngine;
using UnityEngine.EventSystems;

public class Pawn : Pice, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    bool isFirstMovement = true;

    public override void OnPointerClick(PointerEventData eventData)
    {
        CheckMovements();
        CheckEat();
    }

    public void CheckMovements()
    {
        int movement = +1;
        int x = (int)transform.position.x;
        int z = (int)transform.position.z;

        if (color == EColorType.Black)
            movement = -1;
        Square targetPice = board.GetSquare(x, z + movement);
        if (targetPice == null)
            return;
        if (targetPice.pice == null)
            targetPice.Select(this, false);
        if(isFirstMovement)
        {
            targetPice = board.GetSquare(x, z + (movement * 2));
            if (targetPice == default)
                return;
            if (targetPice.pice == default)
                targetPice.Select(this, false);
        }
    }

    public void CheckEat()
    {
        
            

        int movement = +1;
        int x = (int)transform.position.x;
        int z = (int)transform.position.z;

        if ((color == EColorType.Black && z < 1) || (color == EColorType.White && z > 6))
            return;

        if (color == EColorType.Black)
        movement = -1;
        //Left
        Square targetSquare;
        if (x != 0)
        {
            targetSquare = board.GetSquare(x - 1, z + movement);
            if(CheckCanEat(targetSquare))
                targetSquare.Select(this, true);
        }
        //Right
        if (x != 7)
        {
            targetSquare = board.GetSquare(x + 1, z + movement);
            if (CheckCanEat(targetSquare))
                targetSquare.Select(this, true);
        }
    }
}
