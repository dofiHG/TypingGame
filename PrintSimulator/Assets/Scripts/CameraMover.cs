using TMPro;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Material mat;
    private float distance;

    public static CameraMover instance;
    public float speed = 0.2f;
    public GameObject player;
    public GameObject textCollider;
    public TMP_Text text;
    public GameObject startSquare;
    public float environmentSpeed;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        environmentSpeed = ChooseSpeed.instance.speed;
    }

    private void Start() => mat = GetComponent<Renderer>().material;

    private void Update()
    {
        if (player.transform.position.x > 0)
        {
            player.GetComponent<SquareMover>().speed = 0;
            startSquare.transform.Translate(new Vector2(-environmentSpeed, 0) * Time.deltaTime);
            textCollider.transform.Translate(new Vector2(-environmentSpeed, 0) * Time.deltaTime);
            text.transform.Translate(new Vector2(-environmentSpeed, 0) * Time.deltaTime);
            distance += Time.deltaTime * speed;
            mat.SetTextureOffset("_MainTex", new Vector2(-environmentSpeed, 0) * distance);
            GameObject.Find("Main Camera").GetComponent<Transform>().position = new Vector2(player.transform.position.x, 0);
        }
    }
}
