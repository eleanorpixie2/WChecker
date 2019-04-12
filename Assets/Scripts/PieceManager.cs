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
        //boardRef = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print("Was clicked");
            }
        }
    }
}
