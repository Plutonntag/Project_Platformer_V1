using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBumper : MonoBehaviour
{
    [SerializeField] float baseBounceForce; // La force de base de rebond

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si l'objet a un Rigidbody2D pour appliquer la force
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            if (collision.transform.tag == "Player")
            {
                // Calcule la direction opposée à la normale du point de contact
                Vector2 bounceDirection = collision.contacts[0].normal;

                // Obtenir la vitesse de l'objet au moment de l'impact
                float impactSpeed = collision.relativeVelocity.magnitude;

                // Calcule la force de rebond basée sur la vitesse d'impact
                float bounceForce = impactSpeed;

                // Applique la force de rebond
                if(bounceForce < 14)
                {
                    rb.AddForce(-bounceDirection * baseBounceForce * 8, ForceMode2D.Impulse);
                }
                else if (bounceForce > 20)
                {
                    rb.AddForce(-bounceDirection * baseBounceForce * 15, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(-bounceDirection * bounceForce, ForceMode2D.Impulse);
                }

            }
            else
            {
                // Calcule la direction opposée à la normale du point de contact
                Vector2 bounceDirection = collision.contacts[0].normal;

                // Obtenir la vitesse de l'objet au moment de l'impact
                float impactSpeed = collision.relativeVelocity.magnitude;

                // Calcule la force de rebond basée sur la vitesse d'impact
                float bounceForce = impactSpeed;

                // Applique la force de rebond
                rb.AddForce(-bounceDirection * bounceForce, ForceMode2D.Impulse);

            }

        }
    }
}
