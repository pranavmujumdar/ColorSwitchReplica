using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem ps;
    

   
    /// <summary>
    /// When the player collides with the Colorwheel then and only then the particles are thrown
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ColorChanger.currentColor != "Black" && collision.tag != "ColorChanger") 
        {
            LaunchParticles();
        }
    }

    /// <summary>
    /// When the player presses the M key the effect is generated
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.M) && ColorChanger.numOfSpecialMoves>0)
        {
            //LaunchParticles();
        }
    }

    public void LaunchParticles()
    {
        ps.Emit(30);
    }
}
