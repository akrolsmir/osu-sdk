using System;
using System.Collections.Generic;
using System.Text;
using osu.GameplayElements.HitObjects;
using osu.GameModes.Edit.AiMod.Reports;
using osu.GameModes.Edit.AiMod.Rulesets;

//how to AutoComment
//how to Organize imports
//What is getType?
//how to Autoformat
//What are [Flags]
//What is Delegate?
//What replaces super?
//How to use Type?

namespace osu.GameModes.Edit.AiMod.Rulesets
{
    internal class AiSnapping:AiModRuleset
    {
        //Type = AiModType.Snapping;

        public AiSnapping()
        {
            
        }

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

        private void testSliderSnap(HitObjectBase currentHitObject)
        {
            //Check start, in between, and end time
        }


        private void testSpinnerSnap(HitObjectBase currentHitObject)
        {
            //Check start and end time
        }

        private void testNormalSnap(HitObjectBase currentHitObject)
        {
            //Check start time
        }

        private bool testFine()
        {
            return true;
        }

        private AiReportOneObject SnappingReport (HitObjectBase h1, string information)
        {
            //TODO understand delegate
            //TODO get weblink
            BeenCorrectedDelegate d = new BeenCorrectedDelegate(testFine);
            return new AiReportOneObject(h1, d, Severity.Error, information, 0);
        }
    }

    private class SnappingReport : AiReport
    {
    }
}
