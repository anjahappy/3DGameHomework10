using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class Judger : MonoBehaviour {

	public int check_game_over(CoastController fromCoast, CoastController toCoast, BoatController boat) {	// 0->not finish, 1->lose, 2->win
		int from_priest = 0;
		int from_devil = 0;
		int to_priest = 0;
		int to_devil = 0;

		int[] fromCount = fromCoast.getCharacterNum ();
		from_priest += fromCount[0];
		from_devil += fromCount[1];

		int[] toCount = toCoast.getCharacterNum ();
		to_priest += toCount[0];
		to_devil += toCount[1];

		if (to_priest + to_devil == 6)		// win
			return 2;

		int[] boatCount = boat.getCharacterNum ();
		if (boat.get_to_or_from () == -1) {	// boat at toCoast
			to_priest += boatCount[0];
			to_devil += boatCount[1];
		} else {	// boat at fromCoast
			from_priest += boatCount[0];
			from_devil += boatCount[1];
		}
		if (from_priest < from_devil && from_priest > 0) {		// lose
			return 1;
		}
		if (to_priest < to_devil && to_priest > 0) {
			return 1;
		}
		return 0;			// not finish
	}
}