using UnityEngine;
using UnityEngine.UI;

public class IceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _icePrefab;
    [SerializeField] private GameObject _player;

    private const int _iceCount = 5;
    private float _startIcePosition = -630;
    private int _iceIndex;
    private Transform _iceParent;
    private bool[] _isSpawnedPrefab = new bool[_iceCount];

    public int charsPerIce;

    private void Awake()
    {
        _iceParent = GameObject.Find("GameElements").GetComponent<Transform>();
        
        _iceIndex = 1;
        _isSpawnedPrefab[0] = true;
    }

    private void Update()
    {
        Spawn();
        charsPerIce = TextGenerator.instance.currentPublicText.Length / _iceCount;
    }
    
    private void Spawn()
    {
        float currentTextIndex = TextGenerator.instance.currentCharIndex;

        if (currentTextIndex > 0)
        {
            if ((int)(currentTextIndex % charsPerIce) == 0 && _isSpawnedPrefab[(int)((currentTextIndex + 1) / charsPerIce)] == false)
            {
                _isSpawnedPrefab[(int)((currentTextIndex + 1) / charsPerIce)] = true;
                _iceIndex++;
                GameObject newIce = Instantiate(_icePrefab, _iceParent);
                newIce.transform.SetSiblingIndex(_player.transform.GetSiblingIndex() - 1);
                newIce.transform.localPosition = new Vector2(_startIcePosition + 310 * _iceIndex, -400);
                newIce.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 128);
            }
        }
    }
}
