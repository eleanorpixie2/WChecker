using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public PlayerManager playerManager;
    public Animator animWhite;
    public Animator animBlack;
    public Button blackPowerUp;
    public Button WhitePowerUp;
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
        currentWhitePieces = playerManager.numberOfWhitePiecesOnBoard;
        currentBlackPieces = playerManager.numberOfBlackPiecesOnBoard;
    }

    // Update is called once per frame
    void Update()
    {
        //white pieces turn
        if(playerManager.currentTurn==colorTurn.white)
        {
            //if pieces have been removed
            if (playerManager.numberOfBlackPiecesOnBoard != currentBlackPieces)
            {
                //get how many pieces have been removed from the opponent
                int numberOfKills = currentBlackPieces - playerManager.numberOfBlackPiecesOnBoard;
                //increase the number of kills
                numberOfKillsWhitePlayer += numberOfKills;
                //reset the current amount
                currentBlackPieces = playerManager.numberOfBlackPiecesOnBoard;
                animWhite.SetInteger("Kills", numberOfKillsWhitePlayer);
                if(numberOfKills>=4)
                {
                    canChoosePowerUpWhitePlayer = true;
                    numberOfKills = 4;
                }
            }
        }
        else if (playerManager.currentTurn == colorTurn.black)
        {
            //if pieces have been removed
            if (playerManager.numberOfWhitePiecesOnBoard != currentWhitePieces)
            {
                //get how many pieces have been removed from the opponent
                int numberOfKills = currentWhitePieces - playerManager.numberOfWhitePiecesOnBoard;
                //increase the number of kills
                numberOfKillsBlackPlayer += numberOfKills;
                //reset the current amount
                currentWhitePieces = playerManager.numberOfWhitePiecesOnBoard;
                animBlack.SetInteger("Kills", numberOfKillsBlackPlayer);
                if (numberOfKills >= 4)
                {
                    canChoosePowerUpBlackPlayer = true;
                    numberOfKills = 4;
                }
            }
        }

    }
}
