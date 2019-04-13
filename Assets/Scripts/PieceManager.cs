using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    Board boardRef;
    public GameObject selectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        //boardRef = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
        selectedPiece = null;
    }

    
    // Update is called once per frame
    void Update()
    {
        CheckForClick();
    }

    private void CheckForClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && selectedPiece == null)
            {
                if (hit.collider.gameObject.tag == "Player")
                    selectedPiece = hit.collider.gameObject;
            }
            else if (Physics.Raycast(ray, out hit))
            {
                BoardSpace space = hit.collider.gameObject.GetComponent<BoardSpace>();
                if (space)
                {
                    Piece _selected = selectedPiece.GetComponent<Piece>();
                    if (CheckValidMove(_selected, space))
                    {
                        selectedPiece.transform.position = hit.collider.gameObject.GetComponent<BoxCollider>().transform.position;
                        //get old space
                        BoardSpace current = _selected.currentSpace;
                        //set new space
                        _selected.currentSpace = space;
                        //set the current piece for the space
                        space.SetCurrentPiece(selectedPiece);
                        //reset the current piece for the old space
                        current.SetCurrentPiece();
                        selectedPiece = null;
                    }
                }
                else
                {
                    selectedPiece = null;
                }


            }
            else
            {
                selectedPiece = null;
            }
        }
    }

    public bool CheckValidMove(Piece pieceToMove, BoardSpace spaceToMove)
    {
        bool valid = false;
        //upper left
        if (pieceToMove.currentSpace.location.x - 1 == spaceToMove.location.x
            && pieceToMove.currentSpace.location.y - 1 == spaceToMove.location.y)
        {
            if (pieceToMove._color == SpaceColor.white)
            {
                if (pieceToMove.isKing && spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
            else
            {
                if (spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
        }
        //upper right
        else if (pieceToMove.currentSpace.location.x - 1 == spaceToMove.location.x
            && pieceToMove.currentSpace.location.y + 1 == spaceToMove.location.y)
        {
            if (pieceToMove._color == SpaceColor.black)
            {
                if (pieceToMove.isKing && spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
            else
            {
                if (spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
        }
        //lower left
        else if (pieceToMove.currentSpace.location.x + 1 == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y - 1 == spaceToMove.location.y)
        {
            if (pieceToMove._color == SpaceColor.white)
            {
                if (pieceToMove.isKing && spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
            else
            {
                if (spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
        }
        //lower right
        else if (pieceToMove.currentSpace.location.x + 1 == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y + 1 == spaceToMove.location.y)
        {
            if (pieceToMove._color == SpaceColor.black)
            {
                if (pieceToMove.isKing && spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
            else
            {
                if (spaceToMove.currentPiece == null)
                {
                    valid = true;
                }
            }
        }

        return valid;
    }
}
