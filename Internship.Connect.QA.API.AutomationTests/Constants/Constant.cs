using Internship.Connect.QA.API.AutomationTests.Utils;

namespace Internship.Connect.QA.API.AutomationTests.Constants
{
    public static class Endpoints
    {
        public static readonly string ConnectUrl = Configurator.GetConfig()["ConnectUrl"];
        public static readonly string TaskProcessorAuthKey = Configurator.GetConfig()["TaskProcessorAuthKey"];
        public const string TaskProcessor = "/task-processor";
    }

    public static class TaskServiceUri
    {
        public const string AllActiveTasks = "/tasks/active";
        public const string TaskById = "/tasks/";
        public const string AllActiveTaskGroups = "/tasks/groups";
        public const string AllActiveIndividualTasks = "/tasks/individual";
        public const string TriggerForAnEntity = "/tasks/trigger/";
        public const string TaskLastExecutionAndStatus = "/tasks/individual/update-task-status/";
        public const string WholeTaskGroupByGroupId = "/tasks/group/disable-failing-group/";
        public const string TaskGroupLastTriggerDate = "/tasks/group/update-last-execution/";

    }

    public static class SystemServiceUri
    {
        public const string SystemById = "/systems/";
        public const string AuthTokenBySystemId = "/authTokens/";
        public const string ConnectorBySystemId = "/connectors/";
    }

    public static class DataTypesUri
    {
        public const string AllDataTypes = "/dataTypes/all";
        public const string DataTypeById = "/dataTypes/";
    }

    public static class Headers
    {
        public const string Authorization = "Authorization";
    }

    public static class Parameters
    {
        public const string LastTriggeredDate = "lastTriggeredDate";
        public const string EncryptedApiKey = "encryptedApiKey";
        public const string JsonEncodedUtf = "application/json; charset=utf-8";
        public const string FileDirectory = "fileDirectory";
        public const string OffSet = "offset";
        public const string Number = "number";
        public const string SortBy = "sortBy";
        public const string SortDesc = "sortDesc";
    }
}