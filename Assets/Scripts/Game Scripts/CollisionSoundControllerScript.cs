using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(AudioSource))]
public class CollisionSoundControllerScript : MonoBehaviour {
	public AudioClip collisionSound;
	public float volume;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.gameObject.tag != "Projectile" ) {
			if ( collision.gameObject.GetComponent<CollisionSoundControllerScript>() == null ) {
				GetComponent<AudioSource>().PlayOneShot(collisionSound, collision.relativeVelocity.magnitude / 10 * volume);
			} else {
				if ( gameObject.GetInstanceID() > collision.gameObject.GetInstanceID() ) {
					GetComponent<AudioSource>().PlayOneShot(collisionSound, collision.relativeVelocity.magnitude / 10 * volume);
				}
			}
		}
	}
}
