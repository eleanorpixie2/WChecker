using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    Board boardRef;
    GameObject selectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        boardRef = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        //boardRef.
    }
}
