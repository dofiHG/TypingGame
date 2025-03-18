using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceDestroyer : MonoBehaviour
{
    private Vector2 _offset = new Vector2(210, 0);

    private GameObject _ice;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            GameObject _ice = collision.gameObject;

            _ice.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            _ice.GetComponent<Rigidbody2D>().gravityScale = 5;
            _ice.GetComponent<Image>().color = new Color32(255, 255, 255, 128);
            _ice.GetComponent<BoxCollider2D>().enabled = false;
            Vector2 forcePosition = (Vector2)transform.localPosition - _offset;
            _ice.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.down * 0.05f, forcePosition);
            _ice.GetComponent<IceMoverBack>().speed *= 15;

            Invoke(nameof(DestroyIce), 3);
        }
    }

    private void DestroyIce() => Destroy(_ice);
}
