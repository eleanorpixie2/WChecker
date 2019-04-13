﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //number of pieces on the board for each side
    public int numberOfWhitePiecesOnBoard;
    public int numberOfBlackPiecesOnBoard;
    //UI text
    public Text whiteNumTxt;
    public Text blackNumTxt;
    // Start is called before the first frame update
    void Start()
    {
        //intialize number and text
        numberOfWhitePiecesOnBoard = 12;
        numberOfBlackPiecesOnBoard = 12;
        blackNumTxt.text = $"Black Left: {numberOfBlackPiecesOnBoard}";
        whiteNumTxt.text = $"White Left: {numberOfWhitePiecesOnBoard}";
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfBlackPiecesOnBoard<=0)
        {
            //lose
        }
        else if(numberOfWhitePiecesOnBoard<=0)
        {
            //lose
        }
    }

    public void RemovePieceFromBoard(GameObject piece)
    {
        //Get the piece component of the game object
        Piece _piece = piece.GetComponent<Piece>();
        //get the space that it is on
        BoardSpace space = _piece.currentSpace;
        //reset the space
        space.SetCurrentPiece();
        //if black then decrease the number of pieces and update text accordingly
        if(_piece._color==SpaceColor.black)
        {
            numberOfBlackPiecesOnBoard--;
            Destroy(piece);
            blackNumTxt.text = $"Black Left: {numberOfBlackPiecesOnBoard}";
        }
        //if white then decrease the number of pieces and update text accordingly
        else if(_piece._color==SpaceColor.white)
        {
            numberOfWhitePiecesOnBoard--;
            Destroy(piece);
            whiteNumTxt.text = $"White Left: {numberOfWhitePiecesOnBoard}";
        }
    }
}
