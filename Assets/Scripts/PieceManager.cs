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
                selectedPiece = hit.collider.gameObject;
            }
            else if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<BoardSpace>())
                {
                    selectedPiece.transform.position = hit.collider.gameObject.GetComponent<BoxCollider>().transform.position;
                    selectedPiece = null;
                }
                
            }
        }
    }
}
