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
        Private Const PreferredTemplateKey As String = "PreferredTemplate"
        Public Shared Sub LoadTemplateType()
            Dim userTemplateCookie As HttpCookie = HttpContext.Current.Request.Cookies(PreferredTemplateCookieName)
            If userTemplateCookie IsNot Nothing AndAlso (Not String.IsNullOrEmpty(userTemplateCookie.Value)) Then
                WebApplication.PreferredApplicationWindowTemplateType = DirectCast(System.Enum.Parse(GetType(TemplateType), userTemplateCookie.Value), TemplateType)
            End If
        End Sub
        Public Shared Sub SetTemplateType(ByVal templateType As TemplateType)
            WebApplication.PreferredApplicationWindowTemplateType = templateType
            Dim userTemplateCookie As HttpCookie = HttpContext.Current.Response.Cookies(PreferredTemplateCookieName)
            userTemplateCookie.Value = templateType.ToString()
            userTemplateCookie.Expires = Date.Now.AddMonths(1)
            HttpContext.Current.Response.SetCookie(userTemplateCookie)
        End Sub
        Public Shared Function GetTemplateType() As TemplateType
            Return WebApplication.PreferredApplicationWindowTemplateType
        End Function
        Private Shared ReadOnly Property PreferredTemplateCookieName() As String
            Get
                Return PreferredTemplateKey + SecuritySystem.CurrentUserId.ToString()
            End Get
        End Property
    End Class
End Namespace