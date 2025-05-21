using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!scored && other.CompareTag("Player"))
        {
            SoundController.instance.PLaySound("point", 1f);
            GameManager.Instance.AddScore();
            scored = true;
        }
    }
}