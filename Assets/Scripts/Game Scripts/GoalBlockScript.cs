using System.Collections;
using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GoalBlockScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D collision)
	{
		if ( ( collision.collider.gameObject.tag != "Walls" && collision.collider.gameObject.tag == "Player" ) ) {
			StateContainer.CompleteStimulus();
		}
	}
}
