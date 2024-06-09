using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class PlayerMouseMove : MonoBehaviour
{
    private PlayerInputManager _inputManager;
    private NavMeshAgent _agent;
    private Animator _animator;
    private void Awake()
    {
        _inputManager = GetComponent<PlayerInputManager>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _inputManager.MouseClickInputPerformed += PlayerMouseMove_MouseClickInputPerformed;
        _inputManager.MouseClickInputCanceled += PlayerMouse_MouseClickInputCanceled;
    }

    private void OnDisable()
    {
        _inputManager.MouseClickInputPerformed -= PlayerMouseMove_MouseClickInputPerformed;
        _inputManager.MouseClickInputCanceled -= PlayerMouse_MouseClickInputCanceled;
    }

    private void PlayerMouseMove_MouseClickInputPerformed()
    {
        StartCoroutine(MovePlayer());
        StartAgent();
    }

    private void PlayerMouse_MouseClickInputCanceled()
    {
        StopAllCoroutines();
        StopAgent();
    }

    private IEnumerator MovePlayer()
    {
        while (true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                NavMeshPath path = new();
                _agent.CalculatePath(hit.point, path);

                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    if (IsPathClear(path))
                    {
                        _agent.SetDestination(hit.point);
                    }
                }
            }

            yield return null;
        }
    }

    private bool IsPathClear(NavMeshPath path)
    {
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Vector3 start = path.corners[i];
            Vector3 end = path.corners[i + 1];

            if (Physics.Linecast(start, end))
            {
                return false;
            }
        }

        return true;
    }

    private void StartAgent()
    {
        _agent.isStopped = false;
        _animator.SetBool("Is Moving", true);
    }

    private void StopAgent()
    {
        _agent.isStopped = true;
        _animator.SetBool("Is Moving", false);
    }
}
