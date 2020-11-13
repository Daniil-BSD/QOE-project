using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ReportDisplayScript : MonoBehaviour {
	// Start is called before the first frame update
	void Start()
	{
		if ( StateContainer.State != null ) {
			GetComponent<Text>().text = StateContainer.State.ToString();
		}
	}
}
