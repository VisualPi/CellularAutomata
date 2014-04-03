using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lifeGameScript : MonoBehaviour
{
    [SerializeField]
    CreateWorldScript _world;
    //public List<List<MeshRenderer>> _matriceMesh = new List<List<MeshRenderer>>();
    List<List<int>> next = new List<List<int>>();
    int _voisin = 0;
    bool _play = true;
    int _generation = 0;
    float time = 0f;
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.1)
        {
            time = 0;
            if(_play)
            {
                //init();
                next.Clear();
                for(int i = 0 ; i < _world._matriceElem.Count ; i++)
                {
                    List<int> nextTemp = new List<int>();
                    for(int j = 0 ; j < _world._matriceElem[i].Count ; j++)
                    {
                        int genTmp = 0;
                        _voisin = 0;
                        if(j != _world._matriceElem[i].Count - 1)
                        {
                            if(_world._matriceElem[i][j + 1].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i][j + 1]))
                                {
                                    _voisin++;
                                }
                            }
                        }
                        if(j != 0)
                        {
                            if(_world._matriceElem[i][j - 1].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i][j - 1]))
                                {
                                    _voisin++;
                                }
                            }

                        }
                        if(i != 0)
                        {
                            if(_world._matriceElem[i - 1][j].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j]))
                                {
                                    _voisin++;
                                }
                            }
                            if(j != 0)
                            {
                                if(_world._matriceElem[i - 1][j - 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j - 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                            if(j != _world._matriceElem[i].Count - 1)
                            {
                                if(_world._matriceElem[i - 1][j + 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j + 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                        }
                        if(i != _world._matriceElem.Count - 1)
                        {
                            if(_world._matriceElem[i + 1][j].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j]))
                                {
                                    _voisin++;
                                }
                            }
                            if(j != 0)
                            {
                                if(_world._matriceElem[i + 1][j - 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j - 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                            if(j != _world._matriceElem[i].Count - 1)
                            {
                                if(_world._matriceElem[i + 1][j + 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j + 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                        }
                        if(_voisin >= 3)//NAISSANCE
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
            Debug.Log(_world._matriceElem[25][25]._generation);
            nextState(next);
        }
    }
    /*void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 100), "LIFE"))
        {
            if(_play)
            {
                //init();
                next.Clear();
                for(int i = 0 ; i < _world._matriceElem.Count ; i++)
                {
                    List<int> nextTemp = new List<int>();
                    for(int j = 0 ; j < _world._matriceElem[i].Count ; j++)
                    {
                        int genTmp = 0;
                        _voisin = 0;
                        if(j != _world._matriceElem[i].Count - 1)
                        {
                            if(_world._matriceElem[i][j + 1].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i][j + 1]))
                                {
                                    _voisin++;
                                }
                            }
                        }
                        if(j != 0)
                        {
                            if(_world._matriceElem[i][j - 1].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i][j - 1]))
                                {
                                    _voisin++;
                                }
                            }

                        }
                        if(i != 0)
                        {
                            if(_world._matriceElem[i - 1][j].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j]))
                                {
                                    _voisin++;
                                }
                            }
                            if(j != 0)
                            {
                                if(_world._matriceElem[i - 1][j - 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j - 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                            if(j != _world._matriceElem[i].Count - 1)
                            {
                                if(_world._matriceElem[i - 1][j + 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i - 1][j + 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                        }
                        if(i != _world._matriceElem.Count - 1)
                        {
                            if(_world._matriceElem[i + 1][j].getState())
                            {
                                if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j]))
                                {
                                    _voisin++;
                                }
                            }
                            if(j != 0)
                            {
                                if(_world._matriceElem[i + 1][j - 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j - 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                            if(j != _world._matriceElem[i].Count - 1)
                            {
                                if(_world._matriceElem[i + 1][j + 1].getState())
                                {
                                    if(_world._matriceElem[i][j].compareGen(_world._matriceElem[i + 1][j + 1]))
                                    {
                                        _voisin++;
                                    }
                                }
                            }
                        }
                        if(_voisin >= 2)//NAISSANCE
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
            Debug.Log(_world._matriceElem[25][25]._generation);
            nextState(next);

        }
    }*/
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
        for(int i = 0 ; i < _world._matriceElem.Count ; i++)
        {
            List<MeshRenderer> _matriceMeshTemp = new List<MeshRenderer>();
            for(int j = 0 ; j < _world._matriceElem[i].Count ; j++)
            {
                MeshRenderer mR = _world._matriceElem[i][j].getMeshRenderer();
                _matriceMeshTemp.Add(mR);
            }
            //_matriceMesh.Add(_matriceMeshTemp);
        }
    }
    void nextState(List<List<int>> tab)
    {
        Debug.Log(tab.Count);
        Debug.Log(tab[1].Count);
        for(int i = 0 ; i < tab.Count ; i++)
        {
            for(int j = 0 ; j < tab[i].Count ; j++)
            {
                if(tab[i][j] == 0)
                {
                    //_matriceMesh[i][j].enabled = false;
                    _world._matriceElem[i][j].setState(false);
                    //_world._matriceElem[i][j]._generation = 0; //dans setState
                }
                else if(tab[i][j] == 1)
                {
                    //_matriceMesh[i][j].enabled = true;
                    _world._matriceElem[i][j].setState(true);
                    //_world._matriceElem[i][j]._generation++; //dans setState
                }
            }
        }
        grewUp();
    }
    public void pause()
    {
        _play = false;
        time = 0;
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
                    //e._generation = _generation;
                    if(e._generation == 0)
                    {
                        e.getMeshRenderer().material.color = Color.red;
                    }
                    if(e._generation == 1)
                    {
                        e.getMeshRenderer().material.color = Color.blue;
                    }
                    if(e._generation == 2)
                    {
                        e.getMeshRenderer().material.color = Color.green;
                    }
                    if(e._generation == 3)
                    {
                        e.getMeshRenderer().material.color = Color.cyan;
                    }
                    if(e._generation == 4)
                    {
                        e.getMeshRenderer().material.color = Color.yellow;
                    }
                    if(e._generation == 5)
                    {
                        e.getMeshRenderer().material.color = Color.black;
                    }
                }
            }
        }

    }
}
