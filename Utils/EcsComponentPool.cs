// ----------------------------------------------------------------------------
// The MIT License
// Simple Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LeopotamGroup.Ecs.Internals {
    /// <summary>
    /// Components pool container.
    /// </summary>
    sealed class EcsComponentPool {
        readonly Stack<IEcsComponent> _pool = new Stack<IEcsComponent> (512);

        readonly Type _type;

        public EcsComponentPool (Type type) {
            _type = type;
        }

        public IEcsComponent Get () {
            return _pool.Count > 0 ? _pool.Pop () : Activator.CreateInstance (_type) as IEcsComponent;
        }

        public void Recycle (IEcsComponent item) {
            if (item != null) {
                _pool.Push (item);
            }
        }

        public int GetCachedCount () {
            return _pool.Count;
        }
    }
}