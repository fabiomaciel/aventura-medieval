using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject _Player;     //Public variable to store a reference to the player game object


    //private Vector2 offset;            //Private variable to store the offset distance between the player and camera
    
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        //offset = player.transform.position;//transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()

    {
        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            float PlayerX = _Player.transform.position.x;
            float PlayerY = _Player.transform.position.y;
            transform.position = new Vector3(PlayerX, PlayerY + 1.8f, -10);
            Debug.Log(_Player.transform.position);
        }
        //offset = player.transform.position;//transform.position - player.transform.position;
        //transform.position = offset;//player.transform.position + offset;
    }
}
