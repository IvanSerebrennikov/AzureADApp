using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAdApp.Models
{
    public class AzureMembershipModel
    {
        public const string RoleType = "Role";
        public const string GroupType = "Group";

        public string ObjectId { get; set; }

        public string DisplayName { get; set; }

        public string ObjectType { get; set; }
    }
}