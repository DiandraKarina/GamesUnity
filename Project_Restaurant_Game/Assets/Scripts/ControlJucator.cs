using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlJucator : MonoBehaviour
{
    public float viteza;
    public Rigidbody corpulJucatorului;
   

    public UnityEngine.UI.Text litereColectate;
    private string litereleMele;

    public UnityEngine.UI.Button butonMaiJoacaOdata;
    public UnityEngine.UI.Button butonMeniu;
    // Start is called before the first frame update
    void Start()
    {
        
        litereleMele = "";

        butonMaiJoacaOdata.gameObject.SetActive(false);
        butonMeniu.gameObject.SetActive(false);

    }

    void FixedUpdate()
    {
        float miscareOrizontala = Input.GetAxis("Horizontal");
        float miscareVerticala = Input.GetAxis("Vertical");


        Vector3 directieMiscareSferaJucator = new Vector3(miscareOrizontala, 0.0f, miscareVerticala);
        corpulJucatorului.AddForce(directieMiscareSferaJucator * viteza * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LiteraColectabila")
        {
            other.gameObject.SetActive(false);

            litereleMele = litereleMele + other.gameObject.GetComponent<TextMesh>().text;
            litereColectate.text = "You have: " + litereleMele;
        }

        if (litereleMele.Equals("BURGER"))
        {
            butonMaiJoacaOdata.gameObject.SetActive(true);
            butonMeniu.gameObject.SetActive(true);

            butonMaiJoacaOdata.GetComponentInChildren<Text>().text = " Congratulations - Play Again";
            Time.timeScale = 0;

        }
        else
        {
            if (litereleMele.Length > 5)
            {
                butonMaiJoacaOdata.gameObject.SetActive(true);
                butonMeniu.gameObject.SetActive(true);
                butonMaiJoacaOdata.GetComponentInChildren<Text>().text = "This is not correct - Play Again";
                Time.timeScale = 0;
            }
            else
            {
                butonMaiJoacaOdata.gameObject.SetActive(false);
                butonMeniu.gameObject.SetActive(false);
            }
        }
    }
}