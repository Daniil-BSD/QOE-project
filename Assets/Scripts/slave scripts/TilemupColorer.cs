using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemupColorer : MonoBehaviour {
	public Tilemap Walls;
	public Tilemap Goal;
	public Tilemap Killer;
	public Tilemap Bounccer;
	public Tilemap Absorber;
	public Camera Background;
	void Start()
	{
		bool apply =
			StateContainer.State != null
			&& ( StateContainer.State.CurrentPhase == StateContainer.Phase.Stimulus1 || StateContainer.State.CurrentPhase == StateContainer.Phase.Stimulus2 )
			&& StateContainer.State.CurrentPair != null
			&& StateContainer.State.CurrentPair.Stimulus.Pallete != null;
		if ( apply ) {
			Pallete pallete = StateContainer.State.CurrentPair.Stimulus.Pallete;
			Walls.color = pallete.wall;
			Goal.color = pallete.goal;
			Killer.color = pallete.killer;
			Bounccer.color = pallete.bouncer;
			Absorber.color = pallete.dampner;
		}
	}
}
