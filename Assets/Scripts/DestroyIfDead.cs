using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (gameObject.name)
        {
            case "Corduka":
                if (SequenceSystem.CordukaDead)
                    Destroy(gameObject);
                break;
            case "Zukori":
                if (SequenceSystem.ZukoriDead)
                    Destroy(gameObject);
                break;
            case "Enjingos":
                if (SequenceSystem.EnjingosDead)
                    Destroy(gameObject);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
