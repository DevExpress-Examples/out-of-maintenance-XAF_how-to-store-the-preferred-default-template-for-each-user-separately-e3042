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
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.Web.Templates

Namespace WebSolution2.Module.Web
	Public Class DefaultTemplateHelper
		Public Shared Sub LoadTemplateType()
			Dim userTemplateCookie As HttpCookie = HttpContext.Current.Request.Cookies(SecuritySystem.CurrentUserId.ToString())
			If userTemplateCookie IsNot Nothing AndAlso (Not String.IsNullOrEmpty(userTemplateCookie.Value)) Then
				WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType = CType(System.Enum.Parse(GetType(TemplateType), userTemplateCookie.Value), TemplateType)
			End If
		End Sub
		Public Shared Sub SetTemplateType(ByVal templateType As TemplateType)
			WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType = templateType
			Dim userTemplateCookie As HttpCookie = HttpContext.Current.Response.Cookies(SecuritySystem.CurrentUserId.ToString())
			userTemplateCookie.Value = templateType.ToString()
			userTemplateCookie.Expires = DateTime.Now.AddMonths(1)
			HttpContext.Current.Response.SetCookie(userTemplateCookie)
		End Sub
		Public Shared Function GetTemplateType() As TemplateType
			Return WebWindowTemplateHttpHandler.PreferredApplicationWindowTemplateType
		End Function
	End Class
End Namespace