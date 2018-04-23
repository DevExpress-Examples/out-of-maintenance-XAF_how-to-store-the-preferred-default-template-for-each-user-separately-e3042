Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Web

Namespace WebSolution2.Module.Web
	Public Class UserDefaultTemplateProvider
		Public Shared Property CurrentUserDefaultTemplate() As String
			Get
				Dim userTemplateCookie As HttpCookie = HttpContext.Current.Request.Cookies(SecuritySystem.CurrentUserId.ToString())
				If userTemplateCookie IsNot Nothing AndAlso (Not String.IsNullOrEmpty(userTemplateCookie.Value)) Then
					Return userTemplateCookie.Value
				Else
					Return WebApplication.DefaultPage
				End If
			End Get
			Set(ByVal value As String)
				Dim userTemplateCookie As HttpCookie = HttpContext.Current.Response.Cookies(SecuritySystem.CurrentUserId.ToString())
				userTemplateCookie.Value = value
				userTemplateCookie.Expires = DateTime.Now.AddMonths(1)
			End Set
		End Property
	End Class
End Namespace
