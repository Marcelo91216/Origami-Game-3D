using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject[] players;
    private Camera cam;
    public int limitSpace=6;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0].transform.position.x > (-1 * limitSpace) && players[0].transform.position.x < limitSpace)
        {
            cam.gameObject.transform.position = new Vector3(players[0].transform.position.x, cam.gameObject.transform.position.y, cam.gameObject.transform.position.z);
        }
    }
}
