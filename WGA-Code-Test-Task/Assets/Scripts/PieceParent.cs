using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceParent : MonoBehaviour
{
    public int[] greyCells = new int[6];
    public int[] colorCells = new int[19];
    public int[] whiteCells = new int[4];

    public Piece[] greenPieces = new Piece[5];
    public Piece[] redPieces = new Piece[5];
    public Piece[] yellowPieces = new Piece[5];

    public GameObject winText;

    void Start()
    {
        int i = 0;
        int j = 0;
        int t = 0;

        foreach (Piece child in GetComponentsInChildren<Piece>())
        {
            if (child.myPieceType == Piece.PieceType.Grey)
            {
                child.myGridCellNumber = greyCells[i];
                i++;
                child.SetLocationOnGrid();
            }
            else if (child.myPieceType == Piece.PieceType.White)
            {
                child.myGridCellNumber = whiteCells[t];
                t++;
                child.SetLocationOnGrid();
            }
            else
            {
                child.myGridCellNumber = colorCells[j];
                j++;
                child.SetLocationOnGrid();
            }
        }


        int g = 0;
        int r = 0;
        int y = 0;

        foreach(Piece child in GetComponentsInChildren<Piece>())
        {

            switch (child.myPieceType)
            {
                case Piece.PieceType.Green:
                    greenPieces[g] = child;
                    g++;
                    break;
                case Piece.PieceType.Red:
                    redPieces[r] = child;
                    r++;
                    break;
                case Piece.PieceType.Yellow:
                    yellowPieces[y] = child;
                    y++;
                    break;
            }
        }
    }
}
