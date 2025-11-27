using Assets.Scripts.Globals;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneChange : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SequenceSystem.CharacterPosition = collision.transform.position;
            SequenceSystem.InCombat = true;

            switch (gameObject.name)
            {
                case "Corduka":
                    SceneManager.LoadScene(2);
                    break;
                case "Enjingos":
                    SceneManager.LoadScene(3);
                    break;
                case "Zukori":
                    SceneManager.LoadScene(4);
                    break;
            }

        }
    }

}
