using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateWorldScript : MonoBehaviour
{

    [SerializeField]
    GameObject _limit;
    [SerializeField]
    GameObject planePrefab;
    [SerializeField]
    lifeGameScript _lifeGame;

    //public GameObject[][] cellulTab = new GameObject[][]; //a gerer avec une taille fixe

    public List<List<GameObject>> _matrice = new List<List<GameObject>>();

    //int k = 0, l = 0;
    // Use this for initialization
    void Start()
    {
        Instantiate(_limit);
        //BoxCollider col = (BoxCollider)_limit.collider;
        float _xLimit = _limit.transform.localScale.x;
        float _zLimit = _limit.transform.localScale.z;
        Debug.Log(_xLimit);
        Debug.Log(_zLimit);

        for(int i = 0 ; i < _zLimit * 10 ; i += 10)
        {
            List<GameObject> _matriceTmp = new List<GameObject>();
            for(int j = 0 ; j < _xLimit * 10 ; j += 10)
            {
                Vector3 debut = new Vector3(_limit.transform.position.x - (_xLimit * 5) + 5, 0f, _limit.transform.position.z + ((_zLimit * 5) - 5));
                Vector3 newPos = new Vector3(debut.x + j, 1, debut.z - i);
                GameObject go = Instantiate(planePrefab, newPos, Quaternion.identity) as GameObject;
                _matriceTmp.Add(go);
            }
            _matrice.Add(_matriceTmp);
        }
        _lifeGame.init();
    }

}
