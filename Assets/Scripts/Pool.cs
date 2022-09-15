using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _poolPrefab;
    [SerializeField] private Transform _childParent;
    [SerializeField] private int _poolCount;
    [SerializeField] private Vector3 _cementeryPosition;
    private GameObject[] _pool;

    private void Awake()
    {
        InicializarPool();


    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject[] GetPool()
    {
        return _pool;
    }


    public void InicializarPool()
    {
        _pool = new GameObject[_poolCount];
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = GameObject.Instantiate(_poolPrefab, _childParent);
            _pool[i].SetActive(false);
            _pool[i].transform.position = _cementeryPosition;
        }

    }
    public GameObject PoolRequest()
    {
        for (int i = 0; i < _pool.Length; i++)
        {
            if (!_pool[i].activeSelf)
            {
                return _pool[i];
            }
        }
        Debug.LogError("No child could be requested");
        return null;
    }
    public GameObject PoolRequest(Vector3 p_position, Quaternion p_direction)
    {
        for (int i = 0; i < _pool.Length; i++)
        {
            if (!_pool[i].activeSelf)
            {
                _pool[i].SetActive(true);
                _pool[i].transform.position = p_position;               
                _pool[i].transform.rotation = p_direction;
                return _pool[i];
            }
        }
        Debug.LogError("No child could be requested");
        return null;
    }

    public GameObject SetearFalse()
    {
        for (int i = 0; i < _pool.Length; i++)
        {
            if (!_pool[i].activeSelf)
            {
                _pool[i].transform.position = _cementeryPosition;
                return _pool[i];
            }
        }
        Debug.LogError("");
        return null;

    }
}
