using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPuzzleTarget : MonoBehaviour
{
		// Use this for initialization
		int targetsLeft = 0;
		bool destroyAllTargets = false;
		void Start()
		{
		targetsLeft = 11; // or whatever;

		}

		// Update is called once per frame
		void Update()
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Target");
		targetsLeft = enemies.Length;
			if (Input.GetKeyDown(KeyCode.W))
			{
			targetsLeft--;
			}
			if (targetsLeft == 0)
			{
				endLevel();
			}
		}

		void endLevel()
		{
		destroyAllTargets = true;
		Debug.Log("Level Finished");
		SceneManager.LoadScene("Escena Augusto Test");
	}
}
