﻿using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.ExpressApp.PivotChart.Win;
using DevExpress.Persistent.Base;

namespace eXpand.ExpressApp.PivotChart.Win {
    [PropertyEditor(typeof (IAnalysisInfo), true)]
    public class AnalysisEditorWin : DevExpress.ExpressApp.PivotChart.Win.AnalysisEditorWin {
        public AnalysisEditorWin(Type objectType, DictionaryNode info) : base(objectType, info) {
        }

        public new AnalysisControlWin Control {
            get { return (AnalysisControlWin) base.Control; }
        }

        public new IAnalysisInfo CurrentObject {
            get { return (IAnalysisInfo) base.CurrentObject; }
            set { base.CurrentObject = value; }
        }

        void analysisControl_HandleCreated(object sender, EventArgs e) {
            ReadValue();
        }

        protected override void UpdatePivotGridSettings() {
            base.UpdatePivotGridSettings();
            Control.PivotGrid.OptionsChartDataSource.SelectionOnly = false;
        }

        protected override IPivotGridSettingsStore CreatePivotGridSettingsStore() {
            return new PivotGridControlSettingsStore(Control.PivotGrid);
        }

        protected override IAnalysisControl CreateAnalysisControl() {
            var analysisControl = new AnalysisControlWin();
            analysisControl.HandleCreated += analysisControl_HandleCreated;
            return analysisControl;
        }
    }
}