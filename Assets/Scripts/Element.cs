using UnityEngine;
using System.Collections;

public class Element
{
    public GameObject _go;
    public int _generation;

    public Element(GameObject go, int generation = 0)
    {
        _go = go;
        _generation = generation;
    }
    public MeshRenderer getMeshRenderer()
    {
        return (MeshRenderer)_go.GetComponent("MeshRenderer");
    }
    public void setState(bool state)
    {
        getMeshRenderer().enabled = state;
        if(state)
        {
            _generation++;
        }
        else
        {
            _generation = 0;
        }
    }
    public bool getState()
    {
        return getMeshRenderer().enabled;
    }
    public bool compareGen(Element a)
    {
        if(this._generation == a._generation)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
