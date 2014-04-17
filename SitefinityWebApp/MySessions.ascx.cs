using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Data.ContentLinks;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Model.ContentLinks;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp
{
    public partial class MySessions : System.Web.UI.UserControl
    {
        private const string SessionsType ="Telerik.Sitefinity.DynamicTypes.Model.DevReach.Session";
        private IList<ContentLink> mySessions = null;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            var manager = DynamicModuleManager.GetManager();
            var repeater = this.Controls.OfType<Repeater>().First();
            var clManager = ContentLinksManager.GetManager();

            mySessions = clManager.GetContentLinks().Where(link => 
                link.ChildItemType == typeof(User).FullName && 
                link.ChildItemId == SecurityManager.CurrentUserId && 
                link.ParentItemType == SessionsType).ToList();
        
            var items = manager.GetDataItems(TypeResolutionService.ResolveType(SessionsType)).Where(item => item.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live);
            
            repeater.DataSource = items;
            repeater.DataBind();
        }

        protected void CommandBtn_Click(Object sender, CommandEventArgs e)
        {
            var sessionId = Guid.Parse(e.CommandArgument.ToString());
            var dynamicModuleManager = DynamicModuleManager.GetManager();
            var myType = TypeResolutionService.ResolveType(SessionsType);

            var masterItem = dynamicModuleManager.GetDataItem(myType, sessionId);
            var liveItem = dynamicModuleManager.GetDataItems(myType).FirstOrDefault(item => item.OriginalContentId == sessionId && item.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live);
            
            if (e.CommandName == "Attend")
            {
                liveItem.CreateRelation(SecurityManager.CurrentUserId, null, typeof(User).FullName, "Attendees");
                var currentAttendeesCount = liveItem.GetValue<decimal>("CurrentAttendees");
                liveItem.SetValue("CurrentAttendees", currentAttendeesCount + 1);
                masterItem.SetValue("CurrentAttendees", currentAttendeesCount + 1);
            }
            else
            {
                liveItem.DeleteRelation(SecurityManager.CurrentUserId, null, typeof(User).FullName, "Attendees");
                var currentAttendeesCount = liveItem.GetValue<decimal>("CurrentAttendees");
                if (currentAttendeesCount > 0)
                {
                    liveItem.SetValue("CurrentAttendees", currentAttendeesCount - 1);
                    masterItem.SetValue("CurrentAttendees", currentAttendeesCount - 1);
                }
            }

            dynamicModuleManager.SaveChanges();
        }

        protected bool CheckIsAttended(object item)
        {
            DynamicContent data = (DynamicContent)item;
            var itemId = data.OriginalContentId;

            if (mySessions.Count == 0) 
                return false;
            
            return mySessions.FirstOrDefault(link => link.ParentItemId == itemId) != null;
        }
    }
}