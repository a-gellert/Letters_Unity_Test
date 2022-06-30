using System;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public int X { get; private set; }
    public int Y { get; private set; }
    [SerializeField] private TMPro.TMP_Text _letterText;
    public char Letter { get; private set; }

    void Start()
    {
        SetLetter();

    }

    private void SetLetter()
    {
        int i = UnityEngine.Random.Range(65, 91);
        Letter = Convert.ToChar(i);
        _letterText.text = Letter.ToString();
    }

    public void ChangePosition(Vector2 newPosition)
    {
        transform.GetComponent<CellMover>().Move(newPosition);
    }
}
