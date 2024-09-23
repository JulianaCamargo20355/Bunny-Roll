using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float vel;
    public int contCenoura = 0;
    public TMPro.TextMeshProUGUI contadorCenouras;
    public TMPro.TextMeshProUGUI tempo;
    float tempoRest = 30f;
    bool jogando = true;
    void Start()
    {
        AtualizarContadorCenouras();
    }

    // Update is called once per frame
    void Update()
    {

        if (jogando) 
        {
            tempoRest -= Time.deltaTime; 
            AtualizarTime(); 

            if (tempoRest <= 0f) 
            {
                VerificarDerrota();
            }
        }

        float moveX = Input.GetAxis("Horizontal") * vel * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * vel * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0f, moveZ), Space.World);

        if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (moveZ > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveZ < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Cenoura"))
        {
            IncrementarCenouras();
            contadorCenouras.text = "= " + contCenoura;
            print("Cenouras: " + contCenoura);
            Destroy(trigger.gameObject);
        }
    }

    private void IncrementarCenouras()
    {
        contCenoura++;
        AtualizarContadorCenouras();

        if (contCenoura >= 20)
        {
            VerificarVitoria();
        }
    }

    private void AtualizarContadorCenouras()
    {
        contadorCenouras.text = "= " + contCenoura;
    }

    private void AtualizarTime()
    {
        int segundosRestantes = Mathf.Max(0, Mathf.FloorToInt(tempoRest)); 
        tempo.text = "Segundos: " + segundosRestantes.ToString();
    }
    private void VerificarDerrota()
    {
        jogando = false; 

        if (contCenoura < 15) 
        {
            SceneManager.LoadScene("Lose"); 
        }
        else
        {
            SceneManager.LoadScene("Win"); 
        }
    }

    private void VerificarVitoria()
    {
        jogando = false; 
        SceneManager.LoadScene("Win"); 
    }
}

