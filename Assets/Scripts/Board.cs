using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    List<BoardSpace> board;
    public GameObject blackPiece;
    public GameObject whitePiece;
    // Start is called before the first frame update
    void Start()
    {
        board = new List<BoardSpace>();
        PopulateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnPieces()
    {

    }


    void PopulateBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (i%2 == 0)
                {
                    if (j%2 == 0)
                    {
                        board.Add(new BoardSpace(SpaceColor.white, new Vector2(j, i)));
                    }
                    else
                    {
                        board.Add(new BoardSpace(SpaceColor.black, new Vector2(j, i)));
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        board.Add(new BoardSpace(SpaceColor.black, new Vector2(j, i)));

                    }
                    else
                    {
                        board.Add(new BoardSpace(SpaceColor.white, new Vector2(j, i)));
                    }
                }
            }
        }
    }
}
