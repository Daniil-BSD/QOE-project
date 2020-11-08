using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using JetBrains.Annotations;
using UnityEngine;

public class MegaController : MonoBehaviour {

	public Data data;


	// Start is called before the first frame update
	void Start()
	{
		StateContainer.InitializeState(data, false);
	}
}
