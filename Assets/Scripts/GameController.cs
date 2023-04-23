using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public Vector3 spawnpoint = new Vector3(0, 5, 0);

    GameObject player;
    GameObject lowerBoundary;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Finish").GetComponentInChildren<Canvas>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        lowerBoundary = GameObject.Find("LowerBoundary");

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < lowerBoundary.transform.position.y) {
            Debug.Log("Resetting");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
