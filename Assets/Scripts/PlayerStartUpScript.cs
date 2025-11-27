using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartUpScript : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        SequenceSystem.PlayerObject = Player;
        GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusic>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
