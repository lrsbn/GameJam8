using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public Vector3 spawnpoint = new Vector3(0, 5, 0);

    private GameObject player;
    public float lowerBoundary = -20f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Finish").GetComponentInChildren<Canvas>().enabled = false;
        GameObject.Find("Loose").GetComponentInChildren<Canvas>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < lowerBoundary) {
            Loose();
        }
    }

    public void Loose() {
        player.GetComponent<Player_Movement>().enabled = false;
        GameObject.Find("Loose").GetComponentInChildren<Canvas>().enabled = true;
    }

    public void Win()
    {
        GameObject.Find("Finish").GetComponentInChildren<Canvas>().enabled = true;
    }

    public void ResetGame() {
        Debug.Log("Resetting");
        SceneManager.LoadScene("SampleScene");
    }
}
