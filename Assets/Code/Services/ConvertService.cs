using UnityEngine;

namespace Code
{
    public static class ConvertService
    {
        public static float ToFloat(string value)
        {
            bool success = float.TryParse(value, out float result);
            if (success == false) Debug.LogWarning($"Failed to convert '{value}' to float");
            return result;
        }
        
        public static int ToInt(string value)
        {
            bool success = int.TryParse(value, out int result);
            if (success == false) Debug.LogWarning($"Failed to convert '{value}' to int");
            return result;
        }
    }
}