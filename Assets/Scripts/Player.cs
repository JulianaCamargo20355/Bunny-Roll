using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vel;
    public int contCenoura;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            contCenoura++;
            print("Cenouras: " + contCenoura);
            Destroy(trigger.gameObject);
        }
    }
}

