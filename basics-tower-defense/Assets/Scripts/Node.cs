using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public GameObject turret;
    public Vector3 positionOffset;
    BuildManager buildManager;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {   
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;


        if(turret != null)
        {
            Debug.Log("Can't build on the current location! TODO: Display on screen");
            return;
        }


        //build a turret
        GameObject turretTobuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretTobuild, transform.position + positionOffset, transform.rotation);

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


}
