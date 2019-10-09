using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public enum PieceType
    {
        White,
        Grey,
        Yellow,
        Green,
        Red
    }

    public PieceType myPieceType;
    public int myGridCellNumber;

    void Start()
    {
        SetLocationOnGrid();
    }

    public void SetLocationOnGrid()
    {
        int myX = myGridCellNumber % 5;
        int myY = myGridCellNumber / 5;
        transform.position = new Vector2(myX, myY);
    }

    void Update()
    {
        
    }
}
