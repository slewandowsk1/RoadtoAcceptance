using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNextScene : MonoBehaviour {

	void Start ()
    {
		StartCoroutine (loadSceneAfterDelay(9));
	}

	IEnumerator loadSceneAfterDelay(float waitbySecs){

		yield return new WaitForSeconds(waitbySecs);
		SceneManager.LoadScene (2);
	} 
}

		
	


	
