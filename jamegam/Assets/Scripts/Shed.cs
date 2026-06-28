using System.Collections.Generic;
using UnityEngine;

public class Shed : MonoBehaviour
{
    private List<RabbitSubject> subjects = new List<RabbitSubject>();
    private Farm farm;

    public int BunnyCount => subjects.Count;

    private void Awake()
    {
        farm = FindAnyObjectByType<Farm>();
    }

    // Shed.cs
    private void Update()
    {
        if (subjects.Count == 0) return;
        if (farm.RabbitCount >= farm.MaxBunnies) return;

        RabbitSubject subject = subjects[subjects.Count - 1];
        subjects.RemoveAt(subjects.Count - 1);
        subject.StartFarming();
    }

    public void Add(RabbitSubject subject)
    {
        subjects.Add(subject);
    }
}