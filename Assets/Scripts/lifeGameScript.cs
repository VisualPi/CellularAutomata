using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lifeGameScript : MonoBehaviour
{
    [SerializeField]
    CreateWorldScript _world;
    public List<List<MeshRenderer>> _matriceMesh = new List<List<MeshRenderer>>();
    List<List<int>> next = new List<List<int>>();
    int _voisin = 0;
    bool _play = true;
    int _generation = 0;
    /*void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "LIFE"))
        {
            if (_play)
            {
                init();
                next.Clear();
                for (int i = 0; i < _matriceMesh.Count; i++)
                {
                    List<int> nextTemp = new List<int>();
                    for (int j = 0; j < _matriceMesh[i].Count; j++)
                    {
                        _voisin = 0;
                        if (j != _matriceMesh[i].Count - 1)
                        {
                            if (_matriceMesh[i][j + 1].enabled == true)
                            {
                                //Debug.Log("VOISIN ++");
                                _voisin++;
                            }
                        }
                        if (j != 0)
                        {
                            if (_matriceMesh[i][j - 1].enabled == true)
                            {
                                //Debug.Log("VOISIN ++");
                                _voisin++;
                            }

                        }
                        if (i != 0)
                        {
                            if (_matriceMesh[i - 1][j].enabled == true)
                            {
                                //Debug.Log("VOISON ++");
                                _voisin++;
                            }
                            if (j != 0)
                            {
                                if (_matriceMesh[i - 1][j - 1].enabled == true)
                                {
                                    //Debug.Log("VOISON ++");
                                    _voisin++;
                                }
                            }
                            if (j != _matriceMesh[i].Count - 1)
                            {
                                if (_matriceMesh[i - 1][j + 1].enabled == true)
                                {
                                    //Debug.Log("VOISON ++");
                                    _voisin++;
                                }
                            }
                        }
                        if (i != _matriceMesh.Count - 1)
                        {
                            if (_matriceMesh[i + 1][j].enabled == true)
                            {
                                //Debug.Log("VOISON ++");
                                _voisin++;
                            }
                            if (j != 0)
                            {
                                if (_matriceMesh[i + 1][j - 1].enabled == true)
                                {
                                    //Debug.Log("VOISON ++");
                                    _voisin++;
                                }
                            }
                            if (j != _matriceMesh[i].Count - 1)
                            {
                                if (_matriceMesh[i + 1][j + 1].enabled == true)
                                {
                                    //Debug.Log("VOISON ++");
                                    _voisin++;
                                }
                            }

                        }
                        if (_voisin >= 2)//NAISSANCE
                        {
                            nextTemp.Add(1);
                            //_matriceMesh[i][j].enabled = true;
                        }
                        else//MORT
                        {
                            nextTemp.Add(0);
                            //_matriceMesh[i][j].enabled = false;
                        }
                    }
                    _voisin = 0;
                    next.Add(nextTemp);
                }
            }
            nextState(next);
        }
    }*/
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "LIFE"))
        {
            if (_play)
            {
                init();
                next.Clear();
                for (int i = 0; i < _world._matriceElem.Count; i++)
                {
                    List<int> nextTemp = new List<int>();
                    for (int j = 0; j < _world._matriceElem[i].Count; j++)
                    {
                        int genTmp = 0;
                        _voisin = 0;
                        if (j != _world._matriceElem[i].Count - 1)
                        {
                            if (_world._matriceElem[i][j + 1].getState())
                            {
                                if (_world._matriceElem[i][j].compareGen(_world._matriceElem[i][j + 1]))
                                {
                                    _voisin++;
                                }
                            }
                        }
                        if (j != 0)
                        {
                            if (_world._matriceElem[i][j - 1].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i][j - 1]))
                                {
                                    _voisin++;
                                }
                            }

                        }
                        if (i != 0)
                        {
                            if (_world._matriceElem[i - 1][j].getState())
                            {
                                if (_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j]))
                                {
                                    _voisin++;
                                }
                            }
                            if (j != 0)
                            {
                                if (_world._matriceElem[i - 1][j - 1].getState())
                                {
                                    if (_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j - 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                            if (j != _world._matriceElem[i].Count - 1)
                            {
                                if (_world._matriceElem[i - 1][j + 1].getState())
                                {
                                    if (_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j + 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                        }
                        if (i != _matriceMesh.Count - 1)
                        {
                            if (_world._matriceElem[i + 1][j].getState())
                            {
                                if (_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j]))
                                {
                                    _voisin++;
                                }
                            }
                            if (j != 0)
                            {
                                if (_world._matriceElem[i + 1][j - 1].getState())
                                {
                                    if (_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j - 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                            if (j != _world._matriceElem[i].Count - 1)
                            {
                                if (_world._matriceElem[i + 1][j + 1].getState())
                                {
                                    if (_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j + 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                        }
                        if (_voisin >= 2)//NAISSANCE
                        {
                            //_world._matriceElem[i][j]._generation = 0;
                            nextTemp.Add(1);
                        }
                        else//MORT
                        {
                            //_world._matriceElem[i][j]._generation = 0;
                            nextTemp.Add(0);
                        }
                    }
                    _voisin = 0;
                    next.Add(nextTemp);
                }
            }
            nextState(next);
            _generation++;
        }
    }
    public void init()
    {
        /*for (int i = 0; i < _world._matrice.Count; i++)
        {
            List<MeshRenderer> _matriceMeshTemp = new List<MeshRenderer>();
            for (int j = 0; j < _world._matrice[i].Count; j++)
            {
                MeshRenderer mR = (MeshRenderer)_world._matrice[i][j].GetComponent("MeshRenderer");
                _matriceMeshTemp.Add(mR);
            }
            _matriceMesh.Add(_matriceMeshTemp);
        }*/
        for (int i = 0; i < _world._matriceElem.Count; i++)
        {
            List<MeshRenderer> _matriceMeshTemp = new List<MeshRenderer>();
            for (int j = 0; j < _world._matriceElem[i].Count; j++)
            {
                MeshRenderer mR = _world._matriceElem[i][j].getMeshRenderer();
                _matriceMeshTemp.Add(mR);
            }
            _matriceMesh.Add(_matriceMeshTemp);
        }
    }
    void nextState(List<List<int>> tab)
    {
        Debug.Log(tab.Count);
        Debug.Log(tab[1].Count);
        for (int i = 0; i < tab.Count; i++)
        {
            for (int j = 0; j < tab[i].Count; j++)
            {
                if (tab[i][j] == 0)
                {
                    //_matriceMesh[i][j].enabled = false;
                    _world._matriceElem[i][j].setState(false);
                }
                else if (tab[i][j] == 1)
                {
                    //_matriceMesh[i][j].enabled = true;
                    _world._matriceElem[i][j].setState(true);
                }
            }
        }
    }
    public void pause()
    {
        _play = false;
    }
    public void play()
    {
        _play = true;
    }
    public void grewUp()
    {
        for(int i = 0 ; i < _world._matriceElem.Count ; i++)
        {
            foreach(Element e in _world._matriceElem[i])
            {
                if(e.getState())
                {
                    e._generation = _generation;
                }
            }
        }
        
    }
}
