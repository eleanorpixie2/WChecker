using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckValidMove(Piece pieceToMove,BoardSpace spaceToMove)
    {
        bool valid = false;
        if (pieceToMove.currentSpace.location.x + 1 == spaceToMove.location.x
            && pieceToMove.currentSpace.location.y == spaceToMove.location.y)
        {
            if (spaceToMove.currentPiece == null)
            {
                valid = true;
            }
        }
        else if (pieceToMove.currentSpace.location.x -1 == spaceToMove.location.x 
            && pieceToMove.currentSpace.location.y==spaceToMove.location.y)
        {
            if (spaceToMove.currentPiece == null)
            {
                valid = true;
            }
        }
        else if (pieceToMove.currentSpace.location.x == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y-1 == spaceToMove.location.y)
        {
            if(pieceToMove.isKing && spaceToMove.currentPiece==null)
            {
                valid = true;
            }
        }
        else if (pieceToMove.currentSpace.location.x + 1 == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y+1 == spaceToMove.location.y)
        {
            if (spaceToMove.currentPiece == null)
            {
                valid = true;
            }
        }

        return valid;
    }
}
