<!-- default file list -->
*Files to look at*:

* [ChooseTemplateController.cs](./CS/WebSolution2.Module.Web/ChooseTemplateController.cs) (VB: [ChooseTemplateController.vb](./VB/WebSolution2.Module.Web/ChooseTemplateController.vb))
* **[DefaultTemplateHelper.cs](./CS/WebSolution2.Module.Web/DefaultTemplateHelper.cs) (VB: [DefaultTemplateHelper.vb](./VB/WebSolution2.Module.Web/DefaultTemplateHelper.vb))**
* [WebApplication_.cs](./CS/WebSolution2.Web/ApplicationCode/WebApplication_.cs) (VB: [WebApplication_.vb](./VB/WebSolution2.Web/ApplicationCode/WebApplication_.vb))
<!-- default file list end -->
# How to store the preferred Default template for each user separately


<p>In our MainDemo, there is a ChooseTemplate action that allows you to select the default template at runtime. It uses the static WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType property for this. However, this property can store its value only within the current session. So, the selected template type will be lost after a user logs off. This example shows how to store the selected template type in cookies and restore it when the user logs on. These operations are performed by the <strong>DefaultTemplateHelper</strong> class.</p><p>It is also possible to use other storages for the preferred template type. For example, you can extend the user class (SecuritySystemUser by default) with the corresponding property and store the template type in the database - see <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3384"><u>How to: Implement Custom Security Objects (Users, Roles, Operation Permissions)</u></a>.</p>

<br/>


