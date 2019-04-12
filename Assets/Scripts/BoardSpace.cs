using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum SpaceColor { black,white};
public class BoardSpace : MonoBehaviour
{
    public GameObject currentPiece { get; private set; }
    public SpaceColor _spaceColor;
    public Vector2 location;

    public void SetInital(SpaceColor color, Vector2 loc)
    {
        _spaceColor = color;
        location = loc;
    }

    public void SetCurrentPiece(GameObject piece=null)
    {
        if(piece!=null)
        {
            currentPiece = piece;
        }
        else
        {
            currentPiece = null;
        }
    }


}
