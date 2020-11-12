using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputEmulator : MonoBehaviour {

	public GravitySpinnerScript mainCamera;


	public Button leftButton;
	public Button rightButton;

	private bool leftButtonPressed = false;
	private bool rightButtonPressed = false;

	void Start()
	{
		if ( mainCamera == null ) {
			Debug.LogWarning("mainCamera is auto-assigned");
			mainCamera = GameObject.Find("Main Camera").GetComponent<GravitySpinnerScript>();
		}
		gameObject.SetActive(mainCamera != null);
		mainCamera.HorizontalAxis = 0;
	}

	public void RightButtonDown()
	{
		rightButtonPressed = true;
		UpdateInputValues();
	}

	public void LeftButtonDown()
	{
		leftButtonPressed = true;
		UpdateInputValues();
	}

	public void RightButtonUp()
	{
		rightButtonPressed = false;
		UpdateInputValues();
	}

	public void LeftButtonUp()
	{
		leftButtonPressed = false;
		UpdateInputValues();
	}

	public void UpdateInputValues()
	{
		int i = 0;
		if ( rightButtonPressed ) {
			i++;
		}
		if ( leftButtonPressed ) {
			i--;
		}
		mainCamera.HorizontalAxis = i;
	}
}