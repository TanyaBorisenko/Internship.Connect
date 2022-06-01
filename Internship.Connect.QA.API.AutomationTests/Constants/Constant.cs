using System;
using Internship.Connect.QA.API.AutomationTests.Utils;

namespace Internship.Connect.QA.API.AutomationTests.Constants
{
    public static class Endpoints
    {
        public static readonly string ConnectUrl = Configurator.GetConfig()["ConnectUrl"];
        public static readonly string TaskProcessorAuthKey = Configurator.GetConfig()["TaskProcessorAuthKey"];
        public const string TaskProcessor = "/task-processor";
        public static readonly string AzureDirectoryWebUrl = Configurator.GetConfig()["AzureDirectoryWebUrl"];
        public const string WebApiService = "/web";
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

    public static class WebApiUri
    {
        public const string AddNewSystem = "/systems";
        public const string AllDataTypes = "/dataTypes/all";
        public const string AllSystems = "/systems";
        public const string AllConnectors = "/connectors";
        public const string UpdateSystem = "/systems/";
        public const string DeleteSystem = "/systems/";
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

    public static class AllConnectorsIds
    {
        public static Guid Bloomberg = Guid.Parse("fe3a7b99-c02d-4df1-852b-0f016f8979c0");
        public static Guid Salesforce = Guid.Parse("641db871-cca7-4098-9cea-10f715408af5");
        public static Guid XlsxFile = Guid.Parse("75de29d9-261f-4478-bae6-23bb5aeea684");
        public static Guid CsvFile = Guid.Parse("dd8a0ade-a0c8-45e7-9e0d-2f9ea22705d2");
        public static Guid MicrosoftSql = Guid.Parse("fb6a0b9e-f445-4017-95c6-482b83d056b2");
        public static Guid DealCloud = Guid.Parse("560daee5-fc95-4ce9-8a6a-68d3c8a37f48");
        public static Guid EFront = Guid.Parse("86942cc6-b984-4ffa-9491-96c73da8bf11");
    }

    public static class DataTypeIds
    {
        public static Guid String = Guid.Parse("bccc5664-0084-4782-b4d4-229196cd878d");
        public static Guid Double = Guid.Parse("40ab6f45-e9c1-44d0-9e36-411ced9241ab");
        public static Guid Boolean = Guid.Parse("0b5b428c-8a2b-4c3a-a2ab-68f5decc8c95");
        public static Guid Int32 = Guid.Parse("be42a807-da63-486f-96b8-863256e08be3");
        public static Guid Single = Guid.Parse("652e0faf-ecc2-4362-8cd8-a845fc813754");
        public static Guid DateTime = Guid.Parse("d19c0995-5eef-4c7a-bf3f-b5270bde88e3");
        public static Guid Char = Guid.Parse("f2b70932-e8b1-418b-967c-b845e548f2db");
        public static Guid Decimal = Guid.Parse("b962dd6e-b70b-4c1a-851c-c178d2bafc5b");
    }
}