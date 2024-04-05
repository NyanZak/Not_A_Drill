using System.Collections;
using UnityEngine;
public class AddScore : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine("Test");
        if (other.gameObject.tag == "Cat")
        {
            ScoreManager.instance.AddScore();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "TV")
        {
            ScoreManager.instance.Minus2Score();
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("ExplosionSFX");
        }
    }

    IEnumerator Test()
    {
        FindObjectOfType<AudioManager>().Play("AmbulanceSFX");
        animator.SetBool("pointscored", true);
        yield return new WaitForSeconds(2.5f);
        animator.SetBool("pointscored", false);
    }  
    
}