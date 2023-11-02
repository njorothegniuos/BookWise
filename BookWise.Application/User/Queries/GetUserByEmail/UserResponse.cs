namespace BookWise.Application.User.Queries.GetUserByEmail
{
    public sealed record UserResponse(string Id,string FirstName, string OtherNames, DateTime CreatedDate, long? CustomerId, bool IsEnabled, Guid? DesignationId, bool IsExternalUser, byte RecordStatus, string CreatedBy, string ApprovedBy, DateTime? ApprovedDate, string EditedBy, DateTime? EditDate, string Remarks, DateTime? LastPasswordChangedDate, DateTime? LastLoginDateTime);
}
