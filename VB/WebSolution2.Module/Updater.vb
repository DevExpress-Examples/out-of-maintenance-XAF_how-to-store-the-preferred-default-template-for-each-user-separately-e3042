Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace WebSolution2.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim sam As SimpleUser = ObjectSpace.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Sam"))
			If sam Is Nothing Then
				sam = ObjectSpace.CreateObject(Of SimpleUser)()
				sam.UserName = "Sam"
				sam.IsAdministrator = True
				sam.Save()
			End If
			Dim john As SimpleUser = ObjectSpace.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "John"))
			If john Is Nothing Then
				john = ObjectSpace.CreateObject(Of SimpleUser)()
				john.UserName = "John"
				john.IsAdministrator = True
				john.Save()
			End If
		End Sub
	End Class
End Namespace
