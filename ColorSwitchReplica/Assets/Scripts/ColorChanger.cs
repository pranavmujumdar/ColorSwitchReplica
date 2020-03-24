using UnityEngine;
using TMPro;

/// <summary>
/// This Class Contains
/// 1. The logic for matching the colors
/// 2. changing the player's color
/// 3. Using the Special Move
/// </summary>
public class ColorChanger : MonoBehaviour
{
    /// <summary>
    /// Getting the Spriterendered reference to change the color of the player from the script
    /// </summary>
    public SpriteRenderer sr;

    //Storing the currentColor in order to match it with the collided tag
    public static string currentColor;

    // All the Colors
    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    public Color colorBlack;

    //Number of special moves
    public static int numOfSpecialMoves = 3;

    //TMPro GUI text feild to show how many moves are left
    public TextMeshProUGUI movesText;

    //Animator
    public Animator animator;
    // Setting random color at the beginning and setting Special Moves text
    void Start()
    {
        numOfSpecialMoves = 3;
        SetRandomColor();
        SetMovesText();
    }
    /// <summary>
    /// For the special Move
    /// if moves are available and player presses M key
    /// the move is used until the player releases the key
    /// Each press reduces the num of moves
    /// The player should not be able to use moves when moves are 0 also the variable should not go below 0
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && numOfSpecialMoves>0)
        {
            FindObjectOfType<AudioManager>().Play("Canon");
            animator.SetBool("IsSpecialMove", true);
        }
        if (Input.GetKey(KeyCode.M) && numOfSpecialMoves>0)
        {
            UseSpecialMove();
        }
        if (Input.GetKeyUp(KeyCode.M) && numOfSpecialMoves>0)
        {
            animator.SetBool("IsSpecialMove", false);
            SetRandomColor();
            numOfSpecialMoves--;
            Debug.Log(numOfSpecialMoves);
            SetMovesText();
            
        }
        if (Input.GetKeyDown(KeyCode.M) && numOfSpecialMoves <= 0)
        {
            Debug.Log("Out Of Moves");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SetRandomColor();
        }
    }
    /// <summary>
    /// When collided with
    /// 1. The "ColorChanger" object the player changes the color and the color changer is destroyed
    /// 2. The "Colorwheel", match the tag on the collided object and the current color of the player
    /// if, they do not match Game over and reload the scene
    /// </summary>
    /// <param name="collision">To get the object that player collided with</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentColor != "Black")
        {
            if (collision.tag == "ColorChanger")
            {
                SetRandomColor();
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Pass");
                return;
            }
            Debug.Log(collision.tag);

            if (collision.tag != currentColor)
            {
                Debug.Log("GO");
                FindObjectOfType<AudioManager>().Stop("Theme");
                FindObjectOfType<AudioManager>().Play("Loser");
                Player.ReloadScene();
            }
        }
    }
    /// <summary>
    /// Sets rendom color to the player when collided with the "ColorChanger" object
    /// </summary>
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
    /// <summary>
    /// Uses Special move, where the current color becomes black and the player can pass through all the wheels until the button is released
    /// </summary>
    void UseSpecialMove()
    {
        currentColor = "Black";
        sr.color = colorBlack;
    }

    /// <summary>
    /// Sets the text to reflect the number of moves left
    /// </summary>
    void SetMovesText()
    {
        movesText.text = "Moves: " + numOfSpecialMoves;
    }
}
