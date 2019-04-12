using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<BoardSpace> board;
    //piece prefabs
    public GameObject blackPiece;
    public GameObject whitePiece;
    //space prefabs
    public BoardSpace whiteSpace;
    public BoardSpace blackSpace;
    //List of pieces
    public List<Piece> whitePieces;
    public List<Piece> blackPieces;

    private Vector3 spaceLocation;
    // Start is called before the first frame update
    void Start()
    {
        board = new List<BoardSpace>();
        whitePieces = new List<Piece>();
        blackPieces = new List<Piece>();
        spaceLocation = whiteSpace.transform.position;
        PopulateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnPieces()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if(y<3)
                {

                }
                else if( y>=5)
                {

                }
            }
        }
    }


    void PopulateBoard()
    {
        //y-cooridnate on grid
        for (int i = 0; i < 8; i++)
        {
            //x-coordinate on grid
            for (int j = 0; j < 8; j++)
            {
                //all even rows
                if (i%2 == 0)
                {
                    //even column
                    if (j%2 == 0)
                    {
                        whiteSpace.SetInital(SpaceColor.white, new Vector2(j, i));
                        board.Add(whiteSpace);
                    }
                    //odd column
                    else
                    {
                        blackSpace.SetInital(SpaceColor.black, new Vector2(j, i));
                        board.Add(whiteSpace);
                    }
                }
                //all odd rows
                else
                {
                    //even column
                    if (j % 2 == 0)
                    {
                        blackSpace.SetInital(SpaceColor.black, new Vector2(j, i));
                        board.Add(whiteSpace);

                    }
                    //odd column
                    else
                    {
                        whiteSpace.SetInital(SpaceColor.white, new Vector2(j, i));
                        board.Add(whiteSpace);
                    }
                }
            }
        }
    }
}
