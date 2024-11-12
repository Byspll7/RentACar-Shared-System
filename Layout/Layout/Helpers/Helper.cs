using System.Reflection.Metadata.Ecma335;

namespace Layout.Helpers
{
    public class Helper : IHelper
    {
        public string Upper(string text)
        {
            return text.ToUpper();
        }
        
    }
}
