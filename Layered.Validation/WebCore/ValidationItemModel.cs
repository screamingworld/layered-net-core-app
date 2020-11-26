using System.Collections.Generic;

namespace Layered.Common.WebCore
{
    public class ValidationItemModel
    {
        public string Field { get; set; }
        public string Key { get; set; }
        public string FailureType { set; get; }
        public ICollection<string> Args { get; } = new List<string>();
    }
}
