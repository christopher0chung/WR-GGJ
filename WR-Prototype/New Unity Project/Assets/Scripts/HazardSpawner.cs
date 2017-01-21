using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {

	public float hazardDelay;
	private int index = 0;

	public GameObject[] hazards;

	// Update is called once per frame
	void Update () {
		if (index < hazards.Length) {
			if (hazards [index] == null) {
				Debug.Log ("No Hazard Found.");
				//break;
			} else {

				while (IsInvoking ("SpawnHazard") == false) {
					Invoke ("SpawnHazard", hazardDelay);
					index++;
				}
			}
		}
	}

	void SpawnHazard() {
		if (index < hazards.Length) {
			Instantiate (hazards [index], transform.position, Quaternion.identity);
		}
	}

}
