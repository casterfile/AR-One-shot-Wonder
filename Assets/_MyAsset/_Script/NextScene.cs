using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {

	public string NameScene;
	public void StartNextPage () {
		Application.LoadLevel(NameScene);
	}
}
