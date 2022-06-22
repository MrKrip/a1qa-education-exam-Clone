using ExamTask.Models;
using ExamTask.Util;

namespace ExamTask.ApiRequests
{
    public static class SecondVariantRequests
    {
        public static (string, string) GetToken(string Variant)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["GetTokenRequest"]}?variant={Variant}");
        }

        public static (List<TestsModel>, string) GetProjectTests(string id)
        {
            return ApiUtils.PostRequest<List<TestsModel>>($"{ConfigClass.Config["GetProjectTests"]}?projectId={id}");
        }

        public static (string, string) AddNewTest(NewTestModel newTest)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["NewTest"]}?SID={newTest.SID}&projectName={newTest.ProjectName}&testName={newTest.TestName}&methodName={newTest.MethodName}&env={newTest.Env}");
        }

        public static (string, string) AddTestLog(TestLogModel testLog)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["NewTestLog"]}?testId={testLog.TestId}&content={testLog.Content}");
        }

        public static (string, string) AddTestAttachment(TestAttachmentModel testAttachment)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["NewTestAttachment"]}?testId={testAttachment.TestId}&content={testAttachment.Content}&contentType={testAttachment.ContentType}");
        }
    }
}
