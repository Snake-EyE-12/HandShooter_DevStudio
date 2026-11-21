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

        transform.rotation = Quaternion.Euler(0, mainCameraTransform.rotation.eulerAngles.y, 0);

        Vector3 playerposref = mainCameraTransform.position - transform.position;

        Vector2 enemydir = new Vector2(enemyRoot.forward.x, enemyRoot.forward.z).normalized;
        Vector2 playerdir = new Vector2(playerposref.x, playerposref.z).normalized;

        // get the angle the enemy is facing
        // get the angle the player is in relation to the enemy
        float enemyangle = Mathf.Atan2(enemydir.y, enemydir.x) * Mathf.Rad2Deg;
        float playerangle = Mathf.Atan2(playerdir.y, playerdir.x) * Mathf.Rad2Deg;

        // find the difference of the two angles, then put them between 0-360 degrees
        // and add a 45 degree offset
        float finaldir = ((playerangle - enemyangle) + 360 + 45) % 360;

        // put the 0-360 degrees into the 0-3 int range
        int dirSprite = Mathf.FloorToInt((finaldir) / 90);
        EnemyVisual.sprite = enemyDirections[dirSprite];
    }
}
