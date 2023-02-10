using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Range(0, 100)]
    [SerializeField] private int _flockSize;
    public int flockSize { get { return _flockSize; } private set { } }
    [SerializeField] private TextMeshProUGUI textFlockSize;
    
    private int MaxFlockSize = 100;
    private int MinFlockSize = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void SetFlockSize()
    {
        if (Input.GetKey(KeyCode.T) && flockSize < MaxFlockSize)
        {
            _flockSize++;
        }
        else if (Input.GetKey(KeyCode.G) && flockSize > MinFlockSize)
        {
            _flockSize--;
        }
        textFlockSize.text = "Flock size: " + flockSize;
    }
    private void Update()
    {
        SetFlockSize();
    }
}
