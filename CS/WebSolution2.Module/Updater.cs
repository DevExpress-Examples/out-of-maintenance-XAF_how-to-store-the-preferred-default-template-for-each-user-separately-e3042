using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace WebSolution2.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            SimpleUser sam = ObjectSpace.FindObject<SimpleUser>(new BinaryOperator("UserName", "Sam"));
            if (sam == null) {
                sam = ObjectSpace.CreateObject<SimpleUser>();
                sam.UserName = "Sam";
                sam.IsAdministrator = true;
                sam.Save();
            }
            SimpleUser john = ObjectSpace.FindObject<SimpleUser>(new BinaryOperator("UserName", "John"));
            if (john == null) {
                john = ObjectSpace.CreateObject<SimpleUser>();
                john.UserName = "John";
                john.IsAdministrator = true;
                john.Save();
            }
        }
    }
}
