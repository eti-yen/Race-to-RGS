using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Transform trans;

    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
    }
	
    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2();
        movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movement.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        trans.Translate(movement);
    }
}
