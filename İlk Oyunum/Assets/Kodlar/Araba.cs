using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Araba : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rigid;
    public float arabaHiz;
    int puan;
    public Text puanText;
    public Text süreText;
    public Text uyariText;
    Vector3 fark;
    Vector3 toplam;
    public GameObject kamera;
    float zaman;
    int sayac;
 
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        fark = kamera.transform.position - transform.position;

        uyariText.text = "Oyunu Bitirmek için 15 saniyen var.";
    }

    // Update is called once per frame
    void Update()
    {
        ArabaHareketEttir();
        ZamanYazdir();
        puanText.text = "Puan :" + puan.ToString();
        süreText.text = "Süre :" + sayac;

        toplam = transform.position + fark;
        kamera.transform.position = new Vector3(toplam.x, kamera.transform.position.y, kamera.transform.position.z);

        if (sayac == 1)
        {
            uyariText.gameObject.SetActive(false);
        }
        else if (sayac == 15) 
        {
            uyariText.gameObject.SetActive(true);
            uyariText.text = "GAME OVER";
        }
        else if(sayac==16)
        {
            SceneManager.LoadScene(0);
        }

    }

    void ArabaHareketEttir()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigid.AddForce(new Vector3(horizontal * arabaHiz, 0, 0));
    }
    void ZamanYazdir()
    {
        zaman += Time.deltaTime;
        if (zaman > 1)
        {
            sayac++;
            zaman = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "elmas")
        {
            puan = puan + 3;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Finish") 
        {
            uyariText.gameObject.SetActive(true);
            uyariText.text = "WIN";
            SceneManager.LoadScene(0);
        }
    }
   
}
