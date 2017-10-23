using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	public string StartLevel;

	public void NewGame ()
	{
		Application.LoadLevel(StartLevel);

	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
