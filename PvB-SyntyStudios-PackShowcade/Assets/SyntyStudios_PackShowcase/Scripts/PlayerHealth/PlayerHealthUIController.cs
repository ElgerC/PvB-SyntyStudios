using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUIController : MonoBehaviour
{
    [SerializeField] private List<GameObject> Hearts = new List<GameObject>();
    [SerializeField] private RectTransform heartTemplate;
    [SerializeField] private Transform heartHolder;
    [SerializeField] private Vector3 heartOffset;
    private int index;
    public void RemoveHeart(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            Hearts[index -1].SetActive(false);
            index--;
            if(index < 0)
            {
                Debug.LogWarning("Heart UI index is below zero");
                return;
            }
        }
    }

    public void GenerateHearts(int heartCount)
    {
        var generationIndex = 0;

        for (int i = 0; i < heartCount; i++)
        {
            var position = heartTemplate.position + (heartOffset*generationIndex);
            var heart = Instantiate(heartTemplate.gameObject,position,Quaternion.identity,heartHolder);
            Hearts.Add(heart);

            generationIndex++;
        }

        index = heartCount;
        heartTemplate.gameObject.SetActive(false);
    }
}
