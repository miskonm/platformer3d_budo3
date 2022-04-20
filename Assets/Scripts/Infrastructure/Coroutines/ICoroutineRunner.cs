using System.Collections;
using UnityEngine;

namespace Platformer.Infrastructure.Coroutines
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}