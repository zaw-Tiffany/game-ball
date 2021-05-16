using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;
    GameObject center;
    public bool hasPowerup=false;
    public float force = 15f;
    public GameObject Indicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        center = GameObject.Find("center");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(center.transform.forward * speed * forwardInput);
        Indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy") && hasPowerup)
        {
            Rigidbody enbody= col.gameObject.GetComponent<Rigidbody>();
            enbody.AddForce((col.gameObject.transform.position - transform.position) * force, ForceMode.Impulse);
        }
            if (col.gameObject.CompareTag("food"))
        {
            hasPowerup = true;
            Indicator.gameObject.SetActive(true);
            Destroy(col.gameObject);
        }
    }

}
