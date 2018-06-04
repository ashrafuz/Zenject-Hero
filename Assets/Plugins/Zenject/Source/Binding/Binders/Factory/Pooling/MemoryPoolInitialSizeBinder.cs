using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject
{
    public class MemoryPoolInitialSizeBinder<TContract> : MemoryPoolExpandBinder<TContract>
    {
        public MemoryPoolInitialSizeBinder(
            DiContainer bindContainer, BindInfo bindInfo, FactoryBindInfo factoryBindInfo, MemoryPoolBindInfo poolBindInfo)
            : base(bindContainer, bindInfo, factoryBindInfo, poolBindInfo)
        {
        }

        public MemoryPoolExpandBinder<TContract> WithInitialSize(int size)
        {
            MemoryPoolBindInfo.InitialSize = size;
            return this;
        }

        public FactoryToChoiceIdBinder<TContract> WithFixedSize(int size)
        {
            MemoryPoolBindInfo.InitialSize = size;
            MemoryPoolBindInfo.ExpandMethod = PoolExpandMethods.Fixed;
            return this;
        }
    }
}

