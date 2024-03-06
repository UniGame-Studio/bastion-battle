namespace ExitGames.Client.Photon
{
    using System;
    using Leopotam.EcsLite;
    using Newtonsoft.Json;
    using UniCore.Runtime.ProfilerTools;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UnityEngine;

    /// <summary>
    /// network commands tools
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class NetworkCommandsToolsSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private JsonSerializerSettings _serializerSettings;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _serializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }

        public SendEventResult SendCustomMessage(ref NetworkMessageValue value, CommandTarget target)
        {
            return new SendEventResult();
        }

        public SendEventResult SendEvent<TData>(byte code, ref TData data, CommandTarget target)
            where TData : struct
        {
            return SendEvent<TData>(code, ref data, 0, target);
        }

        public SendEventResult SendEvent<TData>(byte code,ref TData data,int hash,CommandTarget target)
            where TData : struct
        {
            var serializedData = JsonConvert.SerializeObject(data);
            return SendEvent(code, serializedData, hash, target);
        }
        
        public SendEventResult SendEvent(byte code,string serializedData,int hash,CommandTarget target)
        {
            var result = new SendEventResult()
            {
                Entity = -1,
                Hash = hash,
                Success = false
            };
            
            var newHash = serializedData.GetHashCode();
            if (newHash == hash) return result;
            
#if UNITY_EDITOR || DEBUG || NET_DEBUG
            GameLog.Log($"NetworkCommandsTools: SendEvent {serializedData}",Color.green );
#endif
            
            var eventEntity = _world.NewEntity();
            switch (target)
            {
                case CommandTarget.Server:
                    var severEvent = new SendEventResult(){};
                    break;
                case CommandTarget.All:
                    var allEvent = new SendEventResult();
                    break;
                case CommandTarget.Others:
                    var othersEvent = new SendEventResult();
                    break;
            }

            result.Hash = newHash;
            result.Entity = eventEntity;
            result.Success = true;
            
            return result;
        }
        
        public ref TValue ReceiveEvent<TValue>(string data)
            where TValue : struct
        {
            var component = default(TValue);
            
#if UNITY_EDITOR || DEBUG
            try
            {
#endif
                component = JsonConvert.DeserializeObject<TValue>(data);
#if UNITY_EDITOR || DEBUG
            }
            catch (Exception e)
            {
                Debug.LogError($"NetworkCommandsTools: ReceiveEvent {data} Error for Type {typeof(TValue).Name} \n{e.Message}" );
            }
#endif
            var eventEntity = _world.NewEntity();
            return ref _world.AddRawComponent(eventEntity, component);
        }
        
        [Serializable]
        public struct SendEventResult
        {
            public bool Success;
            public int Hash;
            public int Entity;
        }
        
    }
}