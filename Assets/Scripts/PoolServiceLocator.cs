using System;
using System.Collections.Generic;

namespace Asteroids
{
    public static class PoolServiceLocator
    {
        private static readonly Dictionary<Type, object> _poolContainer = new Dictionary<Type, object>();

        public static void SetPool<T>(T pool) where T : IPool
        {
            // не понял, зачем тут нужна проверка на наличие в словаре ключа? если нет - добавит, если есть - передобавит
            // или это из соображений производительности?
            _poolContainer[typeof(T)] = pool;
        }

        public static T Resolve<T>()
        {
            // переделал твою реализацию проверки наличия ключа на TryGetValue
            // вроде бы под капотом делает то же самое
            _poolContainer.TryGetValue(typeof(T), out var pool);
            return (T) pool;
        }
    }
}