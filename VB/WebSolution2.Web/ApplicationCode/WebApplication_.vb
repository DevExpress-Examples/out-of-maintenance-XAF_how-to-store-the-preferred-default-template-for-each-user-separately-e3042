Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.ExpressApp
Imports WebSolution2.Module.Web

Namespace WebSolution2.Web
	Partial Public Class WebSolution2AspNetApplication
		Protected Overrides Sub OnLoggedOn(ByVal args As LogonEventArgs)
			MyBase.OnLoggedOn(args)
			DefaultTemplateHelper.LoadTemplateType()
		End Sub
	End Class
End Namespace