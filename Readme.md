<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128593958/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3042)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [ChooseTemplateController.cs](./CS/WebSolution2.Module.Web/ChooseTemplateController.cs) (VB: [ChooseTemplateController.vb](./VB/WebSolution2.Module.Web/ChooseTemplateController.vb))
* [MyFrameTemplateFactory.cs](./CS/WebSolution2.Module.Web/MyFrameTemplateFactory.cs) (VB: [MyFrameTemplateFactory.vb](./VB/WebSolution2.Module.Web/MyFrameTemplateFactory.vb))
* [UserDefaultTemplateProvider.cs](./CS/WebSolution2.Module.Web/UserDefaultTemplateProvider.cs) (VB: [UserDefaultTemplateProvider.vb](./VB/WebSolution2.Module.Web/UserDefaultTemplateProvider.vb))
* [WebApplication.cs](./CS/WebSolution2.Web/ApplicationCode/WebApplication.cs) (VB: [WebApplication.vb](./VB/WebSolution2.Web/ApplicationCode/WebApplication.vb))
<!-- default file list end -->
# How to store the preferred Default template for each user separately


<p>In our MainDemo, there is a ChooseTemplate action that allows you to select the default template at runtime. It uses the static WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType property for this. However, this property can store its value only within the current session. So, the selected template type will be lost after a user logs off. This example shows how to store the selected template type in cookies and restore it when the user logs on. These operations are performed by the <strong>DefaultTemplateHelper</strong> class.</p><p>It is also possible to use other storages for the preferred template type. For example, you can extend the user class (SecuritySystemUser by default) with the corresponding property and store the template type in the database - see <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3384"><u>How to: Implement Custom Security Objects (Users, Roles, Operation Permissions)</u></a>.</p>

<br/>


