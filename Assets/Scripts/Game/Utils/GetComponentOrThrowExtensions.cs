using System;
using UnityEngine;

namespace SlotMachine.Game.Util.Extensions
{
    public static class GetComponentOrThrowExtensions
    {
        public static T GetComponentOrThrow<T>(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent<T>(out var component))
            {
                return component;
            }

            throw new Exception($"The {gameObject.name} can not find the {typeof(T)} component");
        }
        public static T GetComponentOrThrow<T>(this Transform transform)
        {
            return transform.gameObject.GetComponentOrThrow<T>();
        }
        public static T GetComponentOrThrow<T>(this MonoBehaviour monoBehaviour)
        {
            return monoBehaviour.gameObject.GetComponentOrThrow<T>();
        }

        public static T GetBehaviourOrThrow<T>(this Animator animator)
            where T: StateMachineBehaviour
        {
            var behavior = animator.GetBehaviour<T>();
            if (behavior == null)
            {
                throw new Exception($"Can not find the {typeof(T)} behavior");
            }

            return behavior;
        }

        public static GameObject FindChildOrThrow(this GameObject gameObject, string childName)
        {
            var childTransform = gameObject.transform.Find(childName);
            if (childTransform == null)
            {
                throw new Exception($"The {gameObject.name} can not find a child with '{childName}' name");
            }

            return childTransform.gameObject;
        }
        public static Transform FindChildOrThrow(this Transform transform, string childName)
        {
            var childTransform = transform.Find(childName);
            if (childTransform == null)
            {
                throw new Exception($"The {transform.name} can not find child with '{childName}' name");
            }

            return childTransform;
        }
    }
}