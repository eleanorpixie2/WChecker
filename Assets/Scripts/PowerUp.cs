using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public PlayerManager playerManager;

    public Animator animWhite;
    public Animator animBlack;

    public Button blackPowerUpRevive;
    public Button WhitePowerUpRevive;

    public Board board;

    public GameObject whitePiece;
    public GameObject blackPiece;

    private int numberOfKillsWhitePlayer;
    private int numberOfKillsBlackPlayer;

    private int currentWhitePieces;
    private int currentBlackPieces;

    private bool canChoosePowerUpWhitePlayer;
    private bool canChoosePowerUpBlackPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //can't choose a power up yet
        canChoosePowerUpWhitePlayer = false;
        canChoosePowerUpBlackPlayer = false;

        //nothing has been killed yet
        numberOfKillsWhitePlayer = 0;
        numberOfKillsBlackPlayer = 0;

        //intial amount of pieces on the board
        currentWhitePieces = 12;
        currentBlackPieces = 12;

        Button btnBlack = blackPowerUpRevive.GetComponent<Button>();
        btnBlack.onClick.AddListener(TaskOnClick2);
        //btnBlack.enabled= false;

        Button btnWhite = WhitePowerUpRevive.GetComponent<Button>();
        btnWhite.onClick.AddListener(TaskOnClick);
        //btnWhite.enabled = false;


    }

    private void TaskOnClick2()
    {
        if (playerManager.currentTurn == colorTurn.black && canChoosePowerUpBlackPlayer)
        {
            canChoosePowerUpBlackPlayer = false;
            numberOfKillsBlackPlayer = 0;
            animBlack.SetInteger("Kills", numberOfKillsBlackPlayer);

            GameObject space = null;
            Piece p = blackPiece.GetComponent<Piece>();
            foreach (GameObject bs in GameObject.FindGameObjectsWithTag("Space"))
            {
                if (bs.GetComponent<BoardSpace>().location.y >= 5)
                {
                    if (bs.GetComponent<BoardSpace>()._spaceColor == SpaceColor.black && bs.GetComponent<BoardSpace>().currentPiece == null)
                    {
                        space = bs;
                    }
                }
            }

            p.currentSpace = space.GetComponent<BoardSpace>();
            p._color = SpaceColor.black;
            p.isKing = false;
            blackPiece.gameObject.transform.position = space.transform.position;
            GameObject piece = (GameObject)PrefabUtility.InstantiatePrefab(blackPiece);
            PrefabUtility.UnpackPrefabInstance(piece, PrefabUnpackMode.Completely, InteractionMode.UserAction);
            space.GetComponent<BoardSpace>().SetCurrentPiece(piece);
            playerManager.numberOfBlackPiecesOnBoard++;
            playerManager.UpdateText();
        }
    }

    private void TaskOnClick()
    {
        if (playerManager.currentTurn == colorTurn.white && canChoosePowerUpWhitePlayer)
        {
            canChoosePowerUpWhitePlayer = false;
            GameObject space = null;
            Piece p = whitePiece.GetComponent<Piece>();
            foreach (GameObject bs in GameObject.FindGameObjectsWithTag("Space"))
            {
                if (bs.GetComponent<BoardSpace>().location.y < 3)
                {
                    if (bs.GetComponent<BoardSpace>()._spaceColor == SpaceColor.black && bs.GetComponent<BoardSpace>().currentPiece == null)
                    {
                        space = bs;
                    }
                }
            }
            p.currentSpace = space.GetComponent<BoardSpace>();
            p._color = SpaceColor.white;
            p.isKing = false;
            whitePiece.gameObject.transform.position = space.transform.position;
            GameObject piece = (GameObject)PrefabUtility.InstantiatePrefab(whitePiece);
            PrefabUtility.UnpackPrefabInstance(piece, PrefabUnpackMode.Completely, InteractionMode.UserAction);
            space.GetComponent<BoardSpace>().SetCurrentPiece(piece);
            playerManager.numberOfWhitePiecesOnBoard++;
            playerManager.UpdateText();

            numberOfKillsWhitePlayer = 0;
            animWhite.SetInteger("Kills", numberOfKillsWhitePlayer);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //white pieces turn

        //if pieces have been removed
        if (playerManager.numberOfBlackPiecesOnBoard != currentBlackPieces)
        {
            //get how many pieces have been removed from the opponent
            int numberOfKills = currentBlackPieces - playerManager.numberOfBlackPiecesOnBoard;

            //increase the number of kills
            numberOfKillsBlackPlayer += numberOfKills;

            //reset the current amount
            currentBlackPieces = playerManager.numberOfBlackPiecesOnBoard;
            animBlack.SetInteger("Kills", numberOfKillsBlackPlayer);

            if (numberOfKillsBlackPlayer >= 4)
            {
                canChoosePowerUpBlackPlayer = true;
                numberOfKills = 4;
            }
        }
        //if pieces have been removed
        if (playerManager.numberOfWhitePiecesOnBoard != currentWhitePieces)
        {
            //get how many pieces have been removed from the opponent
            int numberOfKills = currentWhitePieces - playerManager.numberOfWhitePiecesOnBoard;

            //increase the number of kills
            numberOfKillsWhitePlayer += numberOfKills;

            //reset the current amount
            currentWhitePieces = playerManager.numberOfWhitePiecesOnBoard;
            animWhite.SetInteger("Kills", numberOfKillsWhitePlayer);

            if (numberOfKillsWhitePlayer >= 4 && playerManager.numberOfWhitePiecesOnBoard < 12)
            {
                canChoosePowerUpWhitePlayer = true;
                numberOfKills = 4;
            }
        }
    }


}
