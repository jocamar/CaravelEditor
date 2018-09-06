﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caravel.Editor;
using Caravel.Core.Entity;

namespace CaravelEditor
{
    public partial class CameraToolOptions : UserControl
    {
        private EditorApp m_EditorApp;
        private Cv_Entity m_EditorCamera;

        public CameraToolOptions()
        {
            InitializeComponent();
        }

        public void Initialize(EditorApp app)
        {
            m_EditorApp = app;
            m_EditorCamera = m_EditorApp.Logic.GetEntity("_editorCamera");

            if (m_EditorCamera != null)
            {
                zoomTextBox.Text = ((int)(m_EditorCamera.GetComponent<Cv_CameraComponent>().Zoom * 100)).ToString() + "%";
            }
        }

        public void RefreshInfo()
        {
            if (m_EditorCamera != null)
            {
                zoomTextBox.Text = ((int)(m_EditorCamera.GetComponent<Cv_CameraComponent>().Zoom * 100)).ToString() + "%";
            }
        }
    }
}