﻿using UnityEngine;
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
        if(time >= 0.08)
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
                        if(_voisin == 3)//NAISSANCE
                        {
                            //_world._matriceElem[i][j]._generation = 0;
                            if(_world._matriceElem[i][j].getState())
                            {
                                nextTemp.Add(1);//stayAlive
                            }
                            else
                            {
                                nextTemp.Add(2);//newBorn
                            }
                        }
                        else if(_voisin == 2)
                        {
                            //_world._matriceElem[i][j]._generation = 0;
                            if(_world._matriceElem[i][j].getState())
                            {
                                nextTemp.Add(1);//stayAlive
                            }
                            else//MORT
                            {
                                nextTemp.Add(0);//death
                            }
                        }
                        else
                        {
                            nextTemp.Add(0);
                        }
                    }
                    _voisin = 0;
                    next.Add(nextTemp);
                }
            }
            nextState(next);
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
                if(tab[i][j] == 0)//death
                {
                    _world._matriceElem[i][j].setState(false);
                }
                else if(tab[i][j] == 1)//stayAlive
                {
                    if(_world._matriceElem[i][j]._newBorn == true)
                    {
                        _world._matriceElem[i][j].setState(true);
                        //_world._matriceElem[i][j]._newBorn = false;
                        _world._matriceElem[i][j].getMeshRenderer().material.color = Color.blue;
                    }
                }
                else if(tab[i][j] == 2)//newBorn
                {
                    _world._matriceElem[i][j]._newBorn = true;
                    _world._matriceElem[i][j].createCellule();
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
                    if(e._newBorn)
                    {
                        e._newBorn = false;
                        e.getMeshRenderer().material.color = Color.blue;
                    }
                }
            }
        }

    }
}
