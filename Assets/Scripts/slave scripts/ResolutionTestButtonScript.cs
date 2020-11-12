using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ResolutionTestButtonScript : MonoBehaviour {

	public void RecordResolutionTest(bool pass)
	{
		StateContainer.RecordResolutionTest(pass);
	}
}
