using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class AcessmentButtonScript : MonoBehaviour {

	public void RecordScore(int score)
	{
		StateContainer.RecordAccessment(score);
	}
}
