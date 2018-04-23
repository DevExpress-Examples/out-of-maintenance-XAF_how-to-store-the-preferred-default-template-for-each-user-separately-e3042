using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.Web;
using DevExpress.ExpressApp.Web;

namespace WebSolution2.Module.Web {
	public partial class ChooseTemplateController : ViewController {
		public ChooseTemplateController() {
			InitializeComponent();
			CreateActionItems();
			RegisterActions(components);
		}
		private void CreateActionItems() {
			ChoiceActionItem defaultTemplateItem = new ChoiceActionItem("Horizontal navigation", "Default.aspx");
			ChooseTemplateAction.Items.Add(defaultTemplateItem);
			ChoiceActionItem defaultVerticalTemplateItem = new ChoiceActionItem("Vertical navigation", "DefaultVertical.aspx");
			ChooseTemplateAction.Items.Add(defaultVerticalTemplateItem);
		}
        private void ChooseTemplateAction_Execute(object sender, DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs e) {
            string prevUrl = HttpContext.Current.Request.RawUrl;
            string prevDefaultPage = UserDefaultTemplateProvider.CurrentUserDefaultTemplate;
            UserDefaultTemplateProvider.CurrentUserDefaultTemplate = e.SelectedChoiceActionItem.Data.ToString();
            HttpContext.Current.Response.Redirect(prevUrl.Replace(prevDefaultPage, UserDefaultTemplateProvider.CurrentUserDefaultTemplate));
        }
		private void ChooseTemplateController_Activated(object sender, System.EventArgs e) {
			Frame.TemplateChanged += new EventHandler(Frame_TemplateChanged);
		}

		void Frame_TemplateChanged(object sender, EventArgs e) {
			UpdateSelectedItem();
		}
		private void ChooseTemplateController_Deactivated(object sender, System.EventArgs e) {
			Frame.TemplateChanged -= new EventHandler(Frame_TemplateChanged);
		}
		private void UpdateSelectedItem() {
			foreach(ChoiceActionItem item in ChooseTemplateAction.Items) {
                if (UserDefaultTemplateProvider.CurrentUserDefaultTemplate.ToLower().Contains(item.Data.ToString().ToLower())) {
					ChooseTemplateAction.SelectedItem = item;
					break;
				}
			}
		}
	}
}
