using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;

namespace WebSolution2.Module.Web {
    public class UserDefaultTemplateProvider {
        public static string CurrentUserDefaultTemplate {
            get {
                HttpCookie userTemplateCookie = HttpContext.Current.Request.Cookies[SecuritySystem.CurrentUserId.ToString()];
                if (userTemplateCookie != null && !String.IsNullOrEmpty(userTemplateCookie.Value)) {
                    return userTemplateCookie.Value;
                } else {
                    return WebApplication.DefaultPage;
                }
            }
            set {
                HttpCookie userTemplateCookie = HttpContext.Current.Response.Cookies[SecuritySystem.CurrentUserId.ToString()];
                userTemplateCookie.Value = value;
                userTemplateCookie.Expires = DateTime.Now.AddMonths(1);
            }
        }
    }
}
