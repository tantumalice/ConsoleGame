using System;
using ConsoleGame.GameObjects;
using System.Reflection;
using System.Linq;

namespace ConsoleGame
{
    class RandomFiller
    {
        private static Random rnd = new Random();
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
    }
}
