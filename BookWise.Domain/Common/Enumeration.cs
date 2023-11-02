using System.ComponentModel;

namespace BookWise.Domain.Common
{
    public enum Roles
    {
        Root = 1,
        Admin,
        Webapi,
        Regular
    }
    public enum UserRecordStatus
    {
        [Description("Approved")]
        Approved = 1
    }
    public enum RecordStatus
    {
        [Description("Available")]
        Available = 0,
        [Description("Reserved")]
        Reserved = 1,
        [Description("Borrowed")]
        Borrowed = 2
    }
    public enum ServiceOrigin
    {
        [Description("Web MVC")]
        WebMVC = 1,
        [Description("Web API")]
        WebAPI = 2,
        [Description("Windows Service")]
        WindowsService = 3
    }
}
