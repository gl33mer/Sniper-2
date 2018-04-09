using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Instance and Awake Method
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                GameObject go = new GameObject("_GameManager");
                _Instance = go.AddComponent<GameManager>();
            }
            return _Instance;
        }
    }
    private static GameManager _Instance;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
    }
    #endregion

    public GameObject _player;

    private void Start()
    {
        GameObject Player = Instantiate(_player);
        Player.transform.position = new Vector3(0, 0, 0);
    }
}
