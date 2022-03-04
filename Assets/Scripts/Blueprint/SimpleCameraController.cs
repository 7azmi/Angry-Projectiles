using UnityEngine;

namespace Blueprint
{
    public class SimpleCameraController : MonoBehaviour
    {
        public float power = 0.2f;
        private Camera cam;
        float horizontal;
        float vertical;

        private void Awake()
        {
            cam = Camera.main;
        }

        void FixedUpdate()
        {
            //horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;

            horizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
            vertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime;

            Vector2 dir = new Vector2(horizontal, vertical).normalized * power;

            cam.transform.position += (Vector3)dir;


            if (Input.GetKey(KeyCode.Q))
            {
                if (!(cam.orthographicSize - Time.fixedDeltaTime * 50 < 1)) cam.orthographicSize -= Time.fixedDeltaTime * 50;
            }
        
        

            if (Input.GetKey(KeyCode.E)) cam.orthographicSize += Time.fixedDeltaTime * 50;
        }
    }
}
