using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

    public int hitsToKill;
    public int points;
    private int timesHit;
    private int numberOfHits;
    public Sprite[] hitSprites = new Sprite[0];
    SpriteRenderer thisSpriteRenderer;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;

            if (numberOfHits == hitsToKill)
            {
                Manager.instance.DestroyBrick();
                Score.instance.AddScore();
                Score1.instance.AddScore1();
                Score2.instance.AddScore2();
                Destroy(this.gameObject);
            }
            else
            {
                LoadSprites();
            }
        }
    }

    void LoadSprites()
    {
        int spriteIndex = numberOfHits - 1;

        if (numberOfHits < 1)
            return;

        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
