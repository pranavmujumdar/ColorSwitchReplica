using UnityEngine;
using TMPro;
public class ColorChanger : MonoBehaviour
{

    public SpriteRenderer sr;


    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    public Color colorBlack;

    public int numOfSpecialMoves = 3;

    public TextMeshProUGUI movesText;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
        SetMovesText();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M) && numOfSpecialMoves>0)
        {
            UseSpecialMove();
        }
        if (Input.GetKeyUp(KeyCode.M) && numOfSpecialMoves>0)
        {
            SetRandomColor();
            numOfSpecialMoves--;
            Debug.Log(numOfSpecialMoves);
            SetMovesText();
        }
        if (Input.GetKeyDown(KeyCode.M) && numOfSpecialMoves <= 0)
        {
            Debug.Log("Out Of Moves");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentColor != "Black")
        {
            if (collision.tag == "ColorChanger")
            {
                SetRandomColor();
                Destroy(collision.gameObject);
                return;
            }
            Debug.Log(collision.tag);

            if (collision.tag != currentColor)
            {
                Debug.Log("GO");
                Player.ReloadScene();
            }
        }
    }

    void SetRandomColor()
    {

        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }

    void UseSpecialMove()
    {
        currentColor = "Black";
        sr.color = colorBlack;
    }

    void SetMovesText()
    {
        movesText.text = "Moves: " + numOfSpecialMoves;
    }
}
