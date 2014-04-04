using UnityEngine;
using System.Collections;

public class Element
{
    public GameObject _go;
    public int _generation;
    public bool _newBorn = false;
    public bool _dead = false;

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
        if (state)
        {
            _generation++;
        }
        else
        {
            getMeshRenderer().material.color = Color.red;
            _generation = 0;
            _newBorn = false;
            _dead = false;
        }
        getMeshRenderer().enabled = state;
    }
    public bool getState()
    {
        return getMeshRenderer().enabled;
    }
    public bool compareGen(Element a)
    {
        if (this._generation == a._generation)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void createCellule()
    {
        this.setState(true);
        if (_newBorn)
        {
            this.getMeshRenderer().material.color = Color.green;
        }
        else
        {
            this.getMeshRenderer().material.color = Color.blue;
        }
    }
}
