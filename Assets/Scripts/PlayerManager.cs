using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum colorTurn { black,white};
public class PlayerManager : MonoBehaviour
{
    //number of pieces on the board for each side
    public int numberOfWhitePiecesOnBoard;
    public int numberOfBlackPiecesOnBoard;
    //UI text
    public Text whiteNumTxt;
    public Text blackNumTxt;
    public Camera whitePiecesSide;
    public colorTurn currentTurn;
    // Start is called before the first frame update
    void Start()
    {
        //intialize number and text
        numberOfWhitePiecesOnBoard = 12;
        numberOfBlackPiecesOnBoard = 12;
        blackNumTxt.text = $"Black Left: {numberOfBlackPiecesOnBoard}";
        whiteNumTxt.text = $"White Left: {numberOfWhitePiecesOnBoard}";
        currentTurn = colorTurn.white;
        whitePiecesSide = Camera.main;
        currentPos = whitePiecesSide.transform.position;
        whiteSide = currentPos;
        blackSide = new Vector3(2.19f, 8.59f, 11.68f);
    }

    public float degrees = 0;
    public Vector3 currentPos;
    private Vector3 whiteSide;
    private Vector3 blackSide;

    // Update is called once per frame
    void Update()
    {
        //CameraRotation();
        //currentPos = whitePiecesSide.transform.position;

        if (numberOfBlackPiecesOnBoard <= 0)
        {
            //lose
        }
        else if (numberOfWhitePiecesOnBoard <= 0)
        {
            //lose
        }
        //if(currentTurn==colorTurn.white)
        //{
        //    //whitePiecesSide.enabled = true;
        //    //blackPiecesSide.enabled = false;
        //    //whitePiecesSide.transform.RotateAround(Vector3.zero, Vector3.up, degrees);
        //}
        //else if (currentTurn == colorTurn.black)
        //{
        //    //whitePiecesSide.enabled = false;
        //    //blackPiecesSide.enabled = true;
        //}
    }

    private void CameraRotation()
    {
        degrees = 20 * Time.deltaTime;

        if (currentTurn == colorTurn.white)
        {
            whitePiecesSide.transform.RotateAround(new Vector3(2.13f, 0), Vector3.up, degrees);
        }
        else if (currentTurn == colorTurn.black)
        {
            whitePiecesSide.transform.RotateAround(new Vector3(2.13f, 0), Vector3.up, degrees);
        }
    }

    public void RemovePieceFromBoard(Piece bp, BoardSpace bs)
    {
        //if black then decrease the number of pieces and update text accordingly
        if(bp._color==SpaceColor.black)
        {
            numberOfBlackPiecesOnBoard--;
            Destroy(bp.gameObject);
            bs.SetCurrentPiece();
            UpdateText();
        }
        //if white then decrease the number of pieces and update text accordingly
        else if(bp._color==SpaceColor.white)
        {
            numberOfWhitePiecesOnBoard--;
            Destroy(bp.gameObject);
            bs.SetCurrentPiece();
            UpdateText();
        }
    }

    public void UpdateText()
    {
        blackNumTxt.text = $"Black Left: {numberOfBlackPiecesOnBoard}";
        whiteNumTxt.text = $"White Left: {numberOfWhitePiecesOnBoard}";
    }
}
