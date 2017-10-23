using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Gives access to Unity UI Methods and Variables



public class GameMaster : MonoBehaviour {

	public int points;

	public Text pointsText;

	void Update () 
	{
		pointsText.text = ("Points:  " + points);

	}
}