﻿using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.NodeWrappers;
using DevExpress.ExpressApp.TreeListEditors.Win;
using DevExpress.ExpressApp.Win.Controls;
using DevExpress.Persistent.Base;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace eXpand.ExpressApp.TreeListEditors.Win.Controllers {
    public class TreeListInplaceEditViewController : ViewController<ListView> {
        void treeList_CellValueChanged(object sender, CellValueChangedEventArgs cellValueChangedEventArgs) {
            ReflectionHelper.SetMemberValue(((ObjectTreeList) sender).FocusedObject,
                                            cellValueChangedEventArgs.Column.FieldName, cellValueChangedEventArgs.Value);
            ObjectSpace.CommitChanges();
        }

        void TreeListOnShowingEditor(object sender, CancelEventArgs cancelEventArgs) {
            TreeListColumn treeListColumn = ((TreeList) sender).FocusedColumn;
            var listViewInfoNodeWrapper = new ListViewInfoNodeWrapper(View.Info);
            cancelEventArgs.Cancel = !listViewInfoNodeWrapper.Columns.FindColumnInfo(treeListColumn.FieldName).AllowEdit;
        }

        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            var listViewInfoNodeWrapper = new ListViewInfoNodeWrapper(View.Info);
            if ((View.Editor is TreeListEditor) && listViewInfoNodeWrapper.AllowEdit) {
                TreeList treeList = ((TreeListEditor) View.Editor).TreeList;
                foreach (RepositoryItem ri in treeList.RepositoryItems) {
                    ri.ReadOnly = false;
                }
                treeList.CellValueChanged += treeList_CellValueChanged;
                treeList.ShowingEditor += TreeListOnShowingEditor;
                treeList.OptionsBehavior.Editable = true;
            }
        }
    }
}