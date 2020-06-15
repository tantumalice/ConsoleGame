using System;
using ConsoleGame.GameObjects;
using System.Reflection;
using System.Linq;

namespace ConsoleGame
{
    static class RandomFiller
    {
        private static Random rnd = new Random();

        public static int GetRandomInt(int min, int max)
        {
            return rnd.Next(min, max);
        }
        public static T GetEnumValue<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(rnd.Next(values.Length));
        }

        public static GameObject GetGameObject()
        {
            var type = typeof(GameObject);
            var types = Assembly.GetAssembly(type).GetTypes().Where(x => x.IsSubclassOf(type)).ToArray();
            return (GameObject)Activator.CreateInstance(types[rnd.Next(types.Length)]);
        }

        public static int[] GetRandomSequence(int length, int minVal, int maxVal)
        {
            var src = new int[maxVal - minVal];
            for (int i = 0; i < src.Length; ++i)
            {
                src[i] = minVal + i;
            }
            Shuffle(src);
            var seq = src[..length];
            return seq;
        }

        private static void Shuffle(int[] arr)
        {
            int n = arr.Length;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                var buff = arr[k];
                arr[k] = arr[n];
                arr[n] = buff;
            }
        }
    }
}
