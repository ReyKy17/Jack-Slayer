using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabMusuh;          // urutan: Zombie, Archer, Knight
    public int[] bobot = { 4, 3, 1 };         // komposisi sama dengan asumsi Income di Bagian A
    public float jeda = 2f;                   // detik antar spawn
    public int maksMusuh = 8;                 // batas musuh di layar

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < jeda) return;
        timer = 0f;

        int jumlah = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (jumlah < maksMusuh) Spawn();
    }

    void Spawn()
    {
        if (prefabMusuh == null || prefabMusuh.Length == 0) return;

        GameObject prefab = prefabMusuh[PilihIndeks()];
        Vector3 posisi = new Vector3(Random.Range(-7f, 7f), Random.Range(0f, 3f), 0f);
        Instantiate(prefab, posisi, Quaternion.identity);
    }

    int PilihIndeks()
    {
        int n = Mathf.Min(bobot.Length, prefabMusuh.Length);
        int total = 0;
        for (int i = 0; i < n; i++) total += bobot[i];
        if (total <= 0) return 0;

        int acak = Random.Range(0, total);
        for (int i = 0; i < n; i++)
        {
            if (acak < bobot[i]) return i;
            acak -= bobot[i];
        }
        return 0;
    }
}
