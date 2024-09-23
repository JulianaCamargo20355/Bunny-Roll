using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TelaJogo : MonoBehaviour
{
    public void CarregarCena(string Fase1)
    {
        SceneManager.LoadScene(Fase1);
    }
}
