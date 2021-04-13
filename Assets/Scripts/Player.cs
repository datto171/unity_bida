using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rid;
    Vector3 direction;

    [SerializeField]
    float moveSpeed = 500f;
    public int points = 0;

    public Text scoretext;
    public Text wintext;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();
        scoretext.text = "Score:" + points.ToString();
        wintext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        direction.x = h;
        direction.z = v; //(0.0.0)

        rid.AddForce(direction.normalized * Time.deltaTime * moveSpeed);

        if(points >= 4)
        {
            wintext.text = "WIN!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cube"))
        {
            points += 1;
            other.gameObject.SetActive(false);
            scoretext.text = "Score:" + points.ToString();
        }
    }
}
