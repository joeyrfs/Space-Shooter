using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour
{
    public float rotSpeed = 90f;
    Transform player;
        
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            // Procura o player pelo nome
            //Debug.Log(GameObject.Find("PlayerShip").transform.position); 

            // Procura o player's ship
            GameObject go =  GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        // Neste ponto procuramos o player, se ele existe ou não.
 
        if (player == null)
        {
            return;
        }

        // AQUI -- Sabemos que existe um player. Vai para cima dele!

        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desirerRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation =  Quaternion.RotateTowards(transform.rotation, desirerRot, rotSpeed * Time.deltaTime); 
    }
}
