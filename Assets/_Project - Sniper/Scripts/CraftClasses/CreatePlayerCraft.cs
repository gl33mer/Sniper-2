/*
 * to customise and build ship from start of game or when player docks
 */


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreatePlayerCraft : MonoBehaviour
{
    private PlayerManager newCraft;
    private PrefabLoader craftPrefab;

    void Awake()
    {
        craftPrefab = gameObject.GetComponent<PrefabLoader>();
        GameObject spawnCockpit = (GameObject)Instantiate(craftPrefab.PlayerSphere);
    }
}
