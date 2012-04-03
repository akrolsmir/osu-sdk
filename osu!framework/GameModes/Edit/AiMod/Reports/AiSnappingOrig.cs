using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using osu.GameModes.Edit.AiMod.Reports;
using osu.GameplayElements.HitObjects;

namespace osu.GameModes.Edit.AiMod.Rulesets
{
    internal class AiSnapping : AiModRuleset
    {
        private const float ERROR_FACTOR = 0.05f;
        private const float MIN_SNAPPING_FACTOR = 0.01f;

        public AiSnapping(Editor editor)
            : base(editor)
        {
        }

        protected override void runAllRules()
        {
            checkBeatSnapping();
        }

        /// <summary>
        /// For each combo 
        /// </summary>
        private void checkBeatSnapping()
        {
            List<HitObjectBase> hitObjects = editor.hitObjectManager.hitObjects;

            for (int i = 0; i < hitObjects.Count; i++)
            {
                if (testBeatSnap(hitObjects[i]))
                {
                    int index = i;
                    AiReport report = new AiReportOneObject(hitObjects[i], delegate { return testBeatSnap(hitObjects[index]); }, Severity.Warning, "Object isn't snapped!", 0);
                    Reports.Add(report);
                }
            }
        }

        private bool testBeatSnap(HitObjectBase hitObject)
        {
            int snapped = editor.Timing.BeatSnapValue(hitObject.StartTime, 8, hitObject.StartTime);

            int snappedSixth = editor.Timing.BeatSnapValue(hitObject.StartTime, 6, hitObject.StartTime);

            bool beatIsSnapped = Math.Abs(snapped - hitObject.StartTime) <= 1 ||
                Math.Abs(snappedSixth - hitObject.StartTime) <= 1;

            return !beatIsSnapped;
        }

        private static float getSnappingFactor(HitObjectBase h1, HitObjectBase h2)
        {
            return Vector2.Distance(h1.EndPosition, h2.Position) / (h2.StartTime - h1.EndTime);
        }
    }
}