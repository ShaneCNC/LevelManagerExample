// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainView.cs" company="CNC Software, Inc.">
//   Copyright (c) 2013 CNC Software, Inc.
// </copyright>
// <summary>
//   The main view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerExample
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Forms;

    using LevelManagerExample.Services;

    using Mastercam.Database.Types;
    using Mastercam.IO;
    using Mastercam.IO.Types;
    using Mastercam.Math;
    using Mastercam.Support;

    /// <summary>
    /// The main view.
    /// </summary>
    public partial class MainView : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView()
        {
            this.InitializeComponent();
        }

        /// <summary> Raises the draw box event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnDrawBox(object sender, EventArgs e)
        {
            // No need to test the return here
            UtilityService.Initialize(false);

            // Draw a block 1" deep on level 100
            UtilityService.DrawBlock(new Point3D { x = 0.0, y = 0.0, z = 0.0 }, new Point3D { x = 12.0, y = 12.0, z = 0 }, -1, 100);
        }

        /// <summary> Set color by level event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnSetColorByLevel(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            const int Pink = 172;
            UtilityService.SetColorOnLevel(Pink, 26);
        }

        /// <summary> Raises the select geometry by level event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnSelectGeometryByLevel(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            UtilityService.SelectGeometryByLevel(46);
        }

        /// <summary> Raises the move geometry to level event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnMoveGeometryToLevel(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            // Move all arcs to level 120
            var arcMask = new GeometryMask(false, false, true, false, false, false, false);
            UtilityService.MoveGeometryByMaskToLevel(arcMask, new SelectionMask(true), 120);
        }

        /// <summary> Raises the get list of level names event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnGetListOfLevelNames(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            var msg = "Levels containing Geometry:\n";
            msg += string.Join("\n", UtilityService.GetListOfLevelNamesWithGeometry().ToArray());

            DialogManager.OK(msg, "Levels");
        }

        /// <summary> Raises the set level set name event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnSetLevelSetName(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            // Toggle the level manager 
            ExternalAppsManager.PostFTCommand("OnScreenLevels");

            // Set levels 1 - 10 with the level set name
            var levels = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            UtilityService.SetLevelSetName(levels, "Set via API");

            // Display the level manager so it switches into view
            ExternalAppsManager.PostFTCommand("OnScreenLevels");
        }

        /// <summary> Raises the move all lines event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnMoveGeometry(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            // Set the QuickMaskType and level # to use
            const int Level = 101;
            var result = UtilityService.MoveGeometry(QuickMaskType.Lines, Level);

            DialogManager.OK(result.ToString(CultureInfo.InvariantCulture) + " entities moved to level " + Level, string.Empty);
        }

        /// <summary> Raises the close view event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnCloseView(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary> Raises the copy level event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnCopyLevel(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            // Set the QuickMaskType and level # to use
            const int Level = 105;
            var result = UtilityService.CopyGeometry(QuickMaskType.Wireframe, Level);

            DialogManager.OK(result.ToString(CultureInfo.InvariantCulture) + " entities copied to level " + Level.ToString(CultureInfo.InvariantCulture), string.Empty);
        }

        /// <summary> Raises the move group geometry event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnMoveGroupGeometry(object sender, EventArgs e)
        {
            if (!UtilityService.Initialize(true))
            {
                return;
            }

            // Set the QuickMaskType and level # to use
            const int Level = 150;
            UtilityService.TranslateCopyGroupToLevel(QuickMaskType.Arcs, Level);
        }

        /// <summary> Raises the main view event. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Event information to send to registered event handlers. </param>
        private void OnMainView(object sender, EventArgs e)
        {
            this.ToolTipControl.SetToolTip(this.DrawBox, "Draw a block 1 inch thick on level 100");
            this.ToolTipControl.SetToolTip(this.MoveGeometryToLevel, "Move all arcs to level 120");
            this.ToolTipControl.SetToolTip(this.SetLevelSetName, "Sets the level set name 'Set via API' for levels 1-10");
            this.ToolTipControl.SetToolTip(this.GetListOfLevelNames, "Displays a list of level names that contain entities");
            this.ToolTipControl.SetToolTip(this.MoveAllLines, "Move all lines to level 101");
            this.ToolTipControl.SetToolTip(this.SetColorByLevel, "Draw all entities on level 29 in the color pink");
            this.ToolTipControl.SetToolTip(this.SelectGeometryByLevel, "Selects all entities on level 46");
            this.ToolTipControl.SetToolTip(this.CopyLevel, "Copy all entities to level 105");
            this.ToolTipControl.SetToolTip(this.MoveGroupGeometry, "Translate a copy of all arcs (as a result group) to level 150");
        }  
    }
}
