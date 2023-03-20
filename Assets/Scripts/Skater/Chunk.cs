using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform[] _objectsPlaces;
    [SerializeField] private Transform[] _objectPrefabs;

    public Transform Begin => _begin;
    public Transform End => _end;
    public Transform[] Positions => _objectsPlaces;
    public Transform[] Objects => _objectPrefabs;
    public int ObjectCount => _objectPrefabs.Length;
}
