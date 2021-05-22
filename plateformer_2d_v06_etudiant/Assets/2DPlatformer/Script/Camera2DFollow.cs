using UnityEngine;

//namespace UnitySampleAssets._2D
//{

    public class Camera2DFollow : MonoBehaviour
    {
        [SerializeField]
        private GameObject debutGame;
        [SerializeField]
        private GameObject finGame;
        [SerializeField] 
        private GameObject nvSol;
        [SerializeField] 
        private Vector3 offset;

        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float offsetZ;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;

        private float viewZone;
        private float viewZone2;


        private void Start()
        {
            lastTargetPosition = target.position;
            offsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        private void Update()
        {
            if (target == null)
            {
                return;
            }
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - lastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                lookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward*offsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);


            // limitation camera
            viewZone = (Camera.main.orthographicSize * Screen.width) / Screen.height;

            float miniY = nvSol.transform.position.y + Camera.main.orthographicSize;
            float newPosY = Mathf.Clamp(newPos.y, miniY, Mathf.Infinity);
            newPos.y = newPosY;

            float miniX = debutGame.transform.position.x;
            float maxX = finGame.transform.position.x;
            float newPosX = Mathf.Clamp(newPos.x, miniX+viewZone, maxX-viewZone);
            newPos.x= newPosX;

            transform.position = newPos;

            lastTargetPosition = target.position;
        }
    }
//}