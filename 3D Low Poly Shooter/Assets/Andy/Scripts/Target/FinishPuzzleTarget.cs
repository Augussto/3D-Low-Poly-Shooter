using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPuzzleTarget : MonoBehaviour
{
		// Use this for initialization
	int targetsLeft = 0;
	bool destroyAllTargets = false;
	[SerializeField] ContadorEnemigos contadorTargets;
	private RunInfo runInfo;
	void Start()
	{
		runInfo = FindObjectOfType<RunInfo>();
		contadorTargets = FindObjectOfType<ContadorEnemigos>();
		targetsLeft = 11; // or whatever;
		contadorTargets.SetEnemies(targetsLeft);
	}

		// Update is called once per frame
	void Update()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Target");
		targetsLeft = enemies.Length - 1;
        contadorTargets.SetEnemies(enemies.Length - 1);
        if (targetsLeft == 0)
		{
			endLevel();
		}
	}

	void endLevel()
	{
		runInfo.passMiniGame01 = true;
		destroyAllTargets = true;
		Debug.Log("Level Finished");
		SceneManager.LoadScene("Escena Augusto Test");
	}
}
