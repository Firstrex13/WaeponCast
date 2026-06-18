using TMPro;
using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _aimText;
    private void Start()
    {
        Destroy(_aimText.gameObject, _aimText.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
