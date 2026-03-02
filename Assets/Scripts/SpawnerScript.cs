using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("Planet")]
    public Transform planet;

    [Header("Prefabs")]
    public GameObject moonPrefab;
    public GameObject pTrashPrefab;
    public GameObject lTrashPrefab;
    public GameObject satellitePrefab;

    [Header("Moon Settings")]
    public int moonCount = 6;
    public float moonMinDist = 5f;
    public float moonMaxDist = 10f;


    [Header("PTrash Settings")]
    public int trashCount = 8;
    public float trashMinDist = 3f;
    public float trashMaxDist = 5f;

    [Header("LTrash Settings")]
    public int lTrashCount = 2;

    void Start()
    {
        SpawnMoons();
        SpawnPTrash();
        SpawnSatellites();
    }


    void SpawnMoons()
    {
        for (int i = 0; i < moonCount; i++)
        {
            float dist = Random.Range(moonMinDist, moonMaxDist);
            float angle = (360f / moonCount) * i * Mathf.Deg2Rad;
            Vector3 pos = new Vector3 (Mathf.Cos(angle) * dist, 3f, Mathf.Sin(angle) * dist);

            GameObject moon = Instantiate(moonPrefab, pos, Random.rotation);
            moon.name = $"Moon_{i}";

            var orbit = moon.GetComponent<ProceduralOrbit>() ?? moon.AddComponent<ProceduralOrbit>();
            orbit.target = planet;
            orbit.orbitAxis = Vector3.up;
            orbit.orbitSpeed = Random.Range(20f, 60f);
            orbit.useKeplerSpeed = true;

            var rot = moon.GetComponent<SelfRotate>() ?? moon.AddComponent<SelfRotate>();
            rot.rotationAxis = new Vector3(Random.value, Random.value, Random.value);
            rot.speed = Random.Range(30f, 90f);

            SpawnLTrash(moon.transform);
        }

    }

    void SpawnLTrash(Transform moon)
    {
        for (int i = 0; i < lTrashCount; i++)
        {
            float dist = Random.Range(0.5f, 1f);
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

            Vector3 pos = moon.position + new Vector3(Mathf.Cos(angle) * dist, 0, Mathf.Sin(angle) * dist);

            GameObject trash = Instantiate(lTrashPrefab, pos, Random.rotation);
            trash.name = $"LunarTrash_{moon.name}_{i}";
            //trash.transform.SetParent(moon);

            var orbit = trash.GetComponent<ProceduralOrbit>() ?? trash.AddComponent<ProceduralOrbit>();
            orbit.target = moon;
            orbit.orbitAxis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            orbit.orbitSpeed = Random.Range(40f, 70f);
            orbit.useKeplerSpeed = true;

            var rot = trash.GetComponent<SelfRotate>() ?? trash.AddComponent<SelfRotate>();
            rot.rotationAxis = new Vector3(Random.value, Random.value, Random.value).normalized;
            rot.speed = Random.Range(50f, 150f);
        }

    }
    
    void SpawnPTrash()
    {
        for (int i = 0; i < trashCount; i++)
        {
            float dist = Random.Range(trashMinDist, trashMaxDist);
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector3 pos = new Vector3 (Mathf.Cos(angle) * dist, 0f, Mathf.Sin(angle) * dist);

            GameObject trash = Instantiate(pTrashPrefab, pos, Random.rotation);
            trash.name = $"SpaceTrash_{i}";

            var orbit = trash.GetComponent<ProceduralOrbit>() ?? trash.AddComponent<ProceduralOrbit>();
            orbit.target = planet;
            orbit.orbitAxis = Vector3.up;
            orbit.orbitSpeed = Random.Range(20f, 50f);
            orbit.useKeplerSpeed = true;

            var rot = trash.GetComponent<SelfRotate>() ?? trash.AddComponent<SelfRotate>();
            rot.rotationAxis = new Vector3(Random.value, Random.value, Random.value);
            rot.speed = Random.Range(40f, 120f);
        }

    }

    void SpawnSatellites()
    {
        Vector3[] axes = {
            new Vector3(1f, 0.5f, 0f).normalized,
            new Vector3(0f, 0.5f, 1f).normalized
        };

        for (int i = 0; i < 2; i++)
        {
            float dist = Random.Range(7f, 13f);
            Vector3 pos = new Vector3(dist, i * 3f + 2f, 0f);

            GameObject sat = Instantiate(satellitePrefab, pos, Random.rotation);
            sat.name = $"Satellite_{i}";
            //sat.transform.SetParent(planet);

            var orbit = sat.GetComponent<ProceduralOrbit>() ?? sat.AddComponent<ProceduralOrbit>();
            orbit.target = planet;
            orbit.orbitAxis = axes[i];
            orbit.orbitSpeed = Random.Range(15f, 35f);
            orbit.useKeplerSpeed = true;

            var rot = sat.GetComponent<SelfRotate>() ?? sat.AddComponent<SelfRotate>();
            rot.rotationAxis = Vector3.up;
            rot.speed = Random.Range(20f, 60f);
            
        }


    }
}

