
using UnityEngine;
public class InteractableObject : MonoBehaviour
{
    [SerializeField] private Transform _interactPoint;
    [SerializeField] private float _interactPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private string inputControl;

    private readonly Collider[] _colliders = new Collider[1];
    [SerializeField] private int _numFound;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
     }
    private void Update()
     {
        _numFound = Physics.OverlapSphereNonAlloc(_interactPoint.position, _interactPointRadius, _colliders, _interactableMask);
    

    if (_numFound > 0)
    {
        var interactable = _colliders[0].GetComponent<IFInteractable>();

        if (interactable != null && Input.GetButton(inputControl))
        {
            animator.Play("Interact");
            interactable.Interact(this);
            

        }
    }
     }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactPoint.position, _interactPointRadius);
    }
}
