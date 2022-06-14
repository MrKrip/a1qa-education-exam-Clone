using ExamTask.Models;
using ExamTask.Util;

namespace ExamTask.ApiRequests
{
    public class SecondVariantRequests
    {
        public (string,string) GetToken(string Variant)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["GetTokenRequest"]}?variant={Variant}");
        }
    }
}
