using UnityEngine;
using System.Collections;

public class CreateOnClickScript : MonoBehaviour
{
    [SerializeField]
    Camera _camera;

    [SerializeField]
    lifeGameScript _lifeGame;

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _lifeGame.pause();
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Element e = new Element(hit.collider.gameObject);
                e.createCellule();
                //MeshRenderer meshRenderer = (MeshRenderer)hit.collider.gameObject.GetComponent("MeshRenderer");
                //meshRenderer.enabled = true;

            }
        }
        _lifeGame.play();
        //_lifeGame.init();
    }

    // Update is called once per frame
    /*void OnMouseClickOnMouseDown()
    {
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = hit.point;
        }
        //go.transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);
    }*/
}
