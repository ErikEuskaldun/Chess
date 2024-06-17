using UnityEngine;

public static class ChessUtils
{
    public static string ConvertWorldPositionToChessNaming(int x, int z)
    {
        return ((char)(97 + x)) + "" + (z+1);
    }
}
