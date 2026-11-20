using UnityEngine;
using UnityEngine.UI;

public class EnemyBillboard : MonoBehaviour
{
    protected Transform mainCameraTransform;
    [SerializeField] protected Image EnemyVisual;
    [SerializeField] protected Sprite[] enemyDirections;
    [SerializeField] protected Transform enemyRoot; // used for calculating the facing direction for the correct sprite to show

    void Start()
    {
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        if (mainCameraTransform == null) return;

        transform.rotation = mainCameraTransform.rotation;

        Vector3 playerdirref = mainCameraTransform.position - transform.position;

        Vector2 camf = new Vector2(playerdirref.x, playerdirref.z).normalized;
        Vector2 rootf = new Vector2(enemyRoot.forward.x, enemyRoot.forward.z).normalized;

        float enemydir = Mathf.Atan2(rootf.y, rootf.x) * Mathf.Rad2Deg;
        float playdir = Mathf.Atan2(camf.y, camf.x) * Mathf.Rad2Deg;
        //Debug.Log("Enemy Dir: " + enemydir / 90);

        float finaldir = ((enemydir - playdir) + 180) % 360; // for tomorrow max: figure out how to correctly translate the difference of the 2 directions into the 360 degree range
        Debug.Log("final Dir: " + finaldir);

        int dirSprite = Mathf.FloorToInt((finaldir / 90));

        //EnemyVisual.sprite = enemyDirections[dirSprite];
        Debug.Log("PLayer Dir: " + dirSprite);
    }
}
