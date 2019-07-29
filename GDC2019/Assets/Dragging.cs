using UnityEngine;

public class Dragging : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire1") && MouseOver)
        {
            Vector3 MousePositionInWorld = GameObject.FindWithTag("SubCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(MousePositionInWorld.x, MousePositionInWorld.y, 3);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            foreach (Transform t in transform)
                t.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
            
        
    }
    bool MouseOver;
    private void OnMouseOver()
    {
        MouseOver = true;
    }
    private void OnMouseExit()
    {
        MouseOver = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        foreach (Transform t in transform)
            t.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
