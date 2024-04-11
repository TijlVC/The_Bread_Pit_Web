using Microsoft.AspNetCore.Identity;

namespace The_Bread_Pit.Areas.Admin.Models
{
    public class UserManagementViewModel
    {
        public List<IdentityUser>? UnconfirmedUsers { get; set; }
        public List<IdentityUser>? Users { get; set; }
        public List<IdentityUser>? Admins { get; set; }
        public List<IdentityUser>? Employees { get; set; }
        public List<IdentityRole>? Roles { get; set; }        
    }

    public class UserApprovalViewModel
    {
        public List<IdentityUser>? UnconfirmedUsers { get; set; }
        public List<IdentityUser>? ConfirmedUsers { get; set; }
    }

        public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

}