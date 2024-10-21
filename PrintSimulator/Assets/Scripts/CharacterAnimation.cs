using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData) => gameObject.GetComponent<Animator>().SetInteger("State", 1);

    public void OnPointerExit(PointerEventData eventData) => gameObject.GetComponent<Animator>().SetInteger("State", 0);
}
