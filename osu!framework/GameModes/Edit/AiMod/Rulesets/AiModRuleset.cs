<<<<<<< HEAD:osu!framework/GameModes/Edit/AiMod/AiModRuleset.cs
﻿using System;
using System.Collections.Generic;
using osu.GameplayElements.HitObjects;

namespace osu.GameModes.Edit.AiMod
{
    public abstract class AiModRuleset : MarshalByRefObject
    {
        public List<AiReport> Reports;

        /// <summary>
        /// Set a default type for reports returned by this ruleset.
        /// </summary>
        public abstract AiModType Type { get; }

        public AiModRuleset()
        {
            Reports = new List<AiReport>();
        }

        public List<AiReport> Run(List<HitObjectBase> hitObjects)
        {
            Reports.Clear();
            RunAllRules(hitObjects);
            return Reports;
        }

        /// <summary>
        /// Runs all rules for this ruleset and fills Reports.
        /// </summary>
        protected abstract void RunAllRules(List<HitObjectBase> hitObjects);
    }

    public enum BeatmapDifficulty
    {
        Easy,
        Normal,
        Hard,
        Insane,
        Expert
    }

    public enum AiModType
    {
        All = 0,
        Spacing,
        Snapping,
        Errors,
        Difficulty,
        Style,
        Custom
    }
=======
﻿using System;
using System.Collections.Generic;
using osu.GameplayElements.HitObjects;

namespace osu.GameModes.Edit.AiMod.Rulesets
{
    public abstract class AiModRuleset
    {
        public List<AiReport> Reports;

        /// <summary>
        /// Set a default type for reports returned by this ruleset.
        /// </summary>
        public abstract AiModType Type { get; }

        public AiModRuleset()
        {
            Reports = new List<AiReport>();
        }

        public List<AiReport> Run(List<HitObjectBase> hitObjects)
        {
            Reports.Clear();
            RunAllRules(hitObjects);
            return Reports;
        }

        /// <summary>
        /// Runs all rules for this ruleset and fills Reports.
        /// </summary>
        protected abstract void RunAllRules(List<HitObjectBase> hitObjects);
    }

    public enum BeatmapDifficulty
    {
        Easy,
        Normal,
        Hard,
        Insane,
        Expert
    }

    public enum AiModType
    {
        All = 0,
        Spacing,
        Snapping,
        Errors,
        Difficulty,
        Style,
        Custom
    }
>>>>>>> test3:osu!framework/GameModes/Edit/AiMod/Rulesets/AiModRuleset.cs
}