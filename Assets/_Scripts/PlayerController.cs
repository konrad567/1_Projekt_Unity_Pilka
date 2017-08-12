using UnityEngine;
using System.Collections;
using UnityEngine.UI; //biblioteka do napisów

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count; //do zliczania wyniku

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; //bo na start 0 zebranych klockow
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed); //nadanie ruchu
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) //jesli dotkniemy obiektu z tagiem Pick Up
        {
            other.gameObject.SetActive(false); //wylaczenie obiektow ktore dotkniemy
            count = count + 1; //co kazde zebranie obiektu zwieksza nam wartosc o 1
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 5)
        {
            winText.text = "Wygrałeś!";
        }
    }

}
