using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class TilemapHider : MonoBehaviour {
	// Start is called before the first frame update

	public int patternIndex;
	void Start()
	{
		bool enable = StateContainer.State != null && ( StateContainer.State.CurrentPhase == StateContainer.Phase.Stimulus1 || StateContainer.State.CurrentPhase == StateContainer.Phase.Stimulus2 ) && StateContainer.State.CurrentPair != null && StateContainer.State.CurrentPair.Stimulus.patternID == patternIndex;
		gameObject.SetActive(enable);
	}
}
