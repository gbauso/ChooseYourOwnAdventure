using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.CrossCutting.Extensions
{
    public static class JsonExtensions
    {
        public static void ValidateJSON(this string jsonCandidate)
        {
            try
            {
                JToken.Parse(jsonCandidate);
            }
            catch
            {
                throw new InvalidJsonException();
            }
        }

        public static string NormalizeNeo4jJson(this string json)
        {
            return json
                .Replace("starts_with", "rootStep")
                .Replace("decisionRef", "id")
                .Replace("stepRef", "id")
                .Replace("storyRef", "id")
                .Replace("has", "choices")
                .Replace("results_in", "to");
        }

    }
}
