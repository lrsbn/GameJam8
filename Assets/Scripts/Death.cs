using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	private GameObject gameController;
	private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
		gameController = GameObject.Find("GameController");
    }

	// Update is called once per frame
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == ("Player"))
		{
			Debug.Log("Death");
			gameController.GetComponent<GameController>().Loose();
		}
	}

}
