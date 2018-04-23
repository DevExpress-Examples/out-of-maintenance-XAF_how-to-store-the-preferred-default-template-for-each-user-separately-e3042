using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp;
using System.Web.Security;
using System.Web;
using DevExpress.ExpressApp.Web;
using System.Web.UI;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Web.Templates;

namespace WebSolution2.Module.Web {
    public class DefaultTemplateHelper {
        public static void LoadTemplateType() {
            HttpCookie userTemplateCookie = HttpContext.Current.Request.Cookies[SecuritySystem.CurrentUserId.ToString()];
            if (userTemplateCookie != null && !String.IsNullOrEmpty(userTemplateCookie.Value)) {
                WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType = (TemplateType)Enum.Parse(typeof(TemplateType), userTemplateCookie.Value);
            }
        }
        public static void SetTemplateType(TemplateType templateType) {
            WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType = templateType;
            HttpCookie userTemplateCookie = HttpContext.Current.Response.Cookies[SecuritySystem.CurrentUserId.ToString()];
            userTemplateCookie.Value = templateType.ToString();
            userTemplateCookie.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Current.Response.SetCookie(userTemplateCookie);
        }
        public static TemplateType GetTemplateType() {
            return WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType;
        }
    }
}