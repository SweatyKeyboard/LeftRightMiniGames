using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private Chunk _firstChunk;
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Transform _player;

    private List<Chunk> _currentChunks = new List<Chunk>();

    private void Awake()
    {
        _currentChunks.Add(_firstChunk);
    }
    private void Update()
    {
        if (_currentChunks.Count < 5)
        {
            Spawn();
        }

        if (_currentChunks[1].transform.position.z < _player.position.z)
        {
            Spawn();
            DestroyOld();
        }   
    }

    private void Spawn()
    {
        Chunk newChunk = Instantiate(_chunks[Random.Range(0, _chunks.Length)]);
        newChunk.transform.position = _currentChunks.Last().End.position - newChunk.Begin.position;
        _currentChunks.Add(newChunk);      
        
        for (int i = 0; i < newChunk.Positions.Length; i++)
        {
            Instantiate(
                newChunk.Objects[Random.Range(0, newChunk.ObjectCount)],
                newChunk.Positions[i].position,
                new Quaternion(
                    Random.Range(0, 360),
                    Random.Range(0, 360),
                    Random.Range(0, 360),
                    0),
                newChunk.transform);
        }

    }

    private void DestroyOld()
    {
        Destroy(_currentChunks[0].gameObject);
        _currentChunks.RemoveAt(0);
    }
}
