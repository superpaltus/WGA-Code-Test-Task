using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static GameObject firstPiece;

    private static bool isFirst = true;

    public PieceParent pieceParent;

    private void Start()
    {
        pieceParent = FindObjectOfType<PieceParent>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isFirst)
            {
                firstPiece = gameObject;
                isFirst = false;
            }
            else
            {
                ChangePieces();
                isFirst = true;
            }
        }
    }

    private void ChangePieces()
    {
        int firstCellNumber = firstPiece.GetComponent<Piece>().myGridCellNumber;
        print("first cell number is: " + firstCellNumber);
        int secondCellNumber = GetComponent<Piece>().myGridCellNumber;
        print("second cell number is: " + secondCellNumber);

        int temp = firstCellNumber;

        bool firstCondition = Mathf.Abs(firstCellNumber - secondCellNumber) == 1;
        bool secondCondition = (firstCellNumber % 5 == secondCellNumber % 5) && (Mathf.Abs((firstCellNumber / 5) - (secondCellNumber / 5)) == 1);
        bool thirdCondition = firstPiece.GetComponent<Piece>().myPieceType == Piece.PieceType.White || GetComponent<Piece>().myPieceType == Piece.PieceType.White;

        if ((firstCondition || secondCondition) && thirdCondition)
        {
            firstPiece.GetComponent<Piece>().myGridCellNumber = secondCellNumber;
            GetComponent<Piece>().myGridCellNumber = temp;

            firstPiece.GetComponent<Piece>().SetLocationOnGrid();
            GetComponent<Piece>().SetLocationOnGrid();
        }
        WinCheck();
    }

    private void WinCheck()
    {
        int score = 0;

        foreach (Piece piece in pieceParent.greenPieces)
        {
            int num = piece.myGridCellNumber;
            if (num == 0 || num == 5 || num == 10 || num == 15 || num == 20) score++;
        }
        foreach (Piece piece in pieceParent.redPieces)
        {
            int num = piece.myGridCellNumber;
            if (num == 2 || num == 7 || num == 12 || num == 17 || num == 22) score++;
        }
        foreach (Piece piece in pieceParent.yellowPieces)
        {
            int num = piece.myGridCellNumber;
            if (num == 4 || num == 9 || num == 14 || num == 19 || num == 24) score++;
        }

        print("current score: " + score);
        if (score == 15)
        {
            print("YOU WIN");
            pieceParent.winText.SetActive(true);
        }
    }
}
