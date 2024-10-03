using TMPro;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Material mat;
    private float distance;

    public float speed = 0.2f;
    public GameObject player;
    public GameObject textCollider;
    public TMP_Text text;
    public GameObject startSquare;

    private void Start() => mat = GetComponent<Renderer>().material;

    private void Update()
    {
        if (player.transform.position.x > 0)
        {
            player.GetComponent<SquareMover>().speed = 0;
            startSquare.transform.Translate(Vector2.left * Time.deltaTime);
            textCollider.transform.Translate(Vector2.left * Time.deltaTime);
            text.transform.Translate(Vector2.left * Time.deltaTime);
            distance += Time.deltaTime * speed;
            mat.SetTextureOffset("_MainTex", Vector2.right * distance);
            GameObject.Find("Main Camera").GetComponent<Transform>().position = new Vector2(player.transform.position.x, 0);
        }
    }
}
