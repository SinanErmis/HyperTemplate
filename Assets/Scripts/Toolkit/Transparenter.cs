using UnityEngine;

namespace Rhodos.Toolkit
{
    /// <summary>
    /// Transparenter script must be added to a game object for being affected by invisible mask shader.
    /// </summary>
    public class Transparenter : MonoBehaviour
    {
        private void Start()
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (var rend in renderers)
            { 
                rend.material.renderQueue = 3002;
            }

        }
        
    }
}