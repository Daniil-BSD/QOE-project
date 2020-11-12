using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {

	[System.Serializable]
	public class Data {

		public List<Pallete> palletes;

		public List<Sprite> patternPriviews;
	}

	public class Pair {

		private int? rating;

		public readonly Stimulus stimulus1;

		public readonly Stimulus stimulus2;

		public bool IsRated => !( rating is null );

		public int? Rating
		{
			get => rating; set { if ( rating is null ) rating = value; }
		}

		public Stimulus Stimulus
		{
			get {
				switch ( StateContainer.State.CurrentPhase ) {
					case StateContainer.Phase.Stimulus1:
						return stimulus1;
					case StateContainer.Phase.Stimulus2:
						return stimulus2;
					default:
						return null;
				}
			}
		}

		public Pair(Stimulus stimulus1, Stimulus stimulus2)
		{
			this.stimulus1 = stimulus1;
			this.stimulus2 = stimulus2;
		}
	}

	[System.Serializable]
	public class Pallete {

		public Color bouncer;

		public Color dampner;

		public Color goal;

		public Color killer;

		public Color wall;
	}

	public class StateContainer {

		private static StateContainer state = null;

		private List<Pair> fixedOrderPairs;

		private int pairIndex;

		private Phase phase;

		private List<Pair> presentationOrderPairs;

		private bool? resolutionTestPassed = null;

		public static StateContainer State => state;

		public Pair CurrentPair => presentationOrderPairs[pairIndex];

		public Phase CurrentPhase => phase;

		public Data Data { get; }

		private StateContainer(Data data)
		{
			Data = data;
			fixedOrderPairs = new List<Pair>();
			for ( int pattern = 0 ; pattern < data.patternPriviews.Count ; pattern++ )
				for ( int color1 = 0 ; color1 < data.palletes.Count ; color1++ )
					for ( int color2 = color1 + 1 ; color2 < data.palletes.Count ; color2++ )
						fixedOrderPairs.Add(new Pair(new Stimulus(color1, pattern), new Stimulus(color2, pattern)));

			//for ( int color = 0 ; color < data.palletes.Count ; color++ )
			int color = 1; // reducing the number of pairs
			for ( int pattern1 = 0 ; pattern1 < data.patternPriviews.Count ; pattern1++ )
				for ( int pattern2 = pattern1 + 1 ; pattern2 < data.patternPriviews.Count ; pattern2++ )
					fixedOrderPairs.Add(new Pair(new Stimulus(color, pattern1), new Stimulus(color, pattern2)));
			System.Random random = new System.Random();
			presentationOrderPairs = fixedOrderPairs.OrderBy(n => random.Next()).ToList();
			phase = Phase.ResolutionTest;
			pairIndex = 0;
			Reload();
		}

		// =================================  2  =================================
		public static bool CompleteStimulus()
		{
			if ( State.phase == Phase.Stimulus1 ) {
				State.phase = Phase.Stimulus2;
				Reload();
				return true;
			}
			if ( State.phase == Phase.Stimulus2 ) {
				State.phase = Phase.Accessment;
				Reload();
				return true;
			}
			return false;
		}

		public static bool InitializeState(Data data, bool force = false)
		{
			if ( state != null && !force )
				return false; // already initialized
			state = new StateContainer(data);
			return true; // initialized
		}

		// =================================  3  =================================
		public static bool RecordAccessment(int score)
		{
			if ( State.phase == Phase.Accessment ) {
				State.CurrentPair.Rating = score;
				State.phase = Phase.Stimulus1;
				if ( ++State.pairIndex >= state.fixedOrderPairs.Count )
					State.phase = Phase.Report;
				Reload();
				return true;
			}
			return false;
		}

		// =================================  1  =================================
		public static bool RecordResolutionTest(bool passed)
		{
			if ( State.resolutionTestPassed is null && State.phase == Phase.ResolutionTest ) {
				State.resolutionTestPassed = passed;
				State.phase = Phase.Stimulus1;
				Reload();
				return true;
			}
			return false;
		}

		public static void Reload()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		// =================================  4  =================================
		public override string ToString()
		{
			string ret = "";
			foreach ( Pair pair in fixedOrderPairs ) {
				if ( pair.IsRated )
					ret += pair.Rating + " ";
			}
			return ret;
		}

		public enum Phase {

			ResolutionTest,

			Stimulus1,

			Stimulus2,

			Accessment,

			Report
		}
	}

	public class Stimulus {

		public readonly int colorID;

		public readonly int patternID;

		public Pallete Pallete => StateContainer.State.Data.palletes[colorID];

		public Sprite PatternPreview => StateContainer.State.Data.patternPriviews[colorID];

		public Stimulus(int colorID, int patternID)
		{
			this.colorID = colorID;
			this.patternID = patternID;
		}
	}
}