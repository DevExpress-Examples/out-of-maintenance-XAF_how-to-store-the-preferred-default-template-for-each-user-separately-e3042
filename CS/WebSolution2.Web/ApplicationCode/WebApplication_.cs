using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.ExpressApp;
using WebSolution2.Module.Web;

namespace WebSolution2.Web {
    partial class WebSolution2AspNetApplication {
        protected override void OnLoggedOn(LogonEventArgs args) {
            base.OnLoggedOn(args);
            DefaultTemplateHelper.LoadTemplateType();
        }
    }
}