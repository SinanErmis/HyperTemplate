using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Rhodos
{
    public class FinishWall : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] bricks;
        [SerializeField] private GameObject wholeCube;
        [SerializeField] private TextMeshPro text;
        [SerializeField] private float forceMultiplier = 100f;
        [SerializeField] private UnityEvent<Collider> triggerEvent;

        public void SetColor(Color c)
        {
            foreach (var brick in bricks)
            {
                brick.GetComponent<Renderer>().material.color = c;
            }

            wholeCube.GetComponent<Renderer>().material.color = c;
        }

        public void SetText(string s) => text.text = s;

        public void Break()
        {
            GetComponent<Collider>().enabled = false;
            wholeCube.SetActive(false);
            foreach (var rb in bricks)
            {
                rb.gameObject.SetActive(true);
                rb.AddForce(rb.transform.localPosition * forceMultiplier, ForceMode.Force);
            }

            text.gameObject.SetActive(false);
            this.DelayedAction(3f, () => gameObject.SetActive(false));
        }

        private void OnTriggerEnter(Collider other)
        {
            triggerEvent?.Invoke(other);
        }
    }

}