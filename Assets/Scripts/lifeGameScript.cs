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
    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 100), "LIFE"))
        {
        init();
        next.Clear();
            for(int i = 0 ; i < _matriceMesh.Count ; i++)
            {
                List<int> nextTemp = new List<int>();
                for(int j = 0 ; j < _matriceMesh[i].Count ; j++)
                {
                    _voisin = 0;
                    if(j != _matriceMesh[i].Count - 1)
                    {
                        if(_matriceMesh[i][j + 1].enabled == true)
                        {
                            //Debug.Log("VOISIN ++");
                            _voisin++;
                        }
                    }
                    if(j != 0)
                    {
                        if(_matriceMesh[i][j - 1].enabled == true)
                        {
                            //Debug.Log("VOISIN ++");
                            _voisin++;
                        }

                    }
                    if(i != 0)
                    {
                        if(_matriceMesh[i - 1][j].enabled == true)
                        {
                            //Debug.Log("VOISON ++");
                            _voisin++;
                        }
                        if(j != 0)
                        {
                            if(_matriceMesh[i - 1][j - 1].enabled == true)
                            {
                                //Debug.Log("VOISON ++");
                                _voisin++;
                            }
                        }
                        if(j != _matriceMesh[i].Count - 1)
                        {
                            if(_matriceMesh[i - 1][j + 1].enabled == true)
                            {
                                //Debug.Log("VOISON ++");
                                _voisin++;
                            }
                        }
                    }
                    if(i != _matriceMesh.Count - 1)
                    {
                        if(_matriceMesh[i + 1][j].enabled == true)
                        {
                            //Debug.Log("VOISON ++");
                            _voisin++;
                        }
                        if(j != 0)
                        {
                            if(_matriceMesh[i + 1][j - 1].enabled == true)
                            {
                                //Debug.Log("VOISON ++");
                                _voisin++;
                            }
                        }
                        if(j != _matriceMesh[i].Count - 1)
                        {
                            if(_matriceMesh[i + 1][j + 1].enabled == true)
                            {
                                //Debug.Log("VOISON ++");
                                _voisin++;
                            }
                        }

                    }
                    if(_voisin >= 2)//NAISSANCE
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
    public void init()
    {
        for(int i = 0 ; i < _world._matrice.Count ; i++)
        {
            List<MeshRenderer> _matriceMeshTemp = new List<MeshRenderer>();
            for(int j = 0 ; j < _world._matrice[i].Count ; j++)
            {
                MeshRenderer mR = (MeshRenderer)_world._matrice[i][j].GetComponent("MeshRenderer");
                _matriceMeshTemp.Add(mR);
            }
            _matriceMesh.Add(_matriceMeshTemp);
        }
    }
    void nextState(List<List<int>> tab)
    {
        Debug.Log(tab.Count);
        Debug.Log(tab[1].Count);
        for (int i = 0 ; i < tab.Count ; i++)
        {
            for (int j = 0 ; j < tab[i].Count ; j++)
            {
                if(tab[i][j] == 0)
                {
                    _matriceMesh[i][j].enabled = false;
                }
                else if(tab[i][j] == 1)
                {
                    _matriceMesh[i][j].enabled = true;
                }
            }
        }
    }
}
