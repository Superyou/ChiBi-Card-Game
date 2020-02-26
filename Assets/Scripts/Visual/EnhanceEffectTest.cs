using UnityEngine;
using System.Collections;

public class EnhanceEffectTest : MonoBehaviour {

    public GameObject EnhancePrefab;
    public static EnhanceEffectTest Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            DamageEffect.CreateDamageEffect(transform.position, Random.Range(1, 7));
    }
}
