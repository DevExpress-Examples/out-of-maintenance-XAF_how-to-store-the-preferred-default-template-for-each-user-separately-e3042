Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp
Imports System.Web.Security
Imports System.Web
Imports DevExpress.ExpressApp.Web
Imports System.Web.UI

Namespace WebSolution2.Module.Web
	Public Class MyFrameTemplateFactory
		Implements IFrameTemplateFactory
		Private Function CreateFrameTemplateByVirtualPath(ByVal path As String) As IFrameTemplate
			Return CType(System.Web.Compilation.BuildManager.CreateInstanceFromVirtualPath(path, GetType(Page)), IFrameTemplate)
		End Function
		#Region "IFrameTemplateFactory Members"
        Public Function CreateTemplate(ByVal context As TemplateContext) As IFrameTemplate Implements IFrameTemplateFactory.CreateTemplate
            Dim result As IFrameTemplate = Nothing
            If context = TemplateContext.LogonWindow Then
                result = CreateFrameTemplateByVirtualPath(FormsAuthentication.LoginUrl)
            ElseIf context = TemplateContext.ApplicationWindow Then
                result = CreateFrameTemplateByVirtualPath(VirtualPathUtility.GetDirectory(FormsAuthentication.DefaultUrl) + UserDefaultTemplateProvider.CurrentUserDefaultTemplate)
            ElseIf context = TemplateContext.PopupWindow Then
                result = CreateFrameTemplateByVirtualPath(VirtualPathUtility.GetDirectory(FormsAuthentication.DefaultUrl) + WebApplication.PopupWindowTemplatePage)
            ElseIf context = TemplateContext.NestedFrame Then
                If WebWindow.CurrentRequestPage Is Nothing Then
                    Throw New Exception(String.Format("Cannot load the '{0}' control because the CurrentRequestPage is null", WebApplication.NestedFrameTemplateControl))
                End If
                Dim nestedFrameTemplateControl As Control = WebWindow.CurrentRequestPage.LoadControl(WebApplication.NestedFrameTemplateControl)
                nestedFrameTemplateControl.ID = "NestedFrameTemplateControl"
                result = CType(nestedFrameTemplateControl, IFrameTemplate)
            End If
            Return result
        End Function
		#End Region

	End Class
End Namespace