using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp;
using System.Web.Security;
using System.Web;
using DevExpress.ExpressApp.Web;
using System.Web.UI;

namespace WebSolution2.Module.Web {
    public class MyFrameTemplateFactory : IFrameTemplateFactory {
        private IFrameTemplate CreateFrameTemplateByVirtualPath(string path) {
            return (IFrameTemplate)System.Web.Compilation.BuildManager.CreateInstanceFromVirtualPath(path, typeof(Page));
        }
        #region IFrameTemplateFactory Members
        public IFrameTemplate CreateTemplate(TemplateContext context) {
            IFrameTemplate result = null;
            if (context == TemplateContext.LogonWindow) {
                result = CreateFrameTemplateByVirtualPath(FormsAuthentication.LoginUrl);
            } else if (context == TemplateContext.ApplicationWindow) {
                result = CreateFrameTemplateByVirtualPath(VirtualPathUtility.GetDirectory(FormsAuthentication.DefaultUrl) + UserDefaultTemplateProvider.CurrentUserDefaultTemplate);
            } else if (context == TemplateContext.PopupWindow) {
                result = CreateFrameTemplateByVirtualPath(VirtualPathUtility.GetDirectory(FormsAuthentication.DefaultUrl) + WebApplication.PopupWindowTemplatePage);
            } else if (context == TemplateContext.NestedFrame) {
                if (WebWindow.CurrentRequestPage == null) {
                    throw new Exception(string.Format(
                        "Cannot load the '{0}' control because the CurrentRequestPage is null",
                        WebApplication.NestedFrameTemplateControl));
                }
                Control nestedFrameTemplateControl = WebWindow.CurrentRequestPage.LoadControl(WebApplication.NestedFrameTemplateControl);
                nestedFrameTemplateControl.ID = "NestedFrameTemplateControl";
                result = (IFrameTemplate)nestedFrameTemplateControl;
            }
            return result;
        }
        #endregion

    }
}