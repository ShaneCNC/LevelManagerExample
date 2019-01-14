// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilityService.cs" company="CNC Software, Inc.">
//   Copyright (c) 2013 CNC Software, Inc.
// </copyright>
// <summary>
//   The utility service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerExample.Services
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Mastercam.Curves;
    using Mastercam.Database;
    using Mastercam.Database.Types;
    using Mastercam.GeometryUtility;
    using Mastercam.IO;
    using Mastercam.IO.Types;
    using Mastercam.Math;
    using Mastercam.Support;

    /// <summary>
    /// The utility service.
    /// </summary>
    public static class UtilityService
    {
        #region Private Fields

        /// <summary>
        /// The levels drawing.
        /// </summary>
        private static readonly string LevelsDrawing = Path.Combine(SettingsManager.UserDirectory, @"mcx\levels.mcx-8");

        #endregion

        #region Public Methods

        /// <summary> Move geometry by mask to level. </summary>
        ///
        /// <param name="mask">      The mask. </param>
        /// <param name="selection"> The selection. </param>
        /// <param name="level">     The level. </param>
        public static void MoveGeometryByMaskToLevel(GeometryMask mask, SelectionMask selection, int level)
        {
            const int SearchAllLevels = -1;

            var geometries = SearchManager.GetGeometry(mask, selection, SearchAllLevels).ToList();
            if (!geometries.Any())
            {
                return;
            }

            foreach (var entity in geometries)
            {
                entity.Level = level;
                entity.Commit();
            }
        }

        /// <summary> Gets list of level names with geometry. </summary>
        ///
        /// <returns> The list of level names with geometry. </returns>
        public static List<string> GetListOfLevelNamesWithGeometry()
        {
            var levels = LevelsManager.GetLevelNumbersWithGeometry().ToList();
            var names = new List<string>();

            if (levels.Any())
            {
                names.AddRange(levels.Select(LevelsManager.GetLevelName));
            }

            return names;
        }

        /// <summary> Select geometry by level. </summary>
        ///
        /// <param name="level"> The level. </param>
        public static void SelectGeometryByLevel(int level)
        {
            var geometries = SearchManager.GetGeometry().ToList();
            if (!geometries.Any())
            {
                return;
            }

            foreach (var entity in geometries.Where(ent => ent.Level == level))
            {
                entity.Selected = true;
                entity.Commit();
            }

            GraphicsManager.Repaint(true);
        }

        /// <summary> Sets the color for all entities on the specified level. </summary>
        ///
        /// <param name="color"> The color to draw </param>
        /// <param name="level"> The level to draw too. </param>
        public static void SetColorOnLevel(int color, int level)
        {
            var geometries = SearchManager.GetGeometry().ToList();
            if (!geometries.Any())
            {
                return;
            }

            foreach (var entity in geometries.Where(ent => ent.Level == level))
            {
                entity.Color = color;
                entity.Commit();
            }

            GraphicsManager.Repaint(true);
        }

        /// <summary> Draws a block on the specified level. </summary>
        ///
        /// <param name="topPoint1">    The first top point. </param>
        /// <param name="topPoint2">    The second top point. </param>
        /// <param name="depth"> The depth. </param>
        /// <param name="level">        The level. </param>
        public static void DrawBlock(Point3D topPoint1, Point3D topPoint2, double depth, int level)
        {
            SelectionManager.UnselectAllGeometry();

            // Create the top rectangle
            var topRectangle = GeometryCreationManager.CreateRectangle(topPoint1, topPoint2);

            foreach (var element in topRectangle)
            {
                element.Color = 48; // Green
                element.Commit();
            }

            SelectionManager.SelectGeometryByMask(QuickMaskType.Lines);

            // Translate a copy down in Z for the bottom rectangle
            GeometryManipulationManager.TranslateGeometry(
                new Point3D(0, 0, topPoint1.z),
                new Point3D(0, 0, depth),
                ViewManager.GraphicsView,
                ViewManager.GraphicsView,
                true);

            SelectionManager.UnselectAllGeometry();

            // Create the vertices
            var verticalLines = new ArrayList
                                    {
                                        new LineGeometry(new Point3D(topPoint1.x, topPoint1.y, topPoint1.z), new Point3D(topPoint1.x, topPoint1.y, depth)),
                                        new LineGeometry(new Point3D(topPoint1.x, topPoint2.y, topPoint1.z), new Point3D(topPoint1.x, topPoint2.y, depth)),
                                        new LineGeometry(new Point3D(topPoint2.x, topPoint2.y, topPoint1.z), new Point3D(topPoint2.x, topPoint2.y, depth)),
                                        new LineGeometry(new Point3D(topPoint2.x, topPoint1.y, topPoint1.z), new Point3D(topPoint2.x, topPoint1.y, depth))
                                    };

            foreach (Geometry line in verticalLines)
            {
                line.Color = 48; // Green
                line.Level = level;
                line.Commit();
            }

            const int ViewNumber = (int)GraphicsViewType.Iso;

            ViewManager.GraphicsView = SearchManager.GetViews(ViewNumber)[0];
            GraphicsManager.FitScreen();
            GraphicsManager.ClearColors(new GroupSelectionMask());
        }

        /// <summary> Initializes this object. </summary>
        ///
        /// <param name="openDrawing"> true to open drawing. </param>
        ///
        /// <returns> true if it succeeds, false if it fails. </returns>
        public static bool Initialize(bool openDrawing)
        {
            FileManager.New(false);

            if (openDrawing)
            {
                if (File.Exists(LevelsDrawing))
                {
                    return FileManager.Open(LevelsDrawing);
                }

                var msg = $"Missing file {LevelsDrawing}. Please copy the included drawing to 'my mcam2017\\mcx' folder";
                DialogManager.OK(msg, "Missing File");
                return false;
            }

            return true;
        }

        /// <summary> Sets level set name. </summary>
        ///
        /// <param name="levels"> The levels list. </param>
        /// <param name="name">   The name of the level set to associate with levels. </param>
        public static void SetLevelSetName(IEnumerable<int> levels, string name)
        {
            foreach (var level in levels)
            {
                LevelsManager.SetLevelSetName(level, name);
            }            
        }

        /// <summary> Move geometry. </summary>
        ///
        /// <param name="mask">  The mask. </param>
        /// <param name="level"> The level. </param>
        ///
        /// <returns> An int. </returns>
        public static int MoveGeometry(QuickMaskType mask, int level)
        {
            // Make sure nothing is already selected
            SelectionManager.UnselectAllGeometry();

            // Select all lines to move
            SelectionManager.SelectGeometryByMask(mask);

            return GeometryManipulationManager.MoveSelectedGeometryToLevel(level, true);
        }

        /// <summary> Copies the geometry. </summary>
        ///
        /// <param name="mask">  The mask. </param>
        /// <param name="level"> The level. </param>
        ///
        /// <returns> An int. </returns>
        public static int CopyGeometry(QuickMaskType mask, int level)
        {
            SelectionManager.UnselectAllGeometry();

            SelectionManager.SelectGeometryByMask(mask);

            LevelsManager.SetLevelName(level, "Copied geometry via API");

            var result = GeometryManipulationManager.CopySelectedGeometryToLevel(level, true);

            GraphicsManager.ClearColors(new GroupSelectionMask());

            HideLevels(level);

            return result;
        }

        /// <summary> Translate copy group to level. </summary>
        ///
        /// <param name="mask">  The mask. </param>
        /// <param name="level"> The level. </param>
        public static void TranslateCopyGroupToLevel(QuickMaskType mask, int level)
        {
            // Make sure nothing is already selected
            SelectionManager.UnselectAllGeometry();

            // Set the mask
            SelectionManager.SelectGeometryByMask(mask);

            // Group on result
            var result = new GroupSelectionMask(false, true);

            // Translate in place
            if (!GeometryManipulationManager.TranslateGeometry(new Point3D { x = 0, y = 0, z = 0 }, new Point3D { x = 0, y = 0, z = 0 }, ViewManager.CPlane, ViewManager.CPlane, true))
            {
                return;
            }

            // Move the grouped result to the level
            GeometryManipulationManager.MoveGroupGeometryToLevel(result, level);

            LevelsManager.SetLevelName(level, "Created via API");

            GraphicsManager.ClearColors(new GroupSelectionMask());

            // Hide all other levels
            HideLevels(level);
        }

        #endregion

        #region Private Methods

        /// <summary> Hides the levels. </summary>
        ///
        /// <param name="level"> The level. </param>
        private static void HideLevels(int level)
        {
            var levels = LevelsManager.GetVisibleLevelNumbers().ToList();

            foreach (var l in levels.Where(x => x != level))
            {
                LevelsManager.SetLevelVisible(l, false);
            }
        }

        #endregion
    }
}
