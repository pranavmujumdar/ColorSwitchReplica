using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float jumpForce = 10f;

    public Rigidbody2D rb;
    

   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
