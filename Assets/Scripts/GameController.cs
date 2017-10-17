using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject CharacterCamera;
    public GameObject Granny;
    private Vector3 m_spawnLocation  = new Vector3(0, 0, 0);

    private List<GameObject> m_characters = new List<GameObject>();

	// Use this for initialization
	void Start () 
    {
        GameObject newCharacter = SpawnNewCharacter();
        SetCharacterActive(newCharacter);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject newCharacter = SpawnNewCharacter();
            SetCharacterActive(newCharacter);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            int index = m_characters.FindIndex(a => a.GetComponent<CharacterMovement>().Active == true);
            index++;
            if (index == m_characters.Count)
                index = 0;
            SetCharacterActive(m_characters[index]);
        }
	}

    private GameObject SpawnNewCharacter()
    {
        Vector3 spawnLocation = new Vector3(m_spawnLocation.x, 1.5f, m_spawnLocation.z);
        while(Physics.CheckSphere(spawnLocation, 0.3f))
        {
            spawnLocation.x += 0.1f;
        }

        spawnLocation.y = 0.0f;

        GameObject newCharacter = Instantiate(Granny, spawnLocation, Quaternion.identity) as GameObject;
        m_characters.Add(newCharacter);
        return newCharacter;
    }

    private void SetCharacterActive(GameObject character)
    {
        foreach (GameObject go in m_characters)
        {
            go.GetComponent<CharacterMovement>().Active = (character == go);
        }
            
        CharacterCamera.GetComponent<CameraRigMovement>().SetTarget(character);
    }
       
}
