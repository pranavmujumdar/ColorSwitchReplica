using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This Class contains logic for physics and scenemanagement
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// Jump Force
    /// </summary>
    [Tooltip("Jump force for playing the game")]
    public float jumpForce = 10f;
    
    /// <summary>
    /// We need to apply force, for which we need to make this a rigid body
    /// </summary>
    public Rigidbody2D rb;
    

   

    /// <summary>
    /// We will be putting the physics code in update, adding Velocity instead of adding force as it seems a lot smoother and proper in this context
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
            //rb.AddForce(transform.up * jumpForce);
        }
    }

    /// <summary>
    /// ReloadScene Method to restart the game when player hits the wrong color
    /// </summary>
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
