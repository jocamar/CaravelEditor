using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CaravelEditor
{
    class EditorBuildLogger : ILogger
    {
        public LoggerVerbosity Verbosity { get; set; }
        public string Parameters { get; set; }
        public int MaxLines { get; set; }

        public RichTextBox TextBox
        {
            get; set;
        }

        private int m_iIndent = 0;
        private Timer m_UpdateTimer = new Timer();

        private List<string> m_LinesBuffer = new List<string>();

        public EditorBuildLogger()
        {
            MaxLines = 2000;
            Verbosity = LoggerVerbosity.Normal;
            m_UpdateTimer.Interval = 100;
            m_UpdateTimer.Tick += UpdateTimer_Tick;
            m_UpdateTimer.Start();
        }

        public void Initialize(IEventSource eventSource)
        {
            if (TextBox != null)
            {
                eventSource.ProjectStarted += EventSource_ProjectStarted;
                eventSource.ProjectFinished += EventSource_ProjectFinished;
                eventSource.TaskStarted += EventSource_TaskStarted;
                eventSource.MessageRaised += EventSource_MessageRaised;
                eventSource.WarningRaised += EventSource_WarningRaised;
                eventSource.ErrorRaised += EventSource_ErrorRaised;
            }
        }

        private void EventSource_ErrorRaised(object sender, BuildErrorEventArgs e)
        {
            // BuildErrorEventArgs adds LineNumber, ColumnNumber, File, amongst other parameters
            string line = String.Format(": ERROR {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);
            WriteLineWithSenderAndMessage(line, e);
        }

        private void EventSource_WarningRaised(object sender, BuildWarningEventArgs e)
        {
            string line = String.Format(": Warning {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);
            WriteLineWithSenderAndMessage(line, e);
        }

        private void EventSource_MessageRaised(object sender, BuildMessageEventArgs e)
        {
            if ((e.Importance == MessageImportance.High)
                || (e.Importance == MessageImportance.Normal && (Verbosity == LoggerVerbosity.Normal || Verbosity == LoggerVerbosity.Detailed))
                || (e.Importance == MessageImportance.Low && Verbosity == LoggerVerbosity.Detailed)
                )
            {
                WriteLineWithSenderAndMessage(String.Empty, e);
            }
        }

        private void EventSource_TaskStarted(object sender, TaskStartedEventArgs e)
        {
            if (TextBox != null)
            {
                //WriteLine(Environment.NewLine, e);
            }
        }

        private void EventSource_ProjectFinished(object sender, ProjectFinishedEventArgs e)
        {
            if (TextBox != null)
            {
                m_iIndent--;
                WriteLine("", e);
            }
        }

        private void EventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {
            if (TextBox != null)
            {
                WriteLine("", e);
                m_iIndent++;
            }
        }

        public void Shutdown()
        {

        }

        public void WriteLine(string line)
        {
            TextBox.AppendText(Environment.NewLine);
            for (int i = m_iIndent; i > 0; i--)
            {
                TextBox.AppendText("\t");
            }
            TextBox.AppendText(line);
            TrimLines();
        }

        private void WriteLine(string line, BuildEventArgs e)
        {
            var toWrite = "";
            toWrite += Environment.NewLine;
            for (int i = m_iIndent; i > 0; i--)
            {
                toWrite += "\t";
                //TextBox.AppendText("\t");
            }

            toWrite += line + e.Message;
            //TextBox.AppendText(line + e.Message);
            
            lock (m_LinesBuffer)
            {
                m_LinesBuffer.Add(toWrite);
            }
        }

        private void WriteLineWithSenderAndMessage(string line, BuildEventArgs e)
        {
            if (0 == String.Compare(e.SenderName, "MSBuild", true /*ignore case*/))
            {
                // Well, if the sender name is MSBuild, let's leave it out for prettiness
                WriteLine(line, e);
            }
            else
            {
                WriteLine(e.SenderName + ": " + line, e);
            }
        }

        private void TrimLines()
        {
            if (TextBox != null)
            {
                if (TextBox.Lines.Length > MaxLines)
                {
                    TextBox.Select(0, TextBox.GetFirstCharIndexFromLine(TextBox.Lines.Length - MaxLines));
                    TextBox.SelectedText = "";
                }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            lock (m_LinesBuffer)
            {
                foreach (var line in m_LinesBuffer)
                {
                    TextBox.AppendText(line);
                }

                TrimLines();

                if (m_LinesBuffer.Count > 0)
                {
                    TextBox.ScrollToCaret();
                }

                m_LinesBuffer.Clear();
            }
        }
    }
}
