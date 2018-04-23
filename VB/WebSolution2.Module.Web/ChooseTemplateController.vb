Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.DC
Imports System.Web
Imports DevExpress.ExpressApp.Web
Imports System.Web.UI
Imports DevExpress.ExpressApp.Web.Templates

Namespace WebSolution2.Module.Web
    Partial Public Class ChooseTemplateController
        Inherits ViewController

        Public Sub New()
            InitializeComponent()
            CreateActionItems()
            RegisterActions(components)
        End Sub
        Private Sub CreateActionItems()
            Dim defaultTemplateItem As New ChoiceActionItem("Horizontal navigation", TemplateType.Horizontal)
            ChooseTemplateAction.Items.Add(defaultTemplateItem)
            Dim defaultVerticalTemplateItem As New ChoiceActionItem("Vertical navigation", TemplateType.Vertical)
            ChooseTemplateAction.Items.Add(defaultVerticalTemplateItem)
        End Sub
        Private Sub ChooseTemplateAction_Execute(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs) Handles ChooseTemplateAction.Execute
            Dim page As Page = WebWindow.CurrentRequestPage
            If page IsNot Nothing Then
                DefaultTemplateHelper.SetTemplateType(CType(e.SelectedChoiceActionItem.Data, TemplateType))
                If page.IsCallback Then
                    WebWindow.CurrentRequestWindow.RegisterStartupScript("redirect", DirectCast(WebWindow.CurrentRequestPage, ICallbackManagerHolder).CallbackManager.GetScript(True))
                Else
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Path)
                End If
            End If
        End Sub
        Private Sub ChooseTemplateController_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            AddHandler Frame.TemplateChanged, AddressOf Frame_TemplateChanged
            UpdateSelectedItem()
        End Sub

        Private Sub Frame_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateSelectedItem()
        End Sub
        Private Sub ChooseTemplateController_Deactivated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivated
            RemoveHandler Frame.TemplateChanged, AddressOf Frame_TemplateChanged
        End Sub
        Private Sub UpdateSelectedItem()
            For Each item As ChoiceActionItem In ChooseTemplateAction.Items
                If DefaultTemplateHelper.GetTemplateType().Equals(item.Data) Then
                    ChooseTemplateAction.SelectedItem = item
                    Exit For
                End If
            Next item
        End Sub
    End Class
End Namespace
