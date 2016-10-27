﻿using System.Collections.Generic;

namespace Lucene.Net.Search.Grouping
{
    /// <summary>
    /// A collector that collects all groups that match the
    /// query. Only the group value is collected, and the order
    /// is undefined.  This collector does not determine
    /// the most relevant document of a group.
    /// 
    /// <para>
    /// This is an abstract version. Concrete implementations define
    /// what a group actually is and how it is internally collected.
    /// </para>
    /// @lucene.experimental
    /// </summary>
    /// <typeparam name="TGroupValue"></typeparam>
    public abstract class AbstractAllGroupsCollector<TGroupValue> : AbstractAllGroupsCollector
    {
        /// <summary>
        /// Returns the total number of groups for the executed search.
        /// This is a convenience method. The following code snippet has the same effect: <code>GetGroups().Count</code>
        /// </summary>
        /// <returns>The total number of groups for the executed search</returns>
        public override int GroupCount
        {
            get
            {
                return Groups.Count;
            }
        }

        /// <summary>
        /// Returns the group values
        /// <para>
        /// This is an unordered collections of group values. For each group that matched the query there is a <see cref="BytesRef"/>
        /// representing a group value.
        /// </para>
        /// </summary>
        /// <returns>the group values</returns>
        public abstract ICollection<TGroupValue> Groups { get; }


        // Empty not necessary
        public override Scorer Scorer
        {
            set
            {
            }
        }

        public override bool AcceptsDocsOutOfOrder()
        {
            return true;
        }
    }

    /// <summary>
    /// LUCENENET specific class used to reference <see cref="AbstractAllGroupsCollector{TGroupValue}"/>
    /// without refering to its generic closing type.
    /// </summary>
    public abstract class AbstractAllGroupsCollector : Collector
    {
        /// <summary>
        /// Returns the total number of groups for the executed search.
        /// This is a convenience method. The following code snippet has the same effect: <code>GetGroups().Count</code>
        /// </summary>
        /// <returns>The total number of groups for the executed search</returns>
        public abstract int GroupCount { get; }


        // Empty not necessary
        public override Scorer Scorer
        {
            set
            {
            }
        }

        public override bool AcceptsDocsOutOfOrder()
        {
            return true;
        }
    }
}