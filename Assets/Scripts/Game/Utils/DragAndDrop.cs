using UnityEngine;

namespace SlotMacchine.Game.Domain.Utils
{
    public class DragAndDrop : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _offset;
        private Vector2 _startPointPosition;
        private GameObject _interactionObject;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            InitInteractionObject();
        }
        private void InitInteractionObject()
        {
            if (_camera == null)
            {
                return;
            }

            RaycastHit2D[] hits = Physics2D.RaycastAll(_camera.ScreenToWorldPoint(GetMousePosition()), Vector3.forward, 100f);
            foreach (RaycastHit2D hit in hits)
            {
                if (gameObject.GetInstanceID() != hit.transform.gameObject.GetInstanceID())
                {
                    _interactionObject = hit.transform.gameObject;
                    return;
                }
            }
        }

        public void OnMouseDown()
        {
            _startPointPosition = transform.position;

            var currentPosition = GetMousePosition();
            _offset = gameObject.transform.position -
                      _camera.ScreenToWorldPoint(currentPosition);
        }
        public void OnMouseDrag()
        {
            var newPosition = GetMousePosition();
            transform.position = _camera.ScreenToWorldPoint(newPosition) + _offset;
        }
        public void OnMouseUp()
        {
            transform.position = _startPointPosition;

            if (_interactionObject == null)
            {
                return;
            }

            InteractionObjectOnMouseDown();
        }

        private void InteractionObjectOnMouseDown()
        {
            if (!IsTouchingMouse(_interactionObject))
            {
                return;
            }

            //_interactionObject.transform.GetComponentOrThrow<IDragAndDroppable>().HandleDropEvent();
            //_interactionObject.GetComponent<SelectableController>()?.OnMouseDown();

            _interactionObject = null;
        }

        public bool IsTouchingMouse(GameObject gameObject)
        {
            if (gameObject == null)
            {
                return false;
            }

            var collider = gameObject.GetComponent<Collider2D>();
            if (collider == null)
            {
                return false;
            }

            Vector2 point = Camera.main.ScreenToWorldPoint(GetMousePosition());

            return collider.OverlapPoint(point);
        }

        private Vector3 GetMousePosition()
        {
            return new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        }
    }
}