using System.Collections.Generic;
using osu.GameplayElements.HitObjects;

//how to AutoComment - ///
//how to Organize imports - Edit > Intilliesense > Organize Usings
//What is getType?
//how to Autoformat - ctrl e + d
//What are [Flags]
//What is Delegate?
//What replaces super?
//How to use Type?

namespace osu.GameModes.Edit.AiMod.Rulesets
{
    internal class AiSnapping : AiModRuleset
    {
        //Type = AiModType.Snapping;
        //TODO figure out how to set type to Snapping.
        //public AiSnapping()
        //{
        //}

        /// <summary>
        /// Goes through the list of hitObjects sorting them based on type.
        /// </summary>
        /// <param name="hitObjects"></param>
        protected override void RunAllRules(List<HitObjectBase> hitObjects)
        {
            for (int i = 0; i < hitObjects.Count; i++)
            {
                HitObjectBase currentHitObject = hitObjects[i];
                switch (currentHitObject.Type)
                {
                    case HitObjectType.Normal:
                    case HitObjectType.NormalNewCombo:
                        testNormalSnap(currentHitObject);
                        break;
                    case HitObjectType.Spinner:
                        testSpinnerSnap(currentHitObject);
                        break;
                    case HitObjectType.Slider:
                    case HitObjectType.SliderNewCombo:
                        testSliderSnap(currentHitObject);
                        break;

                }

            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// For circles. Checks for start time snapping only.
        /// </summary>
        /// <param name="currentHitObject"></param>
        private void testNormalSnap(HitObjectBase currentHitObject)
        {
            int startTime = currentHitObject.StartTime;
            if (!isSnapped(startTime))
            {
                Reports.Add(SnappingReport(startTime, "Circle isn't snapped."));
            }

        }

        /// <summary>
        /// For spinners. Checks for start and end time snapping.
        /// </summary>
        /// <param name="currentHitObject"></param>
        private void testSpinnerSnap(HitObjectBase currentHitObject)
        {
            int startTime = currentHitObject.StartTime;
            int endTime = currentHitObject.EndTime;
            if (!isSnapped(startTime))
            {
                Reports.Add(SnappingReport(startTime, "Spinner isn't snapped."));
            }
            else if (!isSnapped(endTime))
            {
                Reports.Add(SnappingReport(startTime, "Spinner's end isn't snapped."));
            }
        }

        /// <summary>
        /// For sliders. Checks for start, repeats, and end time snapping.
        /// </summary>
        /// <param name="currentHitObject"></param>
        private void testSliderSnap(HitObjectBase currentHitObject)
        {
            int startTime = currentHitObject.StartTime;
            int endTime = currentHitObject.EndTime;
            if (!isSnapped(startTime))
            {
                Reports.Add(SnappingReport(startTime, "Slider isn't snapped."));
            }
            //TODO for each repeat, if repeat isn't snapped...
            else if (!isSnapped(endTime))
            {
                Reports.Add(SnappingReport(startTime, "Slider's end isn't snapped."));
            }

        }

        private bool test(int time)
        {
            return true;
            //return if time is snapped
        }

        private bool test()
        {
            return false;
        }

        /// <summary>
        /// Returns true if this time is snapped.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool isSnapped(int time)
        {
            //TODO fill
        }

        /// <summary>
        /// A customized report for snapping errors.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="information"></param>
        /// <returns></returns>
        private AiReport SnappingReport(int time, string information)
        {
            //TODO understand delegate
            //TODO get weblink
            //BeenCorrectedDelegate d = new BeenCorrectedDelegate(testFine);
            return new AiReport(time, Severity.Error, information, 0, new BeenCorrectedDelegate(test(time)));
        }
    }

    private class SnappingReport : AiReport
    {
    }
}
