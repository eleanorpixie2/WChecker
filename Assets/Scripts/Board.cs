using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] board;
    //piece prefabs
    public Piece blackPiece;
    public Piece whitePiece;
    //space prefabs
    public BoardSpace whiteSpace;
    public BoardSpace blackSpace;
    //List of pieces
    public List<Piece> whitePieces;
    public List<Piece> blackPieces;
    //space location in scene
    private Vector3 spaceLocation;
    private float intialX;
    // Start is called before the first frame update
    void Start()
    {
        whitePieces = new List<Piece>();
        blackPieces = new List<Piece>();
        spaceLocation = whiteSpace.transform.position;
        intialX = spaceLocation.x;
        PopulateBoard();
        board = GameObject.FindGameObjectsWithTag("Space");

        SpawnPieces();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject GetSpace(int x, int y)
    {
        //find correct object based on grid location
        foreach(GameObject space in board)
        {
            if(space.GetComponent<BoardSpace>().location==new Vector2(x,y))
            {
                return space;
            }
            
        }
        return null;
    }

    void SpawnPieces()
    {
        //columns
        for (int y = 0; y < 8; y++)
        {
            //rows
            for (int x = 0; x < 8; x++)
            {
                //first 3 are white
                if (y < 3)
                {
                    GameObject space = GetSpace(x, y);
                    space.transform.position = spaceLocation;
                    //only spawn if the space is black
                    if (space.GetComponent<BoardSpace>()._spaceColor == SpaceColor.black)
                    {
                        whitePiece.currentSpace = space.GetComponent<BoardSpace>();
                        whitePiece._color = SpaceColor.white;
                        whitePiece.isKing = false;
                        whitePiece.gameObject.transform.position = spaceLocation;
                        whitePieces.Add(whitePiece);
                        Instantiate(whitePiece.gameObject);
                    }
                }
                //empty
                else if (y >= 3 && y < 5)
                {
                    GameObject space = GetSpace(x, y);
                    space.transform.position = spaceLocation;
                }
                //last 3 are black
                else if (y >= 5)
                {
                    GameObject space = GetSpace(x, y);
                    space.transform.position = spaceLocation;
                    //only spawn if the space is black
                    if (space.GetComponent<BoardSpace>()._spaceColor == SpaceColor.black)
                    {
                        blackPiece.currentSpace = space.GetComponent<BoardSpace>();
                        blackPiece._color = SpaceColor.black;
                        blackPiece.isKing = false;
                        blackPiece.gameObject.transform.position = spaceLocation;
                        blackPieces.Add(blackPiece);
                        Instantiate(blackPiece.gameObject);
                    }
                }
                //move to the right
                spaceLocation.x += 1.42f;
            }
            //reset x
            spaceLocation.x = intialX;
            //move up
            spaceLocation.z +=1.42f;
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
                        Instantiate(whiteSpace.gameObject);
                    }
                    //odd column
                    else
                    {
                        blackSpace.SetInital(SpaceColor.black, new Vector2(j, i));
                        Instantiate(blackSpace.gameObject);

                    }
                }
                //all odd rows
                else
                {
                    //even column
                    if (j % 2 == 0)
                    {
                        blackSpace.SetInital(SpaceColor.black, new Vector2(j, i));
                        Instantiate(blackSpace.gameObject);

                    }
                    //odd column
                    else
                    {
                        whiteSpace.SetInital(SpaceColor.white, new Vector2(j, i));
                        Instantiate(whiteSpace.gameObject);

                    }
                }
            }
        }
    }
}
