using System.Collections;
using UnityEngine;
public class LoseScore : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<AudioManager>().Play("FloorHitSFX");
        if (other.gameObject.tag == "Cat")
        {
            ScoreManager.instance.MinusScore();
            GameControl.strikes += 1;
            other.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
            Destroy(other.gameObject, 1f);
            velocity.pause = true;
            other.gameObject.GetComponent<Animator>().Play("Idle");
            StartCoroutine(DelayVelocityPause());
        }
        else if (other.gameObject.tag == "TV")
        {
            other.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
            Destroy(other.gameObject, 1f);
        }
    }
    IEnumerator DelayVelocityPause()
    {
        yield return null;
        velocity.pause = false;
    }
}