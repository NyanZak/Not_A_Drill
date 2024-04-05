using UnityEngine;
public class Movement : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    GameObject dustCloud;
   public float speed = 2f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0) * speed;
        animator.SetFloat("Speed", Mathf.Abs(x));
        if (transform.hasChanged && Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            FindObjectOfType<AudioManager>().Play("MovementSFX");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cat")
        {
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
            FindObjectOfType<AudioManager>().Play("CatSFX");
        }
        if (other.gameObject.tag == "TV")
        {
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
        }
    }
}