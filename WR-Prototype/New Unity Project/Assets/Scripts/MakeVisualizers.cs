using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisualizers : MonoBehaviour {

    private GameObject myVE;
    private GameObject myP;

	void Start () {
        Invoke("MakeVis", .1f);
	}

    void MakeVis()
    {
        myVE = (GameObject)Resources.Load("VisualizerElement");
        myP = (GameObject)Resources.Load("PlayerElement");
        for (int i = 0; i < 39; i++)
        {
            if (i == 19)
            {
                GameObject thisVE = Instantiate(myP, new Vector3(-100 + (i * 5), 0, 0), Quaternion.identity, transform);
            }
            else
            {
                //GameObject thisVE = Instantiate(myVE, new Vector3(-100 + (i * 5), 0, 0), Quaternion.identity, transform);
            }
        }
    }
}
