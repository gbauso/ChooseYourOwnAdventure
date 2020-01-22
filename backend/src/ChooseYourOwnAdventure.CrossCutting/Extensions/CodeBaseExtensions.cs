using System.Collections.Generic;
using System.Linq;

namespace ChooseYourOwnAdventure.CrossCutting.Extensions
{
    public static class CodeBaseExtensions
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsEmptyJson(this object json)
        {
            return json.ToString().Equals("{}");
        }

        public static bool ListIsNullOrEmpty<L>(this IEnumerable<L> list)
        {
            return list.IsNull() || list.Count() == 0 || list.Any(i => i.IsNull() || i.IsEmptyJson());
        }
    }
}
