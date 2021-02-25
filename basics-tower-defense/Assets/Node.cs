
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {   
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build on the current location! TODO: Display on screen");
            return;
        }


        //build a turret
        GameObject turretTobuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretTobuild, transform.position, transform.rotation);

    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


}
