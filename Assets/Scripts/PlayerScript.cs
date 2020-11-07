using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public class PlayerScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 temp = collision.GetContact(0).point;
		Debug.Log(collision.collider.gameObject.GetComponent<Tilemap>().layoutGrid.WorldToCell(new Vector3(temp.x, temp.y, 0)));
	}
}
