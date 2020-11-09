using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using static Assets.Scripts.StateContainer;

public class ControllerEnableSlave : MonoBehaviour {

	public Phase phase;

	// Start is called before the first frame update
	void Update()
	{
		gameObject.SetActive(StateContainer.State.CurrentPhase == phase);
	}
}