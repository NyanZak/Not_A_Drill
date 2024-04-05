using System.Collections;
using UnityEngine;
public class velocity : MonoBehaviour
{
    public Vector2 initialVelocity;
    private Vector3 pausedVelocity;
    private float pausedAngularVelocity;
    public static bool pause = false;
    private bool paused = false;
    public Animator animator;

    private void Start()
    {
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => velocity.pause == false);
        Rigidbody2D physics = GetComponent<Rigidbody2D>();
        animator.SetBool("isFalling", true);
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        physics.AddForce(initialVelocity, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("FallingSFX");
    }

    public void Pause()
    {
        pausedVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pausedAngularVelocity = GetComponent<Rigidbody2D>().angularVelocity;
        GetComponent<Rigidbody2D>().isKinematic = true;
        Invoke("Resume", 3f);
    }

    public void Resume()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().velocity = pausedVelocity;
        GetComponent<Rigidbody2D>().angularVelocity = pausedAngularVelocity;
        pause = false;
        paused = false;
        Rigidbody2D physics = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (pause == true && paused == false)
        {
            paused = true;
            Pause();
        }
    }

}