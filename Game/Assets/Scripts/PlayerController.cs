using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject attack;

    Transform trans;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2();
        movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movement.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb2d.AddForce(movement, ForceMode2D.Impulse);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject hit = (GameObject)Instantiate(attack, trans.position + new Vector3(0.7f, 0f, 0f), Quaternion.identity, trans);
            Destroy(hit, 0.1f);
        }
    }
}
