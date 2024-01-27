using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    public int index = 0;

    [SerializeField] private List<GameObject> players = new List<GameObject>();

    public PlayerInputManager manager;
    
    // Start is called before the first frame update
    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = players[index];
    }

    public void SwitchNextSpawnCharacter(PlayerInput input)
    {
        manager.playerPrefab = players[index];
        index++;
    }
}
