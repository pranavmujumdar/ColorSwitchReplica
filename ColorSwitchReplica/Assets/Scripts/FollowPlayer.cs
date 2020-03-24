using UnityEngine;

/// <summary>
/// This Class Contains the logic for following the camera with the player
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    //Getting the transform position of the player
    public Transform player;
    

    /// <summary>
    /// If player moves in Y direction i.e. Player's position is "HIGHER" than the camera position
    /// We will move the camera upwards
    /// </summary>
    void Update()
    {
        if(player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }    
    }
}
