using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;      // diisi di Inspector (tarik file SO ke sini)

    private float hpSekarang;
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        hpSekarang = stats.hp;
        rend.material.color = stats.warna;
    }

    public void TerimaDamage(float damage)
    {
        // Armor mengurangi damage, sehingga HP efektif = HP / (1 - Armor)
        float damageBersih = damage * (1f - stats.armor);
        hpSekarang -= damageBersih;

        // Warna makin gelap saat HP berkurang
        float rasio = Mathf.Clamp01(hpSekarang / stats.hp);
        rend.material.color = Color.Lerp(Color.black, stats.warna, 0.3f + 0.7f * rasio);

        if (hpSekarang <= 0f) Mati();
    }

    void Mati()
    {
        if (CoinManager.Instance != null)
            CoinManager.Instance.TambahCoin(stats.cost);

        Debug.Log(stats.namaMusuh + " tumbang, +" + stats.cost + " Cells");
        Destroy(gameObject);
    }
}
