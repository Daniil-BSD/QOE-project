using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GravitySpinnerScript : MonoBehaviour {
	public bool overrideTheGravitatyMagnitude = false;
	public float newMagnitude = 10f;
	public float degreesPerSecond = 90f;
	private float horizontalAxis = 0;
	public GameObject player;
	private float usedMagnitude;
	private float step;
	private float angle = -90;

	public float Angle => angle;

	public float HorizontalAxis
	{
		get => horizontalAxis;
		set => horizontalAxis = value;
	}

	void OnEnable()
	{
		if ( overrideTheGravitatyMagnitude && newMagnitude != 0 ) {
			usedMagnitude = newMagnitude;
		} else {
			usedMagnitude = Physics2D.gravity.magnitude;
		}
		step = Time.fixedDeltaTime * degreesPerSecond;
		Physics2D.gravity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * usedMagnitude, Mathf.Sin(angle * Mathf.Deg2Rad) * usedMagnitude);
	}

	void FixedUpdate()
	{
		if ( Input.GetAxis("Horizontal") != 0 || horizontalAxis != 0 ) {
			if ( Input.GetAxis("Horizontal") > 0 || horizontalAxis > 0 ) {
				angle += step;
				transform.Rotate(0, 0, step);
			} else {
				angle -= step;
				transform.Rotate(0, 0, -step);
			}
			Physics2D.gravity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * usedMagnitude, Mathf.Sin(angle * Mathf.Deg2Rad) * usedMagnitude);
		}
	}

	void Update()
	{
		if ( player != null ) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		}
	}
}