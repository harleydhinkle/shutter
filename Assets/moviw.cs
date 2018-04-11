using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class bandey
{
    public float xMin, xMax, yMin, yMax;
}
public class moviw : MonoBehaviour {
    public float speed;
    public Rigidbody2D fire;
    public float speed2;
    public float tilt;
    public bandey boundary;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Rigidbody2D clone = Instantiate(fire, gameObject.transform.position,gameObject.transform.rotation) as Rigidbody2D;
            clone.velocity = transform.up * speed;
        }
	}
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed2;

        GetComponent<Rigidbody2D>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
        );
    }
}
