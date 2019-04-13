using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    Board boardRef;
    public GameObject selectedPiece;
    public PlayerManager playerManager;
    public GameObject kingWhite;
    public GameObject kingBlack;
    // Start is called before the first frame update
    void Start()
    {
        boardRef = GetComponent<Board>();
        boardRef.SpawnPieces();
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
                    BoardSpace current = _selected.currentSpace;
                    if (CheckValidMove(_selected, space))
                    {
                        _selected = selectedPiece.GetComponent<Piece>();
                        selectedPiece.transform.position = hit.collider.gameObject.GetComponent<BoxCollider>().transform.position;
                        //get old space
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
        //check to see if the distance from player is correct
        if (pieceToMove.currentSpace.location.x - 1 == spaceToMove.location.x
            && pieceToMove.currentSpace.location.y - 1 == spaceToMove.location.y)
        {
            //check for which way it is moving so that it can't go backwards
            if (pieceToMove._color == SpaceColor.white )
            {
                //only move if the piece is a king and the space is empty
                if (pieceToMove.isKing && spaceToMove.currentPiece == null && playerManager.currentTurn == colorTurn.white)
                {
                    valid = true;
                    playerManager.currentTurn = colorTurn.black;
                }
            }
            else
            {
                //move forward if the space is empty
                if (spaceToMove.currentPiece == null && playerManager.currentTurn == colorTurn.black)
                {
                    valid = true;
                    playerManager.currentTurn = colorTurn.white;
                    if (spaceToMove.location.y == 0 && !pieceToMove.isKing)
                    {
                        KingPiece(selectedPiece);
                    }
                }
            }
        }
        //upper right
        //check to see if the distance from player is correct
        else if (pieceToMove.currentSpace.location.x - 1 == spaceToMove.location.x
            && pieceToMove.currentSpace.location.y + 1 == spaceToMove.location.y)
        {
            //check for which way it is moving so that it can't go backwards
            if (pieceToMove._color == SpaceColor.black )
            {
                //only move if the piece is a king and the space is empty
                if (pieceToMove.isKing && spaceToMove.currentPiece == null && playerManager.currentTurn == colorTurn.black)
                {
                    valid = true;
                    playerManager.currentTurn = colorTurn.white;
                }
            }
            else
            {
                //move forward if the space is empty
                if (spaceToMove.currentPiece == null && playerManager.currentTurn == colorTurn.white)
                {
                    valid = true;
                    playerManager.currentTurn = colorTurn.black;
                    if (spaceToMove.location.y == 7 && !pieceToMove.isKing)
                    {
                        KingPiece(selectedPiece);
                    }
                }
            }
        }
        //lower left
        //check to see if the distance from player is correct
        else if (pieceToMove.currentSpace.location.x + 1 == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y - 1 == spaceToMove.location.y)
        {
            //check for which way it is moving so that it can't go backwards
            if (pieceToMove._color == SpaceColor.white)
            {
                if (playerManager.currentTurn == colorTurn.white)
                {
                    //only move if the piece is a king and the space is empty
                    if (pieceToMove.isKing && spaceToMove.currentPiece == null)
                    {
                        valid = true;
                        playerManager.currentTurn = colorTurn.black;
                    }
                }
            }
            else
            {
                //move forward if the space is empty
                if (spaceToMove.currentPiece == null && playerManager.currentTurn == colorTurn.black)
                {
                    valid = true;
                    playerManager.currentTurn = colorTurn.white;
                    if (spaceToMove.location.y == 0 && !pieceToMove.isKing)
                    {
                        KingPiece(selectedPiece);
                    }
                }
            }
        }
        //lower right
        //check to see if the distance from player is correct
        else if (pieceToMove.currentSpace.location.x + 1 == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y + 1 == spaceToMove.location.y)
        {
            //check for which way it is moving so that it can't go backwards
            if (pieceToMove._color == SpaceColor.black)
            {
                //only move if the piece is a king and the space is empty
                if (pieceToMove.isKing && spaceToMove.currentPiece == null && playerManager.currentTurn == colorTurn.black)
                {
                    valid = true;
                    playerManager.currentTurn = colorTurn.white;
                }
            }
            else
            {
                //move forward if the space is empty
                if (spaceToMove.currentPiece == null && playerManager.currentTurn == colorTurn.white)
                {
                    valid = true;
                    playerManager.currentTurn = colorTurn.black;
                    if (spaceToMove.location.y == 7 && !pieceToMove.isKing)
                    {
                        KingPiece(selectedPiece);
                    }
                }
            }
        }
        //lower right-2 spaces
        //check diagonal 2 spaces from piece
        else if (pieceToMove.currentSpace.location.x + 2 == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y + 2 == spaceToMove.location.y)
        {
            //check if the space inbetween has a piece on it
            BoardSpace checkSpace = FindSpace((int)spaceToMove.location.x - 1, (int)spaceToMove.location.y - 1).GetComponent<BoardSpace>();
            if (checkSpace != null)
            {
                if (checkSpace.currentPiece != null && spaceToMove.currentPiece == null)
                {
                    //check direction and back only if king
                    if (pieceToMove._color == SpaceColor.black )
                    {
                        if (pieceToMove.isKing && playerManager.currentTurn == colorTurn.black)
                        {
                            if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color)
                            {
                                valid = true;
                                playerManager.currentTurn = colorTurn.white;
                                playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(), checkSpace);
                            }
                        }
                    }
                    else
                    {
                        //check to make sure that the pieces aren't of the same color
                        if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color && playerManager.currentTurn == colorTurn.white)
                        {
                            valid = true;
                            playerManager.currentTurn = colorTurn.black;
                            playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(), checkSpace);
                            if (spaceToMove.location.y == 7 && !pieceToMove.isKing)
                            {
                                KingPiece(selectedPiece);
                            }
                        }

                    }

                }
            }
            else
            {
                print("Null space");
            }
        }
        //lower left-2 spaces
        //check diagonal 2 spaces from piece
        else if (pieceToMove.currentSpace.location.x + 2 == spaceToMove.location.x
        && pieceToMove.currentSpace.location.y - 2 == spaceToMove.location.y)
        {
            //check if the space inbetween has a piece on it
            BoardSpace checkSpace = FindSpace((int)spaceToMove.location.x - 1, (int)spaceToMove.location.y + 1).GetComponent<BoardSpace>();
            if (checkSpace != null)
            {
                if (checkSpace.currentPiece != null && spaceToMove.currentPiece == null)
                {
                    //check direction and back only if king
                    if (pieceToMove._color == SpaceColor.white )
                    {
                        if (pieceToMove.isKing && playerManager.currentTurn == colorTurn.white)
                        {
                            if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color)
                            {
                                valid = true;
                                playerManager.currentTurn = colorTurn.black;
                                playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(), checkSpace);
                            }
                        }
                    }
                    else
                    {
                        //check to make sure that the pieces aren't of the same color
                        if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color && playerManager.currentTurn == colorTurn.black)
                        {
                            valid = true;
                            playerManager.currentTurn = colorTurn.white;
                            playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(),checkSpace);
                            if (spaceToMove.location.y == 0 && !pieceToMove.isKing)
                            {
                                KingPiece(selectedPiece);
                            }
                        }

                    }

                }
            }
        }
        //upper right-2 spaces
        //check diagonal 2 spaces from piece
        else if (pieceToMove.currentSpace.location.x - 2 == spaceToMove.location.x
            && pieceToMove.currentSpace.location.y + 2 == spaceToMove.location.y)
        {
            //check if the space inbetween has a piece on it
            BoardSpace checkSpace = FindSpace((int)spaceToMove.location.x + 1, (int)spaceToMove.location.y - 1).GetComponent<BoardSpace>();
            if (checkSpace != null)
            {
                if (checkSpace.currentPiece != null && spaceToMove.currentPiece == null)
                {
                    //check direction and back only if king
                    if (pieceToMove._color == SpaceColor.black)
                    {
                        if (pieceToMove.isKing && playerManager.currentTurn == colorTurn.black)
                        {
                            if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color)
                            {
                                valid = true;
                                playerManager.currentTurn = colorTurn.white;
                                playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(), checkSpace);
                            }
                        }
                    }
                    else
                    {
                        //check to make sure that the pieces aren't of the same color
                        if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color && playerManager.currentTurn == colorTurn.white)
                        {
                            valid = true;
                            playerManager.currentTurn = colorTurn.black;
                            playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(), checkSpace);
                            if (spaceToMove.location.y == 7 && !pieceToMove.isKing)
                            {
                                KingPiece(selectedPiece);
                            }
                        }

                    }

                }
            }

        }
        //upper left-2 spaces
        //check diagonal 2 spaces from piece
        else if (pieceToMove.currentSpace.location.x - 2 == spaceToMove.location.x
            && pieceToMove.currentSpace.location.y - 2 == spaceToMove.location.y)
        {
            //check if the space inbetween has a piece on it
            BoardSpace checkSpace = FindSpace((int)spaceToMove.location.x + 1, (int)spaceToMove.location.y + 1).GetComponent<BoardSpace>();
            if (checkSpace != null)
            {
                if (checkSpace.currentPiece != null && spaceToMove.currentPiece == null)
                {
                    //check direction and back only if king
                    if (pieceToMove._color == SpaceColor.white)
                    {
                        if (pieceToMove.isKing && playerManager.currentTurn == colorTurn.white)
                        {
                            if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color)
                            {
                                valid = true;
                                playerManager.currentTurn = colorTurn.black;
                                playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(), checkSpace);
                            }
                        }
                    }
                    else
                    {
                        //check to make sure that the pieces aren't of the same color
                        if (checkSpace.currentPiece.GetComponent<Piece>()._color != selectedPiece.GetComponent<Piece>()._color && playerManager.currentTurn == colorTurn.black)
                        {
                            valid = true;
                            playerManager.currentTurn = colorTurn.white;
                            playerManager.RemovePieceFromBoard(checkSpace.currentPiece.GetComponent<Piece>(), checkSpace);
                            if (spaceToMove.location.y == 0 && !pieceToMove.isKing)
                            {
                                KingPiece(selectedPiece);
                            }
                        }

                    }

                }
            }

        }

        //return if valid
        return valid;
    }

    void KingPiece(GameObject piece)
    {
        Piece p = piece.GetComponent<Piece>();
        if(p._color==SpaceColor.black)
        {
            Destroy(piece);
            GameObject kb = Instantiate(kingBlack);
            selectedPiece = kb;
        }
        else if (p._color == SpaceColor.white)
        {
            Destroy(piece);
            GameObject kb = Instantiate(kingWhite);
            selectedPiece = kb;
        }
    }

    //Find a gameobject that represnts a space on the grid
    GameObject FindSpace(int x,int y)
    {
        GameObject[] spaces = GameObject.FindGameObjectsWithTag("Space");
        GameObject temp = null;
        foreach(GameObject s in spaces)
        {
           if( s.GetComponent<BoardSpace>().location == new Vector2(x,y))
            {
                temp = s;
                break;
            }
        }
        return temp;
    }


}
