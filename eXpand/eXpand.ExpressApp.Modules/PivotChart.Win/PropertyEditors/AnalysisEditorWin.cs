﻿using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.Persistent.Base;
using eXpand.ExpressApp.PivotChart.Win.Editors;

namespace eXpand.ExpressApp.PivotChart.Win.PropertyEditors {
    [PropertyEditor(typeof (IAnalysisInfo), true)]
    public class AnalysisEditorWin : DevExpress.ExpressApp.PivotChart.Win.AnalysisEditorWin {
        public AnalysisEditorWin(Type objectType, DictionaryNode info) : base(objectType, info) {
        }

        public new AnalysisControlWin Control {
            get { return (AnalysisControlWin) base.Control; }
        }

        void analysisControl_HandleCreated(object sender, EventArgs e) {
            ReadValue();
        }

        protected override IAnalysisControl CreateAnalysisControl() {
            var analysisControl = new AnalysisControlWin();
            analysisControl.HandleCreated += analysisControl_HandleCreated;
            return analysisControl;
        }
    }
}