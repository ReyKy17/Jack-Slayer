using UnityEngine;

// ScriptableObject = "Live Sheet": semua angka musuh disimpan di sini,
// lalu PowerScore dihitung otomatis setiap angka diubah di Inspector.
[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Jack Slayer/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    [Header("Identitas")]
    public string namaMusuh = "Zombie";
    public Color warna = Color.white;

    [Header("Statistik")]
    public float hp = 60f;
    public float damage = 10f;
    public float speed = 1.5f;
    public float cooldown = 1f;
    [Range(0f, 0.95f)] public float armor = 0f;   // 0.5 berarti armor 50%
    public int cost = 6;                          // anggaran spawn = Cells yang dijatuhkan

    [Header("Hasil Hitung Otomatis (jangan diedit)")]
    public float dps;
    public float effHp;
    public float powerScore;
    public float powerPerCost;

    void OnValidate()
    {
        cooldown = Mathf.Max(0.01f, cooldown);
        dps = damage / cooldown;
        effHp = hp / (1f - armor);
        powerScore = dps * effHp;
        powerPerCost = cost > 0 ? powerScore / cost : 0f;
    }
}
