using ExamTask.Models;
using ExamTask.Util;

namespace ExamTask.ApiRequests
{
    public class SecondVariantRequests
    {
        public (string, string) GetToken(string Variant)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["GetTokenRequest"]}?variant={Variant}");
        }

        public (List<TestsModel>, string) GetProjectTests(string id)
        {
            return ApiUtils.PostRequest<List<TestsModel>>($"{ConfigClass.Config["GetProjectTests"]}?projectId={id}");
        }

        public (string, string) AddNewTest(NewTestModel newTest)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["NewTest"]}?SID={newTest.SID}&projectName={newTest.projectName}&testName={newTest.testName}&methodName={newTest.methodName}&env={newTest.env}");
        }

        public (string, string) AddTestLog(TestLogModel testLog)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["NewTestLog"]}?testId={testLog.testId}&content={testLog.content}");
        }

        public (string, string) AddTestAttachment(TestAttachmentModel testAttachment)
        {
            return ApiUtils.PostRequest($"{ConfigClass.Config["NewTestAttachment"]}?testId={testAttachment.testId}&content={testAttachment.content}&contentType={testAttachment.contentType}");
        }
    }
}
