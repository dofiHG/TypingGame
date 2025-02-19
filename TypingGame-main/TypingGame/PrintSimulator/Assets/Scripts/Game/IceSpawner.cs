using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _icePrefab;

    private const int _iceCount = 5;
    private float _startIcePosition = -630;
    private int _charsPerIce;
    private int _iceIndex;
    private Transform _iceParent;

    private bool[] _isSpawnedPrefab = new bool[_iceCount];

    private void Start()
    {
        _iceParent = GameObject.Find("GameElements").GetComponent<Transform>();
        _charsPerIce = TextGenerator.instance.currentPublicText.Length / _iceCount;
        IceMover.instance.steps = _charsPerIce;
        _iceIndex = 1;
        _isSpawnedPrefab[0] = true;
    }

    private void Update() => Spawn();

    private void Spawn()
    {
        float currentTextIndex = TextGenerator.instance.currentCharIndex;

        if (currentTextIndex > 0)
        {
            if (currentTextIndex % _charsPerIce == 0 && _isSpawnedPrefab[(int)(currentTextIndex / _charsPerIce)] == false)
            {
                _isSpawnedPrefab[(int)(currentTextIndex / _charsPerIce)] = true;
                _iceIndex++;
                GameObject newIce = Instantiate(_icePrefab, _iceParent);
                newIce.transform.localPosition = new Vector2(_startIcePosition + 310 * _iceIndex, -400);
            }
        }
    }
}
