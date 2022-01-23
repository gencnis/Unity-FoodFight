using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

    public GameObject player;
    public Transform wallTransform;
    public Vector3 locationSetter;
    public Collider[] walls;
    public Renderer[] colors;
    public Collider Egress;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        wallTransform = GetComponent<Transform>();
        locationSetter = new Vector3(0f, 0f, 0f);
        //Get the colliders from the walls from our obstruction
        walls = GetComponentsInChildren<Collider>();
        colors = GetComponentsInChildren<Renderer>();
        Egress = walls[Random.Range(0, 3)];
        Egress.isTrigger = true;
        //HauntThePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setExit()
    {
        foreach (Renderer r in colors)
        {
            r.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        Egress.isTrigger = false;
        Egress = walls[Random.Range(0, 3)];
        Egress.isTrigger = true;

    }
    public void HauntThePlayer()
    {
        wallTransform.localScale = player.transform.localScale + Vector3.one;
        locationSetter.Set(player.transform.position.x + (4.5f * wallTransform.localScale.x ), (-1 * wallTransform.localScale.y), player.transform.position.z);
        wallTransform.position = locationSetter;
        setExit();



    }
}
